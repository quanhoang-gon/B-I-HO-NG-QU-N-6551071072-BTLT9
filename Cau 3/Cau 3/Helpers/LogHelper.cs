using Serilog;

namespace Cau_3.Helpers
{
    public static class LogHelper
    {
        public static string LogDirectory =>
            Path.Combine(AppContext.BaseDirectory, AppConfig.Settings.LogFolder);

        public static void Initialize()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(
                    path: Path.Combine(LogDirectory, "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            Log.Information("===== Ứng dụng Kế hoạch dã ngoại khởi động =====");
            Log.Information("Thư mục log: {LogDirectory}", LogDirectory);
        }

        public static void Shutdown()
        {
            Log.Information("===== Ứng dụng Kế hoạch dã ngoại đóng =====");
            Log.CloseAndFlush();
        }
    }
}
