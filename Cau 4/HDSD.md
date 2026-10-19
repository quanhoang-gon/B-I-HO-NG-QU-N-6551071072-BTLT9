# HƯỚNG DẪN SỬ DỤNG VÀ TRIỂN KHAI ỨNG DỤNG QUẢN LÝ QUÁN TRÀ SỮA (CÂU 4)

Ứng dụng **Quản lý quán trà sữa (Tích hợp thanh toán VietQR)** được xây dựng trên nền tảng **.NET 8/10 Windows Forms** kết hợp **Entity Framework Core (SQL Server)**, tích hợp **API sinh mã VietQR động** tự động điền số tiền và nội dung hóa đơn, đồng thời hỗ trợ bán hàng thanh toán tiền mặt và quản lý doanh thu chi tiết.

---

## 1. Cấu trúc thư mục Câu 4
```text
Cau 4/
├── HDSD.md                        # Hướng dẫn chi tiết sử dụng & triển khai
├── README.md                      # Tóm tắt kỹ thuật
├── init_db.sql                    # Script tạo CSDL QL_TraSua & dữ liệu mẫu
├── publish/                       # Thư mục đóng gói độc lập để chép sang máy khác
│   ├── TraSuaApp.exe              # File thực thi chính của ứng dụng
│   ├── appsettings.json           # Cấu hình CSDL & thông tin tài khoản ngân hàng VietQR
│   └── Logs/                      # Thư mục nhật ký Serilog
└── TraSuaApp/
    ├── TraSuaApp.csproj
    ├── appsettings.json
    ├── FormMain.cs                # Giao diện chính (Bán hàng, Thực đơn, Hóa đơn, VietQR)
    ├── FormMain.Designer.cs
    ├── Program.cs                 # Xử lý khởi chạy & log
    ├── Models/                    # Entity models: DanhMucMon, Mon, HoaDon, ChiTietHoaDon
    └── Services/                  # Dịch vụ VietQR & thanh toán
```

---

## 2. Cơ sở dữ liệu (SQL Server)
- **Tên CSDL**: `QL_TraSua`
- **Các bảng**:
  - `DanhMucMon` (MaDM, TenDM)
  - `Mon` (MaMon, TenMon, MaDM, GiaBan, DangBan)
  - `HoaDon` (MaHD, GioLap, HinhThuc, TongTien, DaThanhToan)
  - `ChiTietHoaDon` (MaHD, MaMon, SoLy, DonGia)
- Chạy lại script tạo CSDL (nếu cần):
  ```powershell
  sqlcmd -S "(localdb)\MSSQLLocalDB" -E -f 65001 -i ".\Cau 4\init_db.sql"
  ```

---

## 3. Các tính năng nổi bật
1. **Quản lý thực đơn (CRUD + Tìm kiếm)**: Thêm, sửa, xóa món, lọc theo danh mục, tìm theo tên món.
2. **Lập đơn bán hàng (Giỏ hàng)**: Chọn danh mục, hiển thị danh sách món đang bán, thêm món vào đơn, tự động cộng dồn số lượng, xóa dòng, cập nhật tổng tiền tức thì.
3. **Tích hợp thanh toán VietQR**:
   - Đọc cấu hình ngân hàng từ `appsettings.json` (`BankId`, `AccountNo`, `AccountName`, `Template`, `ShopName`) bằng strongly-typed class, không hard-code.
   - Tự động sinh link ảnh VietQR với số tiền hóa đơn và nội dung chuyển khoản động (VD: `TRASUA HD...`), tải ảnh bằng `HttpClient.GetByteArrayAsync` bất đồng bộ gán vào `PictureBox`.
   - Chịu lỗi mất mạng: Khi mất mạng, hiển thị thông tin ngân hàng và nội dung chuyển khoản dạng chữ để khách chuyển tay.
   - Nút **"Đã nhận tiền"**: Lưu hóa đơn và chi tiết hóa đơn trong cùng một lần giao dịch.
   - Hỗ trợ thanh toán **"Tiền mặt"**: Lưu hóa đơn trực tiếp không qua VietQR.
4. **Danh sách hóa đơn & Doanh thu**: Xem hóa đơn theo ngày bằng `DateTimePicker`, xem chi tiết món từng hóa đơn trên lưới thứ hai, hiển thị tổng doanh thu trong ngày.
5. **Ghi nhật ký Serilog**: Tự động ghi nhận thông tin tạo QR, lưu hóa đơn và bắt lỗi ngoại lệ vào thư mục `Logs/`.

---

## 4. Hướng dẫn chạy và đóng gói
- **Khởi chạy từ mã nguồn**:
  ```powershell
  cd "Cau 4\TraSuaApp"
  dotnet run
  ```
- **Chạy bản đóng gói độc lập**:
  Mở thư mục `Cau 4\publish` và chạy trực tiếp file `TraSuaApp.exe`.
