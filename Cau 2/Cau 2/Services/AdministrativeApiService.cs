using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Cau_2.Helpers;
using Serilog;

namespace Cau_2.Services
{
    public class ProvinceDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("division_type")]
        public string? DivisionType { get; set; }

        [JsonPropertyName("codename")]
        public string? Codename { get; set; }

        [JsonPropertyName("wards")]
        public List<WardDto>? Wards { get; set; }

        public override string ToString() => Name;
    }

    public class WardDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("division_type")]
        public string? DivisionType { get; set; }

        [JsonPropertyName("codename")]
        public string? Codename { get; set; }

        [JsonPropertyName("province_code")]
        public int? ProvinceCode { get; set; }

        public override string ToString() => Name;
    }

    public static class AdministrativeApiService
    {
        // Sử dụng một HttpClient dùng chung duy nhất cho toàn ứng dụng theo Best Practice
        private static readonly HttpClient _httpClient;

        static AdministrativeApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(AppConfig.Settings.AdministrativeApiBaseUrl),
                Timeout = TimeSpan.FromSeconds(AppConfig.Settings.ApiTimeoutSeconds) // 10 giây timeout
            };
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "QuanLyNhaTro/1.0 (WindowsForms)");
        }

        /// <summary>
        /// Nạp danh sách tất cả Tỉnh/Thành phố từ API hành chính
        /// </summary>
        public static async Task<List<ProvinceDto>?> GetProvincesAsync()
        {
            try
            {
                using var response = await _httpClient.GetAsync(string.Empty);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var list = JsonSerializer.Deserialize<List<ProvinceDto>>(json, options);
                return list ?? new List<ProvinceDto>();
            }
            catch (HttpRequestException ex)
            {
                Log.Warning(ex, "Lỗi kết nối HTTP khi gọi API danh sách Tỉnh/Thành phố");
                return null;
            }
            catch (TaskCanceledException ex)
            {
                Log.Warning(ex, "Hết thời gian chờ (Timeout 10s) khi gọi API danh sách Tỉnh/Thành phố");
                return null;
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Lỗi không xác định khi nạp danh sách Tỉnh/Thành phố từ API");
                return null;
            }
        }

        /// <summary>
        /// Nạp danh sách Phường/Xã theo mã Tỉnh/Thành phố với depth=2
        /// </summary>
        public static async Task<List<WardDto>?> GetWardsByProvinceAsync(int provinceCode)
        {
            try
            {
                string endpoint = $"p/{provinceCode}?depth=2";
                using var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var province = JsonSerializer.Deserialize<ProvinceDto>(json, options);
                return province?.Wards ?? new List<WardDto>();
            }
            catch (HttpRequestException ex)
            {
                Log.Warning(ex, "Lỗi HTTP khi gọi API danh sách Phường/Xã cho tỉnh {ProvinceCode}", provinceCode);
                return null;
            }
            catch (TaskCanceledException ex)
            {
                Log.Warning(ex, "Hết thời gian chờ (Timeout 10s) khi gọi API Phường/Xã cho tỉnh {ProvinceCode}", provinceCode);
                return null;
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Lỗi không xác định khi nạp danh sách Phường/Xã cho tỉnh {ProvinceCode}", provinceCode);
                return null;
            }
        }
    }
}
