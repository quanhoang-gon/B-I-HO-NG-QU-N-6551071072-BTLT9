# HƯỚNG DẪN SỬ DỤNG VÀ TRIỂN KHAI ỨNG DỤNG KẾ HOẠCH DÃ NGOẠI (CÂU 3)

Ứng dụng **Kế hoạch dã ngoại** (Picnic Trip Planner) được xây dựng trên nền tảng **.NET 10 Windows Forms** kết hợp **EF Core Database First (SQL Server)**, tích hợp **API dự báo thời tiết Open-Meteo miễn phí** và hỗ trợ **đa ngôn ngữ linh hoạt (Tiếng Việt & English)** chuyển đổi tức thì không cần khởi động lại.

---

## 1. Cấu trúc thư mục Câu 3
```text
Cau 3/
├── Cau 3.slnx                     # Solution Visual Studio
├── HDSD.md                        # Tài liệu hướng dẫn sử dụng & triển khai
├── publish/                       # Thư mục đóng gói độc lập để chép sang máy khác
│   ├── Cau 3.exe                  # File thực thi chính của ứng dụng
│   ├── appsettings.json           # Cấu hình kết nối CSDL SQL Server và API
│   ├── appsettings.example.json   # Cấu hình mẫu an toàn
│   └── Logs/                      # Thư mục lưu nhật ký Serilog hàng ngày
└── Cau 3/
    ├── Cau 3.csproj
    ├── appsettings.json
    ├── appsettings.Development.json
    ├── appsettings.example.json
    ├── FormChuyenDi.cs            # Giao diện & xử lý CRUD, thời tiết, song ngữ
    ├── FormChuyenDi.Designer.cs
    ├── Program.cs                 # Xử lý ngoại lệ toàn cục & test runner tự động (--test)
    ├── Helpers/
    │   ├── AppConfig.cs           # Nạp cấu hình từ JSON & biến môi trường
    │   ├── AppSettings.cs         # Cấu hình strongly-typed (Database, WeatherApi, Serilog)
    │   ├── DbContextHelper.cs     # Cung cấp QlDaNgoaiContext kết nối DB
    │   ├── LogHelper.cs           # Cấu hình Serilog daily rolling file sink
    │   ├── Strings.cs             # Bộ từ điển song ngữ (Tiếng Việt & English)
    │   └── UserSettings.cs        # Lưu cấu hình người dùng vào %LocalAppData%\QuanLyDaNgoai
    ├── Models/
    │   ├── ChuyenDi.cs            # Entity Model ChuyenDi
    │   └── QlDaNgoaiContext.cs    # EF Core DbContext
    ├── Services/
    │   └── WeatherForecastService.cs # Xử lý Geocoding + Dự báo 16 ngày Open-Meteo
    └── Scripts/
        └── QL_DaNgoai.sql         # Script tạo CSDL QL_DaNgoai & 8 chuyến đi mẫu
```

---

## 2. Cơ sở dữ liệu (Task 1)
- **Tên CSDL**: `QL_DaNgoai`
- **Bảng `ChuyenDi`**:
  - `MaChuyen` (int, IDENTITY, PK)
  - `TenChuyen` (nvarchar(100)): Tên chuyến dã ngoại
  - `DiaDiem` (nvarchar(100)): Địa điểm đến (Đà Lạt, Sa Pa, Vũng Tàu, Hội An, Phú Quốc...)
  - `NgayDi` (date): Ngày khởi hành
  - `SoNguoi` (int): Số lượng thành viên tham gia
  - `NganSach` (decimal(18,0)): Ngân sách dự kiến (VND)
  - `PhuongTien` (nvarchar(30)): Xe máy, Ô tô cá nhân, Xe khách, Tàu hỏa, Máy bay...
  - `DaHoanThanh` (bit): Trạng thái chuyến đi (0: Chưa hoàn thành, 1: Đã hoàn thành)
  - `GhiChu` (nvarchar(200), NULL): Ghi chú bổ sung
