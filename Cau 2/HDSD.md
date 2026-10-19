# HƯỚNG DẪN SỬ DỤNG VÀ TRIỂN KHAI ỨNG DỤNG QUẢN LÝ NHÀ TRỌ (CÂU 2)

Ứng dụng **Quản lý nhà trọ** được thiết kế riêng cho cô Lan: đơn giản, dễ dùng, tích hợp API hành chính Việt Nam và đặc biệt là cơ chế **"không chết khi mất mạng hoặc gặp lỗi bất ngờ"**.

---

## 1. Cấu trúc thư mục Câu 2
```text
Cau 2/
├── Cau 2.slnx                     # Solution Visual Studio
├── publish/                       # Thư mục đóng gói độc lập để chép sang máy khác
│   ├── Cau 2.exe                  # File chạy ứng dụng
│   ├── appsettings.json           # File cấu hình kết nối CSDL và API
│   ├── appsettings.example.json   # Cấu hình mẫu an toàn
│   └── Logs/                      # Thư mục nhật ký Serilog
└── Cau 2/
    ├── Cau 2.csproj
    ├── appsettings.json
    ├── appsettings.Development.json
    ├── appsettings.example.json
    ├── FormKhachThue.cs           # Xử lý giao diện & nghiệp vụ CRUD, lọc, phòng trọ
    ├── FormKhachThue.Designer.cs
    ├── Program.cs                 # Xử lý lỗi toàn cục, test runner tự động
    ├── Helpers/
    │   ├── AppConfig.cs           # Nạp cấu hình từ JSON & biến môi trường
    │   ├── AppSettings.cs         # Cấu hình strongly-typed
    │   ├── DbContextHelper.cs     # Cung cấp QlNhaTroContext
    │   └── LogHelper.cs           # Cấu hình Serilog daily file sink
    ├── Models/
    │   ├── PhongTro.cs            # Model Phòng trọ (có ICollection<KhachThue>)
    │   ├── KhachThue.cs           # Model Khách thuê (có MaPhongNavigation)
    │   └── QlNhaTroContext.cs     # DbContext quản lý liên kết 2 bảng
    ├── Services/
    │   └── AdministrativeApiService.cs # Singleton HttpClient gọi API hành chính VN
    └── Scripts/
        └── QL_NhaTro.sql          # Script tạo CSDL QL_NhaTro, 6 phòng & khách mẫu
```

---

## 2. Cơ sở dữ liệu (Task 1)
- **Tên CSDL**: `QL_NhaTro`
- **Bảng `PhongTro`**:
  - `MaPhong` (int, IDENTITY, PK)
  - `TenPhong` (nvarchar(20))
  - `GiaThue` (decimal(18,0))
  - `TinhTrang` (nvarchar(20): "Trống" / "Đang thuê")
- **Bảng `KhachThue`**:
  - `MaKhach` (int, IDENTITY, PK)
  - `HoTen` (nvarchar(100)), `GioiTinh` (nvarchar(5)), `NgaySinh` (date), `SoDienThoai` (varchar(15))
  - `MaTinh` (int), `TenTinh` (nvarchar(100))
  - `MaPhuongXa` (int), `TenPhuongXa` (nvarchar(100))
  - `DaDangKyTamTru` (bit)
  - `MaPhong` (int, FK -> `PhongTro(MaPhong)`)
- Chạy lại script tạo CSDL (nếu cần):
  ```powershell
  sqlcmd -S "(localdb)\MSSQLLocalDB" -E -f 65001 -i ".\Cau 2\Scripts\QL_NhaTro.sql"
  ```

---

## 3. Tích hợp API hành chính & Chịu lỗi mạng (Task 3 & 8)
- Sử dụng **một `HttpClient` dùng chung duy nhất** (singleton), timeout **10 giây**, gọi `async/await` không gây đơ giao diện.
- **Bình thường**:
  - Mở form: tự động nạp danh sách Tỉnh/Thành từ `https://provinces.open-api.vn/api/v2/`.
  - Chọn một Tỉnh/Thành: tự động nạp danh sách Phường/Xã tương ứng từ `https://provinces.open-api.vn/api/v2/p/{code}?depth=2`.
  - Trong lúc tải: hiện thông báo trạng thái và tạm khóa ComboBox để tránh người dùng thao tác sai.
