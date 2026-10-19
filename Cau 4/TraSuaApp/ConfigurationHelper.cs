using Microsoft.Extensions.Configuration;
using TraSuaApp.Models;

namespace TraSuaApp;

public static class ConfigurationHelper
{
    private static IConfiguration? _configuration;

    public static IConfiguration Configuration
    {
        get
        {
            if (_configuration == null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                _configuration = builder.Build();
            }
            return _configuration;
        }
    }

    public static string GetConnectionString()
    {
        return Configuration.GetConnectionString("DefaultConnection") 
            ?? "Server=(localdb)\\MSSQLLocalDB;Database=QL_TraSua;Trusted_Connection=True;TrustServerCertificate=True;";
    }

    public static PaymentConfig GetPaymentConfig()
    {
        var config = new PaymentConfig();
        var section = Configuration.GetSection("Payment");
        if (section.Exists())
        {
            config.BankId = section["BankId"] ?? "";
            config.AccountNo = section["AccountNo"] ?? "";
            config.AccountName = section["AccountName"] ?? "";
            config.Template = section["Template"] ?? "compact2";
            config.ShopName = section["ShopName"] ?? "";
        }
        return config;
    }
}
