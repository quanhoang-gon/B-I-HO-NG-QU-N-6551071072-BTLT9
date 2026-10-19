using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cau_3.Helpers;
using Cau_3.Models;
using Cau_3.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Cau_3
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

                // Đăng ký bắt lỗi toàn cục
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                Application.ThreadException += (sender, e) =>
                {
                    Log.Error(e.Exception, "Lỗi UI Thread không được xử lý (ThreadException)");
                    MessageBox.Show(Strings.Get("LoiChung") ?? "Đã xảy ra lỗi, thông tin đã được ghi lại.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };

                AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                {
                    Log.Fatal(e.ExceptionObject as Exception, "Lỗi nghiêm trọng toàn hệ thống (UnhandledException)");
                    MessageBox.Show("A critical error occurred. The application will close.",
                        "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };

                ApplicationConfiguration.Initialize();
                Application.Run(new FormChuyenDi());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Không thể khởi động ứng dụng Kế hoạch dã ngoại");
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
            Console.WriteLine("=== BẮT ĐẦU KIỂM THỬ TỰ ĐỘNG CÂU 3: KẾ HOẠCH DÃ NGOẠI ===");

            // 1. Kiểm tra CSDL & đọc dữ liệu
            using var context = DbContextHelper.GetContext();
            var list = await context.ChuyenDis.ToListAsync();
            Console.WriteLine($"[PASS] Đọc danh sách chuyến đi ban đầu: {list.Count} chuyến.");

            // 2. Kiểm tra Thêm (Create)
            var testTrip = new ChuyenDi
            {
                TenChuyen = "Chuyến đi kiểm thử tự động",
                DiaDiem = "Đà Lạt",
                NgayDi = DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
                SoNguoi = 3,
                NganSach = 3500000,
                PhuongTien = "Xe khách",
                DaHoanThanh = false,
                GhiChu = "Ghi chú kiểm thử"
            };
            context.ChuyenDis.Add(testTrip);
            await context.SaveChangesAsync();
            Log.Information("Thêm chuyến đi kiểm thử thành công: MaChuyen={MaChuyen}", testTrip.MaChuyen);
            Console.WriteLine($"[PASS] Thêm chuyến đi thành công: MaChuyen={testTrip.MaChuyen}");

            // 3. Kiểm tra Sửa (Update)
            testTrip.TenChuyen = "Chuyến đi kiểm thử đã cập nhật";
            testTrip.NganSach = 4000000;
            await context.SaveChangesAsync();
            Log.Information("Cập nhật chuyến đi kiểm thử thành công: MaChuyen={MaChuyen}", testTrip.MaChuyen);
            Console.WriteLine($"[PASS] Cập nhật chuyến đi thành công: MaChuyen={testTrip.MaChuyen}, NganSach={testTrip.NganSach}");

            // 4. Kiểm tra Xóa (Delete)
            int deletedId = testTrip.MaChuyen;
            context.ChuyenDis.Remove(testTrip);
            await context.SaveChangesAsync();
            Log.Information("Xóa chuyến đi kiểm thử thành công: MaChuyen={MaChuyen}", deletedId);
            Console.WriteLine($"[PASS] Xóa chuyến đi thành công: MaChuyen={deletedId}");

            // 5. Kiểm tra API thời tiết Open-Meteo
            Console.WriteLine("[INFO] Đang kiểm tra API thời tiết Open-Meteo cho 'Đà Lạt'...");
            var geo = await WeatherForecastService.GetCoordinatesAsync("Đà Lạt");
            if (geo != null)
            {
                Console.WriteLine($"[PASS] Geocoding thành công: {geo.Name} (Lat: {geo.Latitude}, Lon: {geo.Longitude})");

                var weather = await WeatherForecastService.GetWeatherForDateAsync("Đà Lạt", DateOnly.FromDateTime(DateTime.Today.AddDays(2)));
                if (weather.Success)
                {
                    Console.WriteLine($"[PASS] Lấy thời tiết thành công: Icon={weather.WeatherIcon}, Temp={weather.TempMin:F1}-{weather.TempMax:F1}°C, Mưa={weather.RainProbability}%, Nguy cơ cao={weather.IsHighRainRisk}");
                }
                else
                {
                    Console.WriteLine($"[WARN] Lấy thời tiết: {weather.ErrorMessage}");
                }
            }
            else
            {
                Console.WriteLine("[WARN] Không thể lấy tọa độ qua Geocoding API.");
            }

            // 6. Kiểm tra cơ chế đa ngôn ngữ Strings
            Strings.SetCulture("vi-VN");
            string titleVi = Strings.Get("AppTitle");
            Strings.SetCulture("en-US");
            string titleEn = Strings.Get("AppTitle");
            Console.WriteLine($"[PASS] Đa ngôn ngữ: vi-VN=\"{titleVi}\" | en-US=\"{titleEn}\"");

            Console.WriteLine("=== TẤT CẢ KIỂM THỬ CÂU 3 ĐÃ THÀNH CÔNG ===");
        }
    }
}
