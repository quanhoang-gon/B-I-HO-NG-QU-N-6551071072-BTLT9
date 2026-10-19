# HƯỚNG DẪN SỬ DỤNG VÀ TRIỂN KHAI ỨNG DỤNG SỔ CHI TIÊU CÁ NHÂN (CÂU 1)

Ứng dụng **Sổ chi tiêu cá nhân** được xây dựng bằng **C# Windows Forms (.NET 10)**, sử dụng **Entity Framework Core Database First**, ghi nhật ký bằng **Serilog** và đóng gói phát hành độc lập dạng **Framework-Dependent (win-x64)**.

---

## 1. Cấu trúc thư mục dự án
```text
Cau 1/
├── Cau 1.slnx                     # Solution Visual Studio
├── publish/                       # Thư mục đóng gói để chép sang máy khác chạy ngay
│   ├── Cau 1.exe                  # File thực thi ứng dụng
│   ├── appsettings.json           # File cấu hình kết nối CSDL và ứng dụng
│   ├── appsettings.example.json   # File mẫu cấu hình
│   └── Logs/                      # Thư mục chứa log hàng ngày (tự động tạo)
└── Cau 1/
    ├── Cau 1.csproj
    ├── appsettings.json           # Cấu hình môi trường Production
    ├── appsettings.Development.json # Cấu hình môi trường Development
    ├── appsettings.example.json   # Cấu hình mẫu không chứa mật khẩu
    ├── FormChiTieu.cs             # Xử lý giao diện & nghiệp vụ CRUD, lọc, thống kê
    ├── FormChiTieu.Designer.cs
    ├── Program.cs                 # Điểm khởi chạy, bắt lỗi toàn cục, test runner
    ├── Helpers/
    │   ├── AppConfig.cs           # Đọc file cấu hình bằng ConfigurationBuilder
    │   ├── AppSettings.cs         # Class cấu hình strongly-typed
    │   ├── DbContextHelper.cs     # Cấp phát DbContext từ chuỗi kết nối cấu hình
    │   └── LogHelper.cs           # Khởi tạo và quản lý Serilog
    ├── Models/
    │   ├── ChiTieu.cs             # Model sinh từ EF Core Database First
    │   └── QlChiTieuContext.cs    # DbContext sinh từ EF Core Database First
    └── Scripts/
        └── QL_ChiTieu.sql         # Script tạo CSDL QL_ChiTieu và 12 bản ghi mẫu
```

---

## 2. Cơ sở dữ liệu (Task 1)
- **Tên CSDL**: `QL_ChiTieu`
- **Bảng**: `ChiTieu`
  - `MaCT` (int, IDENTITY, PK)
  - `NgayChi` (date, NOT NULL)
  - `NoiDung` (nvarchar(100), NOT NULL)
  - `LoaiChi` (nvarchar(30), NOT NULL) - Ăn uống, Đi lại, Học tập, Giải trí, Khác
  - `SoTien` (decimal(18,0), NOT NULL)
  - `GhiChu` (nvarchar(200), NULL)
- **Script tạo bảng & nạp mẫu**: Nằm tại `Cau 1/Cau 1/Scripts/QL_ChiTieu.sql`.
- Chạy lại script tạo CSDL (nếu cần):
  ```powershell
  sqlcmd -S "(localdb)\MSSQLLocalDB" -E -f 65001 -i ".\Cau 1\Scripts\QL_ChiTieu.sql"
  ```

---

## 3. Chức năng chính trên giao diện (Task 2, 3, 4)
1. **Hiển thị danh sách**:
   - DataGridView tải danh sách các khoản chi tiêu, tự định dạng tiền tệ Việt Nam (phân tách hàng nghìn) và ngày chi (`dd/MM/yyyy`).
2. **Thêm mới**:
   - Nhập ngày chi (không vượt quá ngày hôm nay), nội dung (bắt buộc), loại chi, số tiền (bước nhảy 1.000, bắt buộc > 0) và ghi chú.
   - Bấm **Thêm** -> dữ liệu lưu vào CSDL, lưới tự làm mới, Serilog ghi log `Information` kèm `MaCT`.