- **Khi mất mạng hoặc API lỗi / timeout**:
  - Bắt `HttpRequestException`, `TaskCanceledException`, `TimeoutException`.
  - Hiển thị thông báo thân thiện: *"Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng"*.
  - Ghi log mức `Warning` vào file nhật ký.
  - Tự động chuyển ComboBox Tỉnh/Thành và Phường/Xã sang chế độ **cho phép gõ tay** (`DropDownStyle = DropDown`) để cô Lan vẫn nhập được địa chỉ và lưu khách bình thường mà ứng dụng **không hề bị văng/crash**.

---

## 4. Nghiệp vụ CRUD & Cập nhật trạng thái phòng (Task 4 & 5)
- **Hiển thị kết quả JOIN trên DataGridView**:
  - Họ tên, Giới tính, Ngày sinh, SĐT, Tên phòng, Giá thuê (định dạng N0), Quê quán (`Phường/Xã – Tỉnh`), Tạm trú (cột CheckBox).
- **Thêm khách**:
  - Lưu đầy đủ mã và tên Tỉnh/Thành, Phường/Xã.
  - Sau khi thêm khách vào phòng: phòng đó tự động cập nhật `TinhTrang = "Đang thuê"`.
  - Ghi log `Information` kèm `MaKhach`.
- **Sửa khách**:
  - Cho phép sửa thông tin cá nhân, quê quán hoặc đổi sang phòng khác.
  - Nếu đổi sang phòng khác:
    - Phòng mới chuyển sang `"Đang thuê"`.
    - Phòng cũ: kiểm tra nếu không còn khách nào khác thì tự động quay về `"Trống"`.
- **Xóa khách**:
  - Hộp thoại hỏi xác nhận trước khi xóa.
  - Sau khi xóa: kiểm tra số lượng khách còn lại trong phòng. Nếu là người cuối cùng của phòng -> phòng tự động quay về `"Trống"`.
  - Ghi log `Information` kèm `MaKhach`.

---

## 5. Tìm kiếm & Lọc dữ liệu (Task 6)
- Ô tìm kiếm: Tìm nhanh theo **Họ tên** hoặc **Số điện thoại**.
- ComboBox **Lọc Phòng**: Lọc danh sách khách theo từng phòng cụ thể hoặc xem tất cả.
- ComboBox **Lọc Tỉnh**: Lọc danh sách khách theo quê quán Tỉnh/Thành phố.
- Nút **Bỏ lọc**: Hoàn nguyên toàn bộ các tiêu chí lọc về mặc định.

---

## 6. Xử lý lỗi toàn cục & Nút "Gây lỗi thử" (Task 7)
- Đăng ký bắt lỗi toàn cục trong `Program.cs`:
  - `Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)`
  - `Application.ThreadException`
  - `AppDomain.CurrentDomain.UnhandledException`
- Mọi ngoại lệ chưa bắt đều được Serilog ghi lại đầy đủ thông tin stack trace vào file log và hiển thị hộp thoại thân thiện: *"Đã xảy ra lỗi, thông tin đã được ghi lại."* Ứng dụng không bị thoát đột ngột.
- **Nút "⚡ Gây lỗi thử"** (màu đỏ nhạt ở góc phải form):
  - Khi bấm vào nút này, chương trình sẽ cố tình ném ra một ngoại lệ `InvalidOperationException`.
  - Hệ thống lập tức bắt lỗi an toàn, hiện hộp thoại thông báo thân thiện cho cô Lan, ghi chi tiết lỗi vào `Logs/log-yyyyMMdd.txt`, và ứng dụng vẫn tiếp tục chạy bình thường.

---

## 7. Hướng dẫn đóng gói & Chạy trên máy khác (Task 7 & 9.1)
- Lệnh đóng gói đã thực hiện:
  ```powershell
  dotnet publish "Cau 2\Cau 2.csproj" -c Release -r win-x64 --no-self-contained -o "publish"
  ```
- Thư mục đóng gói sẵn sàng: **`Cau 2/publish/`**.
- Để chuyển sang máy khác:
  1. Chép thư mục **`publish`** sang máy tính khác (yêu cầu máy có cài **.NET Desktop Runtime 10.0**).
  2. Mở file `appsettings.json` trong thư mục `publish`, sửa lại `Server=...` cho đúng máy đích.
  3. Nhấp đúp chuột vào file **`Cau 2.exe`** để chạy trực tiếp mà **không cần cài Visual Studio hay biên dịch lại mã nguồn**.
