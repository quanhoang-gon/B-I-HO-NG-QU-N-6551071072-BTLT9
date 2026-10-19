namespace Cau_3.Helpers
{
    public class AppSettings
    {
        public string AppName { get; set; } = "Kế hoạch dã ngoại";
        public string DefaultCulture { get; set; } = "vi-VN";
        public string LogFolder { get; set; } = "Logs";
        public string GeocodingApiUrl { get; set; } = "https://geocoding-api.open-meteo.com/v1/search";
        public string ForecastApiUrl { get; set; } = "https://api.open-meteo.com/v1/forecast";
        public int ApiTimeoutSeconds { get; set; } = 8;
    }
}
