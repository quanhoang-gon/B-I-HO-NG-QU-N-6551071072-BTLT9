using Microsoft.Extensions.Configuration;

namespace Cau_2.Helpers
{
    public static class AppConfig
    {
        public static IConfiguration Configuration { get; private set; } = null!;
        public static AppSettings Settings { get; private set; } = new AppSettings();

        public static void Initialize()
        {
            string env = Environment.GetEnvironmentVariable("APP_ENVIRONMENT") ?? "Production";

            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Settings = Configuration.GetSection("AppSettings").Get<AppSettings>() ?? new AppSettings();
        }

        public static string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                   ?? Configuration.GetConnectionString("DefaultConnection")
                   ?? "Server=(localdb)\\MSSQLLocalDB;Database=QL_NhaTro;Trusted_Connection=True;TrustServerCertificate=True;";
        }
    }
}
