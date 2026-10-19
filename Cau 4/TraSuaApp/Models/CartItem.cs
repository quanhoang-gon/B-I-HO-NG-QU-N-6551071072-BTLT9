namespace TraSuaApp.Models;

public class CartItem
{
    public int MaMon { get; set; }
    public string TenMon { get; set; } = string.Empty;
    public int SoLy { get; set; }
    public decimal DonGia { get; set; }
    public decimal ThanhTien => SoLy * DonGia;
}
