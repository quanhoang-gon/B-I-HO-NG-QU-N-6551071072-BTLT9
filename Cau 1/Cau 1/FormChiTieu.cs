using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cau_1.Helpers;
using Cau_1.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Cau_1
{
    public partial class FormChiTieu : Form
    {
        private int? _selectedMaCT = null;
        private bool _isLoading = false;

        // DTO model hiển thị trên DataGridView
        public class ChiTieuViewItem
        {
            public int MaCt { get; set; }
            public DateOnly NgayChi { get; set; }
            public string NgayChiFormat => NgayChi.ToString("dd/MM/yyyy");
            public string NoiDung { get; set; } = string.Empty;
            public string LoaiChi { get; set; } = string.Empty;
            public decimal SoTien { get; set; }
            public string SoTienFormat => SoTien.ToString("N0", new CultureInfo("vi-VN"));
            public string? GhiChu { get; set; }
        }

        public FormChiTieu()
        {
            InitializeComponent();
        }

        private async void FormChiTieu_Load(object sender, EventArgs e)
        {
            try
            {
                // Giới hạn ngày chi tối đa là hôm nay
                dtpNgayChi.MaxDate = DateTime.Today;
                dtpNgayChi.Value = DateTime.Today;

                // Cài đặt mặc định bộ lọc ngày
                dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                dtpDenNgay.Value = DateTime.Today;
                dtpDenNgay.MaxDate = DateTime.Today.AddYears(1);

                cboLoaiChi.SelectedIndex = 0;
                cboLocLoaiChi.SelectedIndex = 0;

                Text = $"{AppConfig.Settings.AppName} - QL_ChiTieu";

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi trong quá trình khởi tạo FormChiTieu");
                MessageBox.Show("Có lỗi xảy ra khi khởi tạo form: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nạp và lọc dữ liệu từ CSDL QL_ChiTieu
        /// </summary>
        private async Task LoadDataAsync()
        {
            try
            {
                _isLoading = true;
                lblTrangThai.Text = "Đang tải dữ liệu...";

                string tuKhoa = txtTimKiem.Text.Trim();
                string loaiChiLoc = cboLocLoaiChi.SelectedItem?.ToString() ?? "-- Tất cả --";
                bool locTheoNgay = chkLocTheoNgay.Checked;
                DateOnly tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
                DateOnly denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);

                using var context = DbContextHelper.GetContext();

                IQueryable<ChiTieu> query = context.ChiTieus.AsNoTracking();

                // 1. Lọc theo nội dung
                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(x => x.NoiDung.Contains(tuKhoa));
                }

                // 2. Lọc theo loại chi
                if (!string.IsNullOrWhiteSpace(loaiChiLoc) && loaiChiLoc != "-- Tất cả --")
                {
                    query = query.Where(x => x.LoaiChi == loaiChiLoc);
                }

                // 3. Lọc theo khoảng thời gian
                if (locTheoNgay)
                {
                    query = query.Where(x => x.NgayChi >= tuNgay && x.NgayChi <= denNgay);
                }

                var listRaw = await query
                    .OrderByDescending(x => x.NgayChi)
                    .ThenByDescending(x => x.MaCt)
                    .ToListAsync();

                var viewList = listRaw.Select(ct => new ChiTieuViewItem
                {
                    MaCt = ct.MaCt,
                    NgayChi = ct.NgayChi,
                    NoiDung = ct.NoiDung,
                    LoaiChi = ct.LoaiChi,
                    SoTien = ct.SoTien,
                    GhiChu = ct.GhiChu
                }).ToList();

                dgvChiTieu.DataSource = viewList;

                // Tính tổng tiền chi và cập nhật Label
                decimal tongTien = viewList.Sum(x => x.SoTien);
                lblTongChi.Text = $"Tổng chi: {tongTien.ToString("N0", new CultureInfo("vi-VN"))} đ ({viewList.Count} khoản chi)";
                lblTrangThai.Text = $"Hiển thị {viewList.Count} khoản chi tiêu.";

                // Nếu đang chọn một dòng thì bỏ chọn để người dùng thao tác mới
                ClearForm();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi truy xuất dữ liệu từ CSDL QL_ChiTieu");
                MessageBox.Show("Không thể tải danh sách chi tiêu từ cơ sở dữ liệu.\nVui lòng kiểm tra kết nối SQL Server trong appsettings.json!",
                    "Lỗi truy cập CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTrangThai.Text = "Lỗi nạp dữ liệu!";
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void ClearForm()
        {
            _selectedMaCT = null;
            txtMaCT.Clear();
            txtNoiDung.Clear();
            nudSoTien.Value = 0;
            txtGhiChu.Clear();
            dtpNgayChi.Value = DateTime.Today;
            if (cboLoaiChi.Items.Count > 0)
                cboLoaiChi.SelectedIndex = 0;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;

            dgvChiTieu.ClearSelection();
            txtNoiDung.Focus();
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ dữ liệu nhập
        /// </summary>
        private bool ValidateInput()
        {
            // 1. Kiểm tra ngày chi không lớn hơn hôm nay
            if (dtpNgayChi.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày chi không được lớn hơn ngày hôm nay!", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayChi.Focus();
                return false;
            }

            // 2. Nội dung không được để trống
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Nội dung chi tiêu không được để trống!", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return false;
            }

            // 3. Số tiền phải lớn hơn 0
            if (nudSoTien.Value <= 0)
            {
                MessageBox.Show("Số tiền chi tiêu phải lớn hơn 0 đ!", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudSoTien.Focus();
                return false;
            }

            // 4. Phải chọn loại chi
            if (cboLoaiChi.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại chi!", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiChi.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Nút Thêm: Ghi lại từng khoản chi mới
        /// </summary>
        private async void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                var ct = new ChiTieu
                {
                    NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value.Date),
                    NoiDung = txtNoiDung.Text.Trim(),
                    LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác",
                    SoTien = nudSoTien.Value,
                    GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
                };

                using (var context = DbContextHelper.GetContext())
                {
                    context.ChiTieus.Add(ct);
                    await context.SaveChangesAsync();
                }

                // Ghi log Serilog mức Information kèm MaCT
                Log.Information("Thêm khoản chi mới thành công: MaCT={MaCT}, NoiDung='{NoiDung}', LoaiChi='{LoaiChi}', SoTien={SoTien}",
                    ct.MaCt, ct.NoiDung, ct.LoaiChi, ct.SoTien);

                MessageBox.Show("Thêm khoản chi tiêu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi thêm khoản chi tiêu vào CSDL. NoiDung={NoiDung}", txtNoiDung.Text);
                MessageBox.Show("Đã xảy ra lỗi khi lưu vào cơ sở dữ liệu. Vui lòng kiểm tra kết nối!",
                    "Lỗi truy cập CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút Sửa: Cập nhật khoản chi đang chọn
        /// </summary>
        private async void BtnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaCT == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng chi tiêu trên danh sách để sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using (var context = DbContextHelper.GetContext())
                {
                    var ct = await context.ChiTieus.FirstOrDefaultAsync(x => x.MaCt == _selectedMaCT.Value);
                    if (ct == null)
                    {
                        MessageBox.Show("Khoản chi tiêu không còn tồn tại trong hệ thống!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        await LoadDataAsync();
                        return;
                    }

                    ct.NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value.Date);
                    ct.NoiDung = txtNoiDung.Text.Trim();
                    ct.LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác";
                    ct.SoTien = nudSoTien.Value;
                    ct.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

                    await context.SaveChangesAsync();
                }

                // Ghi log Serilog mức Information kèm MaCT
                Log.Information("Cập nhật khoản chi thành công: MaCT={MaCT}, NoiDung='{NoiDung}', LoaiChi='{LoaiChi}', SoTien={SoTien}",
                    _selectedMaCT.Value, txtNoiDung.Text.Trim(), cboLoaiChi.SelectedItem, nudSoTien.Value);

                MessageBox.Show("Cập nhật khoản chi tiêu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi cập nhật khoản chi MaCT={MaCT}", _selectedMaCT);
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật vào cơ sở dữ liệu. Vui lòng kiểm tra kết nối!",
                    "Lỗi truy cập CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút Xóa: Hỏi xác nhận trước khi xóa và ghi log
        /// </summary>
        private async void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaCT == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng chi tiêu trên danh sách để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hỏi xác nhận trước khi xóa
            var xacNhan = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khoản chi [Mã: {_selectedMaCT}] - \"{txtNoiDung.Text}\" không?",
                "Xác nhận xóa chi tiêu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes) return;

            try
            {
                using (var context = DbContextHelper.GetContext())
                {
                    var ct = await context.ChiTieus.FirstOrDefaultAsync(x => x.MaCt == _selectedMaCT.Value);
                    if (ct != null)
                    {
                        context.ChiTieus.Remove(ct);
                        await context.SaveChangesAsync();
                    }
                }

                // Ghi log Serilog mức Information kèm MaCT
                Log.Information("Xóa khoản chi tiêu thành công: MaCT={MaCT}", _selectedMaCT.Value);

                MessageBox.Show("Đã xóa khoản chi tiêu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa khoản chi MaCT={MaCT}", _selectedMaCT);
                MessageBox.Show("Đã xảy ra lỗi khi xóa khỏi cơ sở dữ liệu. Vui lòng kiểm tra kết nối!",
                    "Lỗi truy cập CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblTrangThai.Text = "Đã làm mới form nhập liệu.";
        }

        /// <summary>
        /// Khi chọn một dòng trong DataGridView thì đổ dữ liệu lên các controls
        /// </summary>
        private void DgvChiTieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            PopulateSelectedRow();
        }

        private void DgvChiTieu_SelectionChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            PopulateSelectedRow();
        }

        private void PopulateSelectedRow()
        {
            if (dgvChiTieu.CurrentRow == null || dgvChiTieu.CurrentRow.DataBoundItem is not ChiTieuViewItem item)
            {
                return;
            }

            _selectedMaCT = item.MaCt;
            txtMaCT.Text = item.MaCt.ToString();

            // Chuyển DateOnly sang DateTime cho DateTimePicker
            DateTime ngayChiDt = item.NgayChi.ToDateTime(TimeOnly.MinValue);
            if (ngayChiDt <= dtpNgayChi.MaxDate)
            {
                dtpNgayChi.Value = ngayChiDt;
            }
            else
            {
                dtpNgayChi.Value = DateTime.Today;
            }

            txtNoiDung.Text = item.NoiDung;
            cboLoaiChi.SelectedItem = item.LoaiChi;
            nudSoTien.Value = item.SoTien;
            txtGhiChu.Text = item.GhiChu ?? string.Empty;

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;

            lblTrangThai.Text = $"Đang chọn khoản chi Mã: {item.MaCt}";
        }

        // ================== TÌM KIẾM & LỌC DỮ LIỆU ==================

        private async void BtnLoc_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void BtnXoaLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocLoaiChi.SelectedIndex = 0;
            chkLocTheoNgay.Checked = false;
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today;

            await LoadDataAsync();
        }

        private async void CboLocLoaiChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            await LoadDataAsync();
        }

        private void ChkLocTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtpTuNgay.Enabled = chkLocTheoNgay.Checked;
            dtpDenNgay.Enabled = chkLocTheoNgay.Checked;
        }

        private async void TxtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await LoadDataAsync();
            }
        }
    }
}