- Chạy lại script tạo CSDL (nếu cần):
  ```powershell
  sqlcmd -S "(localdb)\MSSQLLocalDB" -E -f 65001 -i ".\Cau 3\Cau 3\Scripts\QL_DaNgoai.sql"
  ```

---

## 3. Nghiệp vụ CRUD & Ràng buộc hợp lệ (Task 2 & 3)
- **Thêm chuyến đi mới**:
  - Ràng buộc: `NgayDi >= ngày hiện tại` (chỉ áp dụng khi tạo mới chuyến đi).
  - Ràng buộc: `SoNguoi >= 1` và `NganSach >= 0`.
  - Tự động gán chuyến mới ở trạng thái Chưa hoàn thành (nếu không tích chọn).
  - Ghi log `Information` kèm mã chuyến đi vừa thêm.
- **Sửa thông tin**:
  - Chọn dòng cần sửa trên DataGridView -> Dữ liệu đổ lên form nhập liệu.
  - Cho phép sửa mọi thông tin và đánh dấu `"Đã hoàn thành"`.
  - Ghi log `Information` chi tiết khi cập nhật.
- **Xóa chuyến đi**:
  - Có hộp thoại cảnh báo xác nhận trước khi xóa (bằng ngôn ngữ đang chọn).
  - Ghi log `Information` khi xóa thành công.
- **Làm mới form**:
  - Xóa trắng form, đặt lại ngày đi mặc định là ngày mai, số người = 1, ngân sách = 0.

---

## 4. Tìm kiếm & Lọc chuyến đi (Task 4)
- **Tìm kiếm từ khóa**: Nhập tên chuyến hoặc địa điểm vào ô tìm kiếm -> dữ liệu lọc ngay lập tức.
- **Lọc chưa hoàn thành**: Tích vào CheckBox `"Chỉ xem chuyến chưa hoàn thành"` để lọc nhanh những kế hoạch sắp diễn ra.
- **Lọc theo khoảng thời gian**:
  - Chọn `"Từ ngày"` và `"Đến ngày"`.
  - Tích `"Bật lọc ngày"` để áp dụng lọc chuyến đi có `NgayDi` nằm trong khoảng thời gian này.
- **Bỏ lọc**: Khôi phục danh sách hiển thị đầy đủ ban đầu.

---

## 5. Tích hợp API thời tiết Open-Meteo & Panel thời tiết (Task 5 & 6)
- **Cơ chế 2 bước**:
  1. **Geocoding API**: `https://geocoding-api.open-meteo.com/v1/search?name={DiaDiem}&count=1`
     - Tự động bỏ dấu tiếng Việt (ví dụ: *Đà Lạt* -> *Da Lat*, *Hội An* -> *Hoi An*) nếu tìm với chuỗi tiếng Việt có dấu không ra kết quả.
  2. **16-day Weather Forecast API**: `https://api.open-meteo.com/v1/forecast?...`
     - Tìm đúng phần tử trong mảng `daily.time` khớp với `NgayDi`.
- **Panel hiển thị thông tin thời tiết**:
  - **Biểu tượng cảm xúc (Icon)**: ☀️ Trời trong, ⛅ Mây rải rác, ☁️ Nhiều mây, 🌫️ Sương mù, 🌧️ Mưa phùn/mưa rào, ⛈️ Dông sét...
  - **Mô tả thời tiết**: Dịch tương ứng theo mã WMO Weather Interpretation Codes (0, 1-3, 45/48, 51-67/80-82, 95-99).
  - **Nhiệt độ**: Hiển thị nhiệt độ thấp nhất và cao nhất trong ngày (ví dụ: `15.5°C - 25.1°C`).
  - **Xác suất mưa**: Tỷ lệ phần trăm dự báo mưa (`precipitation_probability_max`).
  - **Cảnh báo nguy cơ mưa cao**: Nếu xác suất mưa `>= 60%`, panel chuyển sang viền/màu cảnh báo da cam nổi bật kèm khuyến cáo: *"Nguy cơ mưa cao! Nên mang áo mưa hoặc xem xét dời lịch dã ngoại"*.
  - **Thông báo quá 16 ngày**: Nếu ngày đi vượt quá tầm dự báo 16 ngày của Open-Meteo, hiển thị thông báo: *"Chưa có dữ liệu dự báo cho ngày này (quá 16 ngày)"*.
