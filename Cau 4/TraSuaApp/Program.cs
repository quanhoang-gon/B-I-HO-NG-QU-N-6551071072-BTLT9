using Serilog;

namespace TraSuaApp;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        string logPath = Path.Combine(AppContext.BaseDirectory, "Logs", "log-.txt");
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(logPath, rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        Log.Information("Ứng dụng Quản lý quán trà sữa khởi động.");

        try
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Lỗi nghiêm trọng trong ứng dụng Trà sữa.");
            MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Log.Information("Ứng dụng Quản lý quán trà sữa kết thúc.");
            Log.CloseAndFlush();
        }
    }
}