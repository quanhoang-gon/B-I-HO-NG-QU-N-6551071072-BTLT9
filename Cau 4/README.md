# Hướng dẫn chạy Bài 4: Quản lý quán trà sữa (Tích hợp VietQR)

## 1. Cơ sở dữ liệu (SQL Server)
- File script tạo cơ sở dữ liệu: `init_db.sql`
- Chạy script:
  ```bash
  sqlcmd -S "(localdb)\MSSQLLocalDB" -E -i init_db.sql
  ```
  *(Tạo 4 bảng: `DanhMucMon`, `Mon`, `HoaDon`, `ChiTietHoaDon`, nạp sẵn 4 danh mục, 12 món và hóa đơn mẫu).*

## 2. Tính năng nổi bật
- **Quản lý thực đơn (CRUD + Tìm kiếm)**: Thêm, sửa, xóa món, lọc theo danh mục, tìm theo tên món.
- **Lập đơn bán hàng (Giỏ hàng)**: Chọn danh mục, hiển thị danh sách món đang bán, thêm món vào đơn, tự động cộng dồn số lượng, xóa dòng, cập nhật tổng tiền tức thì.
- **Tích hợp thanh toán VietQR**:
  - Đọc cấu hình ngân hàng từ `appsettings.json` (BankId, AccountNo, AccountName, Template, ShopName) bằng strongly-typed class, không hard-code.
  - Tự động sinh link ảnh VietQR với số tiền hóa đơn và nội dung chuyển khoản động (VD: `TRASUA HD...`), tải ảnh bằng `HttpClient.GetByteArrayAsync` bất đồng bộ gán vào `PictureBox`.
  - Chịu lỗi mất mạng: Khi mất mạng, hiển thị thông tin ngân hàng và nội dung chuyển khoản dạng chữ để khách chuyển tay.
  - Nút **"Đã nhận tiền"**: Lưu hóa đơn và chi tiết hóa đơn trong cùng một lần giao dịch.
  - Hỗ trợ thanh toán **"Tiền mặt"**: Lưu hóa đơn trực tiếp không qua VietQR.
- **Danh sách hóa đơn & Doanh thu**: Xem hóa đơn theo ngày bằng `DateTimePicker`, xem chi tiết món từng hóa đơn trên lưới thứ hai, hiển thị tổng doanh thu trong ngày.
- **Ghi nhật ký Serilog**: Tự động ghi nhận thông tin tạo QR, lưu hóa đơn và bắt lỗi ngoại lệ vào thư mục `Logs/`.

## 3. Khởi chạy
```bash
cd TraSuaApp
dotnet run
```