- **Chịu lỗi & Trải nghiệm người dùng**:
  - Sử dụng **một `HttpClient` dùng chung duy nhất** (singleton pattern) với Timeout **8 giây**.
  - Hiệu ứng **ProgressBar Marquee** và thông báo *"Đang tải thời tiết..."* trong lúc chờ dữ liệu, tuyệt đối không gây đơ/treo UI.
  - Khi mất mạng hoặc API lỗi: Hiện thông báo nhắc nhở nhẹ nhàng, ghi log `Warning`, ứng dụng vẫn chạy trơn tru, **không bị văng/crash**.

---

## 6. Đa ngôn ngữ tức thì (Tiếng Việt & English) (Task 7)
- Cụm điều khiển **RadioButtons**: `Tiếng Việt` và `English`.
- Khi người dùng bấm chuyển đổi:
  - Tất cả nhãn, tiêu đề, nút bấm, GroupBox, cột DataGridView, trạng thái, câu cảnh báo và mô tả thời tiết chuyển đổi **ngay lập tức** mà **không cần khởi động lại ứng dụng**.
  - Lựa chọn ngôn ngữ được tự động lưu lại vào file `%LocalAppData%\QuanLyDaNgoai\usersettings.json`. Khi mở lại ứng dụng vào lần sau, ngôn ngữ người dùng đã chọn sẽ được nạp lại chính xác.

---

## 7. Hướng dẫn đóng gói & Triển khai sang laptop khác (Task 8)

### Cách 1: Chép thư mục `publish`
Thư mục `publish/` đã được build sẵn theo dạng **Framework-Dependent (`win-x64`)**:
1. Copy toàn bộ thư mục `publish/` sang laptop người dùng khác (ví dụ: `C:\QuanLyDaNgoai`).
2. Yêu cầu trên laptop đích: Đã cài **.NET 10 Desktop Runtime** và **SQL Server** (LocalDB hoặc SQL Server Express).
3. Chạy file SQL `QL_DaNgoai.sql` để tạo CSDL và 8 chuyến đi mẫu.
4. Mở file `appsettings.json` trong thư mục `publish/` để kiểm tra chuỗi kết nối:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=QL_DaNgoai;Trusted_Connection=True;TrustServerCertificate=True"
     }
   }
   ```
   *(Nếu máy khác dùng SQL Express, sửa `(localdb)\\MSSQLLocalDB` thành `.\\SQLEXPRESS` mà không cần biên dịch lại mã nguồn).*
5. Nhấp đúp vào `Cau 3.exe` để sử dụng ngay.

### Cách 2: Tự đóng gói lại từ mã nguồn
```powershell
# Di chuyển vào thư mục repo
cd "c:\Users\Hoang Quan\source\repos\BTLT9"

# Biên dịch kiểm tra
dotnet build "Cau 3\Cau 3\Cau 3.csproj"

# Đóng gói Release
dotnet publish "Cau 3\Cau 3\Cau 3.csproj" -c Release -r win-x64 --no-self-contained -o "Cau 3\publish"
```

---

## 8. Lệnh kiểm thử tự động
Dự án được tích hợp sẵn bộ kiểm thử tự động toàn diện qua tham số `--test`:
```powershell
dotnet run --project "Cau 3\Cau 3\Cau 3.csproj" -- --test
```
Bộ test sẽ tự động xác minh:
1. Đọc danh sách chuyến đi từ CSDL `QL_DaNgoai`.
2. Thêm mới chuyến đi thử nghiệm.
3. Cập nhật chuyến đi vừa thêm.
4. Xóa chuyến đi vừa tạo.
5. Gọi API Geocoding Open-Meteo và API dự báo thời tiết 16 ngày thực tế.
6. Chuyển đổi song ngữ Tiếng Việt và English.
