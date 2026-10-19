using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cau_1.Helpers;
using Cau_1.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Cau_1
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

                // Đăng ký bắt lỗi chưa được xử lý
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += (s, e) =>
                {
                    Log.Error(e.Exception, "Lỗi UI Thread không được xử lý");
                    MessageBox.Show("Đã xảy ra lỗi không mong muốn trong ứng dụng.\nChi tiết đã được ghi vào file nhật ký.",
                        "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
                AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                {
                    Log.Fatal(e.ExceptionObject as Exception, "Lỗi nghiêm trọng toàn hệ thống — ứng dụng sắp đóng");
                    MessageBox.Show("Đã xảy ra lỗi nghiêm trọng. Ứng dụng sẽ đóng lại.",
                        "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };

                ApplicationConfiguration.Initialize();
                Application.Run(new FormChiTieu());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Không thể khởi động ứng dụng");
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
            Console.WriteLine("=== BẮT ĐẦU KIỂM THỬ TỰ ĐỘNG CSDL & SERILOG ===");
            using var context = DbContextHelper.GetContext();

            // 1. Kiểm tra đọc dữ liệu
            var initialList = await context.ChiTieus.ToListAsync();
            Console.WriteLine($"[PASS] Đọc danh sách: {initialList.Count} khoản chi ban đầu.");

            // 2. Kiểm tra Thêm (Create)
            var testItem = new ChiTieu
            {
                NgayChi = DateOnly.FromDateTime(DateTime.Today),
                NoiDung = "Khoản chi kiểm thử tự động",
                LoaiChi = "Khác",
                SoTien = 50000,
                GhiChu = "Ghi chú test runner"
            };
            context.ChiTieus.Add(testItem);
            await context.SaveChangesAsync();
            Log.Information("Thêm khoản chi kiểm thử thành công: MaCT={MaCT}, NoiDung='{NoiDung}', SoTien={SoTien}",
                testItem.MaCt, testItem.NoiDung, testItem.SoTien);
            Console.WriteLine($"[PASS] Thêm mới thành công: MaCT={testItem.MaCt}");

            // 3. Kiểm tra Sửa (Update)
            testItem.NoiDung = "Khoản chi kiểm thử đã cập nhật";
            testItem.SoTien = 88000;
            await context.SaveChangesAsync();
            Log.Information("Cập nhật khoản chi kiểm thử thành công: MaCT={MaCT}, SoTien={SoTien}",
                testItem.MaCt, testItem.SoTien);
            Console.WriteLine($"[PASS] Cập nhật thành công: MaCT={testItem.MaCt}, SoTien={testItem.SoTien}");

            // 4. Kiểm tra Lọc theo loại chi 'Ăn uống' và tính tổng tiền
            var anUongList = await context.ChiTieus.Where(x => x.LoaiChi == "Ăn uống").ToListAsync();
            decimal tongAnUong = anUongList.Sum(x => x.SoTien);
            Console.WriteLine($"[PASS] Lọc Ăn uống: {anUongList.Count} khoản chi, Tổng tiền: {tongAnUong:N0} đ");

            // 5. Kiểm tra Xóa (Delete)
            int deletedId = testItem.MaCt;
            context.ChiTieus.Remove(testItem);
            await context.SaveChangesAsync();
            Log.Information("Xóa khoản chi kiểm thử thành công: MaCT={MaCT}", deletedId);
            Console.WriteLine($"[PASS] Xóa bản ghi kiểm thử thành công: MaCT={deletedId}");

            Console.WriteLine("=== TẤT CẢ KIỂM THỬ ĐÃ THÀNH CÔNG ===");
        }
    }
}