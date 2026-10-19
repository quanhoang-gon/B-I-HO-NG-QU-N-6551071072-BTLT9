namespace Cau_2.Helpers
{
    public class AppSettings
    {
        public string AppName { get; set; } = "Quản lý nhà trọ";
        public string DefaultCulture { get; set; } = "vi-VN";
        public string LogFolder { get; set; } = "Logs";
        public string AdministrativeApiBaseUrl { get; set; } = "https://provinces.open-api.vn/api/v2/";
        public int ApiTimeoutSeconds { get; set; } = 10;
    }
}
