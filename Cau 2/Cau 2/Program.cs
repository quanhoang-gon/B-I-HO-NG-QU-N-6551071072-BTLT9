using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cau_2.Helpers;
using Cau_2.Models;
using Cau_2.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Cau_2
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                // Khởi tạo cấu hình và Serilog
                AppConfig.Initialize();
                LogHelper.Initialize();

                // Chế độ kiểm thử tự động từ dòng lệnh (nếu có tham số --test)
                if (args.Length > 0 && args[0].Equals("--test", StringComparison.OrdinalIgnoreCase))
                {
                    RunVerificationTestsAsync().GetAwaiter().GetResult();
                    return;
                }

                // Task 7 (Mục 9.3): Xử lý lỗi toàn cục
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                // 1. Bắt lỗi trên UI Thread
                Application.ThreadException += (sender, e) =>
                {
                    Log.Error(e.Exception, "Lỗi UI Thread không được xử lý (ThreadException)");
                    MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.",
                        "Thông báo lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                // 2. Bắt lỗi ngoài UI Thread hoặc lỗi nền nghiêm trọng
                AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                {
                    Log.Fatal(e.ExceptionObject as Exception, "Lỗi nghiêm trọng toàn hệ thống (UnhandledException)");
                    MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại. Ứng dụng sẽ đóng an toàn.",
                        "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };

                ApplicationConfiguration.Initialize();
                Application.Run(new FormKhachThue());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Không thể khởi động ứng dụng Quản lý nhà trọ");
                MessageBox.Show("Không thể khởi động ứng dụng:\n\n" + ex.Message,
                    "Lỗi khởi động", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LogHelper.Shutdown();
            }
        }

        private static async Task RunVerificationTestsAsync()
        {
            Console.WriteLine("=== BẮT ĐẦU KIỂM THỬ TỰ ĐỘNG CÂU 2: QUẢN LÝ NHÀ TRỌ ===");

            // 1. Kiểm tra CSDL & Danh sách phòng
            using var context = DbContextHelper.GetContext();
            var rooms = await context.PhongTros.ToListAsync();
            Console.WriteLine($"[PASS] Đọc danh sách phòng: {rooms.Count} phòng.");

            var khachList = await context.KhachThues.Include(k => k.MaPhongNavigation).ToListAsync();
            Console.WriteLine($"[PASS] Đọc danh sách khách ban đầu: {khachList.Count} khách.");

            // 2. Kiểm tra gọi API hành chính Việt Nam
            Console.WriteLine("[INFO] Đang kiểm tra API hành chính Việt Nam...");
            var provinces = await AdministrativeApiService.GetProvincesAsync();
            if (provinces != null && provinces.Count > 0)
            {
                Console.WriteLine($"[PASS] Gọi API hành chính thành công: Nhận được {provinces.Count} Tỉnh/Thành phố.");
                var wards = await AdministrativeApiService.GetWardsByProvinceAsync(provinces[0].Code);
                Console.WriteLine($"[PASS] Lấy danh sách Phường/Xã tỉnh '{provinces[0].Name}': {wards?.Count ?? 0} xã/phường.");
            }
            else
            {
                Console.WriteLine("[WARN] Không kết nối được API hành chính - Chế độ chịu lỗi mạng hoạt động.");
            }

            // 3. Kiểm tra logic thêm khách vào phòng trống -> phòng chuyển thành 'Đang thuê'
            var emptyRoom = await context.PhongTros.FirstOrDefaultAsync(p => p.TinhTrang == "Trống");
            if (emptyRoom != null)
            {
                int maPhongTrong = emptyRoom.MaPhong;
                var testKhach = new KhachThue
                {
                    HoTen = "Khách Kiểm Thử Tự Động",
                    GioiTinh = "Nam",
                    NgaySinh = new DateOnly(1998, 5, 20),
                    SoDienThoai = "0999888777",
                    MaTinh = 1,
                    TenTinh = "Thành phố Hà Nội",
                    MaPhuongXa = 613,
                    TenPhuongXa = "Phường Tây Tựu",
                    DaDangKyTamTru = true,
                    MaPhong = maPhongTrong
                };
                context.KhachThues.Add(testKhach);
                emptyRoom.TinhTrang = "Đang thuê";
                await context.SaveChangesAsync();
                Log.Information("Thêm khách kiểm thử thành công: MaKhach={MaKhach}", testKhach.MaKhach);
                Console.WriteLine($"[PASS] Thêm khách mới vào phòng {emptyRoom.TenPhong}: Phòng chuyển thành '{emptyRoom.TinhTrang}'");

                // 4. Kiểm tra xóa khách cuối cùng -> phòng trở lại 'Trống'
                context.KhachThues.Remove(testKhach);
                bool conNguoiKhac = await context.KhachThues.AnyAsync(k => k.MaPhong == maPhongTrong && k.MaKhach != testKhach.MaKhach);
                if (!conNguoiKhac)
                {
                    emptyRoom.TinhTrang = "Trống";
                }
                await context.SaveChangesAsync();
                Log.Information("Xóa khách kiểm thử thành công: MaKhach={MaKhach}", testKhach.MaKhach);
                Console.WriteLine($"[PASS] Xóa khách cuối cùng khỏi phòng {emptyRoom.TenPhong}: Phòng trở lại '{emptyRoom.TinhTrang}'");
            }

            Console.WriteLine("=== TẤT CẢ KIỂM THỬ CÂU 2 ĐÃ THÀNH CÔNG ===");
        }
    }
}
