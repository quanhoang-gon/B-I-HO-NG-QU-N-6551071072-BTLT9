namespace TraSuaApp.Models;

public class PaymentConfig
{
    public string BankId { get; set; } = string.Empty;
    public string AccountNo { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public string Template { get; set; } = "compact2";
    public string ShopName { get; set; } = string.Empty;
}
