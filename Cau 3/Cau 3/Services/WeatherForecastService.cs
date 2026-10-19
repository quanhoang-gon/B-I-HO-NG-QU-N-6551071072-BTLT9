using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Cau_3.Helpers;
using Serilog;

namespace Cau_3.Services
{
    public class GeocodingResponse
    {
        [JsonPropertyName("results")]
        public List<GeocodingResult>? Results { get; set; }
    }

    public class GeocodingResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }
    }

    public class ForecastDailyData
    {
        [JsonPropertyName("time")]
        public List<string>? Time { get; set; }

        [JsonPropertyName("weather_code")]
        public List<int>? WeatherCode { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double>? Temperature2mMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double>? Temperature2mMin { get; set; }

        [JsonPropertyName("precipitation_probability_max")]
        public List<int>? PrecipitationProbabilityMax { get; set; }
    }

    public class ForecastResponse
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("daily")]
        public ForecastDailyData? Daily { get; set; }
    }

    public class WeatherInfoResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public bool IsLocationNotFound { get; set; }
        public bool IsOutOfRange { get; set; } // Ngày đi quá 16 ngày
        public string LocationName { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateOnly Date { get; set; }
        public int WeatherCode { get; set; }
        public string WeatherIcon { get; set; } = "☀️";
        public string WeatherDescriptionKey { get; set; } = "WeatherClearSky";
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int RainProbability { get; set; }
        public bool IsHighRainRisk => RainProbability >= 60;
    }

    public static class WeatherForecastService
    {
        private static readonly HttpClient _httpClient;

        static WeatherForecastService()
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(AppConfig.Settings.ApiTimeoutSeconds) // 8 giây timeout
            };
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "KeHoachDaNgoai/1.0 (WindowsForms)");
        }

        /// <summary>
        /// Xóa dấu tiếng Việt để fallback khi tìm kiếm địa danh
        /// </summary>
        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;

            // Xử lý riêng ký tự Đ/đ của tiếng Việt
            text = text.Replace('Đ', 'D').Replace('đ', 'd');

            string normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Bước 1: Tra cứu tọa độ (latitude, longitude) từ tên địa điểm
        /// </summary>
        public static async Task<GeocodingResult?> GetCoordinatesAsync(string locationName)
        {
            try
            {
                string encoded = Uri.EscapeDataString(locationName.Trim());
                string url = $"{AppConfig.Settings.GeocodingApiUrl}?name={encoded}&count=1&language=vi";

                var result = await QueryGeocodingApiAsync(url);
                if (result != null) return result;

                // Nếu không tìm thấy, thử fallback bằng tên không dấu (ví dụ: "Đà Lạt" -> "Da Lat")
                string unaccented = RemoveDiacritics(locationName);
                if (!string.Equals(unaccented, locationName, StringComparison.OrdinalIgnoreCase))
                {
                    string fallbackUrl = $"{AppConfig.Settings.GeocodingApiUrl}?name={Uri.EscapeDataString(unaccented)}&count=1&language=vi";
                    result = await QueryGeocodingApiAsync(fallbackUrl);
                    if (result != null) return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Lỗi khi tra cứu tọa độ địa điểm: {Location}", locationName);
                return null;
            }
        }

        private static async Task<GeocodingResult?> QueryGeocodingApiAsync(string url)
        {
            using var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var geoResponse = JsonSerializer.Deserialize<GeocodingResponse>(json, options);

            if (geoResponse?.Results != null && geoResponse.Results.Count > 0)
            {
                return geoResponse.Results[0];
            }
            return null;
        }

        /// <summary>
        /// Bước 2: Lấy dự báo thời tiết 16 ngày và trích xuất đúng ngày đi
        /// </summary>
        public static async Task<WeatherInfoResult> GetWeatherForDateAsync(string locationName, DateOnly departDate)
        {
            var result = new WeatherInfoResult
            {
                LocationName = locationName,
                Date = departDate
            };

            try
            {
                // 1. Tìm tọa độ
                var geo = await GetCoordinatesAsync(locationName);
                if (geo == null)
                {
                    result.Success = false;
                    result.IsLocationNotFound = true;
                    result.ErrorMessage = Strings.Get("LocationNotFound");
                    return result;
                }

                result.Latitude = geo.Latitude;
                result.Longitude = geo.Longitude;
                result.LocationName = geo.Name;

                // 2. Gọi Open-Meteo Forecast API
                string url = $"{AppConfig.Settings.ForecastApiUrl}?latitude={geo.Latitude.ToString(CultureInfo.InvariantCulture)}&longitude={geo.Longitude.ToString(CultureInfo.InvariantCulture)}&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max&timezone=auto&forecast_days=16";

                using var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var forecast = JsonSerializer.Deserialize<ForecastResponse>(json, options);

                if (forecast?.Daily?.Time == null || forecast.Daily.Time.Count == 0)
                {
                    result.Success = false;
                    result.ErrorMessage = Strings.Get("NoForecastData");
                    return result;
                }

                // 3. Tìm đúng chỉ số của ngày đi trong mảng daily.time
                string targetDateStr = departDate.ToString("yyyy-MM-dd");
                int index = forecast.Daily.Time.IndexOf(targetDateStr);

                if (index == -1)
                {
                    // Ngày đi quá 16 ngày hoặc trong quá khứ
                    result.Success = false;
                    result.IsOutOfRange = true;
                    result.ErrorMessage = Strings.Get("NoForecastData");
                    return result;
                }

                // 4. Lấy các giá trị cùng chỉ số
                int weatherCode = forecast.Daily.WeatherCode != null && index < forecast.Daily.WeatherCode.Count
                    ? forecast.Daily.WeatherCode[index] : 0;

                double tempMin = forecast.Daily.Temperature2mMin != null && index < forecast.Daily.Temperature2mMin.Count
                    ? forecast.Daily.Temperature2mMin[index] : 0;

                double tempMax = forecast.Daily.Temperature2mMax != null && index < forecast.Daily.Temperature2mMax.Count
                    ? forecast.Daily.Temperature2mMax[index] : 0;

                int rainProb = forecast.Daily.PrecipitationProbabilityMax != null && index < forecast.Daily.PrecipitationProbabilityMax.Count
                    ? forecast.Daily.PrecipitationProbabilityMax[index] : 0;

                result.Success = true;
                result.WeatherCode = weatherCode;
                result.TempMin = tempMin;
                result.TempMax = tempMax;
                result.RainProbability = rainProb;

                // 5. Phân loại weather_code
                MapWeatherCode(weatherCode, result);

                return result;
            }
            catch (HttpRequestException ex)
            {
                Log.Warning(ex, "Lỗi kết nối mạng khi lấy dự báo thời tiết Open-Meteo");
                result.Success = false;
                result.ErrorMessage = Strings.Get("NetworkError");
                return result;
            }
            catch (TaskCanceledException ex)
            {
                Log.Warning(ex, "Timeout khi kết nối API thời tiết Open-Meteo");
                result.Success = false;
                result.ErrorMessage = Strings.Get("NetworkError");
                return result;
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Lỗi không xác định khi lấy thời tiết cho {Location}", locationName);
                result.Success = false;
                result.ErrorMessage = Strings.Get("NetworkError");
                return result;
            }
        }

        private static void MapWeatherCode(int code, WeatherInfoResult r)
        {
            if (code == 0)
            {
                r.WeatherIcon = "☀️";
                r.WeatherDescriptionKey = "WeatherClearSky";
            }
            else if (code >= 1 && code <= 3)
            {
                r.WeatherIcon = "⛅";
                r.WeatherDescriptionKey = "WeatherPartlyCloudy";
            }
            else if (code == 45 || code == 48)
            {
                r.WeatherIcon = "🌫️";
                r.WeatherDescriptionKey = "WeatherFog";
            }
            else if ((code >= 51 && code <= 67) || (code >= 80 && code <= 82))
            {
                r.WeatherIcon = "🌧️";
                r.WeatherDescriptionKey = "WeatherRain";
            }
            else if (code >= 95 && code <= 99)
            {
                r.WeatherIcon = "⛈️";
                r.WeatherDescriptionKey = "WeatherThunderstorm";
            }
            else
            {
                r.WeatherIcon = "⛅";
                r.WeatherDescriptionKey = "WeatherPartlyCloudy";
            }
        }
    }
}