3. **Chọn dòng & Sửa**:
   - Click vào một dòng trên lưới -> dữ liệu tự động đổ lên các control nhập liệu.
   - Chỉnh sửa nội dung / số tiền -> Bấm **Sửa** -> dữ liệu cập nhật vào CSDL, Serilog ghi log `Information` kèm `MaCT`.
4. **Xóa**:
   - Chọn dòng cần xóa -> Bấm **Xóa** -> Hộp thoại hỏi xác nhận (`Yes/No`).
   - Chọn **Yes** -> bản ghi bị xóa khỏi CSDL, Serilog ghi log `Information` kèm `MaCT`.
5. **Tìm kiếm & Lọc dữ liệu**:
   - **Tìm kiếm theo nội dung**: Nhập từ khóa vào ô "Nội dung" (hỗ trợ bấm Enter).
   - **Lọc theo loại chi**: Chọn một loại chi cụ thể trong ComboBox ("Ăn uống", "Đi lại", "Học tập", "Giải trí", "Khác") hoặc chọn "-- Tất cả --" để hiển thị toàn bộ.
   - **Lọc theo khoảng ngày**: Đánh dấu chọn ô "Từ ngày:" để kích hoạt bộ lọc "Từ ngày ... đến ngày ...".
   - Bấm **Bỏ lọc** để hoàn nguyên về trạng thái ban đầu.
6. **Thống kê tổng chi**:
   - Label **"Tổng chi: ... đ"** ở góc dưới bên phải luôn tự động tính tổng tiền của các khoản chi đang hiển thị theo bộ lọc.

---

## 4. Quản lý cấu hình & Bảo mật (Task 5)
- Connection string được tách hoàn toàn ra file `appsettings.json`.
- Hỗ trợ ghi đè khi lập trình bằng file `appsettings.Development.json`.
- Sử dụng `ConfigurationBuilder` và ánh xạ lớp strongly-typed `AppSettings` trong `AppConfig.cs`.
- File cấu hình đã được cấu hình trong `Cau 1.csproj`:
  ```xml
  <None Update="appsettings.json">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </None>
  ```
- File `.gitignore` đã loại trừ các file cấu hình chứa thông tin nhạy cảm (`appsettings.Development.json`, mật khẩu) và thư mục `Logs/`, `bin/`, `obj/`.
- File mẫu `appsettings.example.json` được cung cấp sẵn để phân phối an toàn.

---

## 5. Ghi nhật ký Serilog (Task 6)
- Sử dụng thư viện `Serilog` và `Serilog.Sinks.File`.
- File log được ghi theo ngày dạng `Logs/log-yyyyMMdd.txt` ngay cạnh file thực thi.
- Mức `Information`: Tự động ghi lại khi Thêm / Sửa / Xóa thành công kèm `MaCT`.
- Mức `Error`: Bắt ngoại lệ `try/catch` khi truy cập CSDL bị lỗi hoặc lỗi giao diện không mong muốn, ghi chi tiết stack trace vào log và hiển thị thông báo thân thiện cho người dùng.

---

## 6. Đóng gói & Chạy trên máy khác không cần build lại (Task 7)
### Lệnh đóng gói đã thực hiện:
```powershell
dotnet publish "Cau 1\Cau 1.csproj" -c Release -r win-x64 --no-self-contained -o "publish"
```
Thư mục đóng gói nằm tại: **`Cau 1/publish/`**.

### Cách chuyển sang máy khác:
1. Sao chép toàn bộ thư mục **`publish`** sang máy tính khác (máy đích chỉ cần cài **.NET Desktop Runtime 10.0**).
2. Trên máy đích, mở file `appsettings.json` trong thư mục `publish` bằng Notepad hoặc bất kỳ trình soạn thảo văn bản nào:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=TÊN_SERVER_HOẶC_SQL_EXPRESS_MÁY_ĐÍCH;Database=QL_ChiTieu;Trusted_Connection=True;TrustServerCertificate=True;"
     },
     "AppSettings": {
       "AppName": "Sổ chi tiêu cá nhân",
       "DefaultCulture": "vi-VN",
       "LogFolder": "Logs"
     }
   }
   ```
3. Lưu file `appsettings.json`.
4. Nhấp đúp chuột vào file **`Cau 1.exe`** để chạy trực tiếp **mà không cần cài Visual Studio, .NET SDK hay biên dịch lại code**.
