using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
    public partial class FormKhachThue : Form
    {
        private int? _selectedMaKhach = null;
        private bool _isLoading = false;
        private bool _isApiAvailable = true;
        private List<ProvinceDto> _provinces = new();

        public class KhachThueViewItem
        {
            public int MaKhach { get; set; }
            public string HoTen { get; set; } = string.Empty;
            public string GioiTinh { get; set; } = string.Empty;
            public DateOnly NgaySinh { get; set; }
            public string NgaySinhFormat => NgaySinh.ToString("dd/MM/yyyy");
            public string SoDienThoai { get; set; } = string.Empty;
            public int MaPhong { get; set; }
            public string TenPhong { get; set; } = string.Empty;
            public decimal GiaThue { get; set; }
            public string GiaThueFormat => GiaThue.ToString("N0", new CultureInfo("vi-VN"));
            public int MaTinh { get; set; }
            public string TenTinh { get; set; } = string.Empty;
            public int MaPhuongXa { get; set; }
            public string TenPhuongXa { get; set; } = string.Empty;
            public string QueQuan => $"{TenPhuongXa} – {TenTinh}";
            public bool DaDangKyTamTru { get; set; }
        }

        public class PhongComboItem
        {
            public int MaPhong { get; set; }
            public string DisplayText { get; set; } = string.Empty;

            public override string ToString() => DisplayText;
        }

        public FormKhachThue()
        {
            InitializeComponent();
        }

        private async void FormKhachThue_Load(object sender, EventArgs e)
        {
            try
            {
                Text = $"{AppConfig.Settings.AppName} - Quản lý phòng & Khách thuê";
                dtpNgaySinh.MaxDate = DateTime.Today;
                dtpNgaySinh.Value = new DateTime(2000, 1, 1);

                // Nạp danh sách phòng
                await LoadRoomsAsync();

                // Nạp danh sách Tỉnh/Thành từ API hành chính
                await LoadProvincesFromApiAsync();

                // Nạp dữ liệu khách thuê lên DataGridView
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi trong sự kiện FormKhachThue_Load");
                MessageBox.Show("Có lỗi xảy ra khi khởi động form: " + ex.Message, "Lỗi khởi động",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nạp danh sách phòng trọ vào cboPhong và cboLocPhong
        /// </summary>
        private async Task LoadRoomsAsync()
        {
            try
            {
                using var context = DbContextHelper.GetContext();
                var rooms = await context.PhongTros
                    .Include(p => p.KhachThues)
                    .OrderBy(p => p.TenPhong)
                    .ToListAsync();

                // ComboBox chọn phòng khi nhập liệu
                var phongItems = rooms.Select(p => new PhongComboItem
                {
                    MaPhong = p.MaPhong,
                    DisplayText = $"{p.TenPhong} ({p.TinhTrang} - {p.KhachThues.Count} người - {p.GiaThue:N0}đ)"
                }).ToList();

                cboPhong.DataSource = phongItems;
                cboPhong.DisplayMember = "DisplayText";
                cboPhong.ValueMember = "MaPhong";
                if (cboPhong.Items.Count > 0)
                    cboPhong.SelectedIndex = 0;

                // ComboBox lọc theo phòng
                var locPhongItems = new List<PhongComboItem>
                {
                    new PhongComboItem { MaPhong = 0, DisplayText = "-- Tất cả các phòng --" }
                };
                locPhongItems.AddRange(rooms.Select(p => new PhongComboItem
                {
                    MaPhong = p.MaPhong,
                    DisplayText = $"{p.TenPhong} ({p.TinhTrang})"
                }));

                cboLocPhong.DataSource = locPhongItems;
                cboLocPhong.DisplayMember = "DisplayText";
                cboLocPhong.ValueMember = "MaPhong";
                cboLocPhong.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi nạp danh sách phòng từ CSDL");
            }
        }

        /// <summary>
        /// Nạp danh sách Tỉnh/Thành phố từ API hành chính (Task 3 & 8: Chịu lỗi mạng)
        /// </summary>
        private async Task LoadProvincesFromApiAsync()
        {
            lblTrangThai.Text = "Đang kết nối API nạp danh sách Tỉnh/Thành phố...";
            cboTinhThanh.Enabled = false;
            cboPhuongXa.Enabled = false;

            var provinces = await AdministrativeApiService.GetProvincesAsync();

            if (provinces != null && provinces.Count > 0)
            {
                _isApiAvailable = true;
                _provinces = provinces;

                cboTinhThanh.DataSource = _provinces;
                cboTinhThanh.DisplayMember = "Name";
                cboTinhThanh.ValueMember = "Code";
                cboTinhThanh.Enabled = true;

                // Nạp cho cboLocTinh
                var locTinhList = new List<ProvinceDto>
                {
                    new ProvinceDto { Code = 0, Name = "-- Tất cả Tỉnh/Thành --" }
                };
                locTinhList.AddRange(_provinces);
                cboLocTinh.DataSource = locTinhList;
                cboLocTinh.DisplayMember = "Name";
                cboLocTinh.ValueMember = "Code";
                cboLocTinh.SelectedIndex = 0;

                lblTrangThai.Text = $"Đã tải {_provinces.Count} Tỉnh/Thành phố từ API thành công.";
            }
            else
            {
                // Task 8: Chịu lỗi mạng, thông báo thân thiện và chuyển sang gõ tay
                _isApiAvailable = false;
                cboTinhThanh.DropDownStyle = ComboBoxStyle.DropDown;
                cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
                cboTinhThanh.Enabled = true;
                cboPhuongXa.Enabled = true;

                lblTrangThai.Text = "Mất kết nối API hành chính - Chuyển sang chế độ nhập địa chỉ bằng tay.";
                MessageBox.Show("Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng.\nBạn vẫn có thể gõ trực tiếp tên Tỉnh/Thành và Phường/Xã vào ô nhập liệu để tiếp tục lưu khách.",
                    "Thông báo kết nối mạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Khi chọn một Tỉnh/Thành phố -> nạp danh sách Phường/Xã tương ứng
        /// </summary>
        private async void CboTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading || !_isApiAvailable) return;

            if (cboTinhThanh.SelectedValue is int provinceCode && provinceCode > 0)
            {
                await LoadWardsForProvinceAsync(provinceCode);
            }
        }

        private async Task LoadWardsForProvinceAsync(int provinceCode, int? preselectedWardCode = null)
        {
            try
            {
                cboPhuongXa.Enabled = false;
                lblTrangThai.Text = "Đang tải danh sách Phường/Xã từ API...";

                var wards = await AdministrativeApiService.GetWardsByProvinceAsync(provinceCode);

                if (wards != null && wards.Count > 0)
                {
                    cboPhuongXa.DataSource = wards;
                    cboPhuongXa.DisplayMember = "Name";
                    cboPhuongXa.ValueMember = "Code";
                    cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown; // Cho phép tìm kiếm / gõ tay
                    cboPhuongXa.Enabled = true;

                    if (preselectedWardCode.HasValue)
                    {
                        cboPhuongXa.SelectedValue = preselectedWardCode.Value;
                    }
                    else if (cboPhuongXa.Items.Count > 0)
                    {
                        cboPhuongXa.SelectedIndex = 0;
                    }

                    lblTrangThai.Text = $"Đã tải {wards.Count} Phường/Xã.";
                }
                else
                {
                    // Fallback gõ tay nếu không lấy được xã
                    cboPhuongXa.DataSource = null;
                    cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
                    cboPhuongXa.Enabled = true;
                    lblTrangThai.Text = "Không tải được danh sách Phường/Xã - Cho phép gõ tay.";
                }
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Lỗi khi xử lý danh sách Phường/Xã");
                cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
                cboPhuongXa.Enabled = true;
            }
        }

        /// <summary>
        /// Nạp và lọc dữ liệu khách thuê từ CSDL
        /// </summary>
        private async Task LoadDataAsync()
        {
            try
            {
                _isLoading = true;
                lblTrangThai.Text = "Đang tải dữ liệu...";

                string tuKhoa = txtTimKiem.Text.Trim();
                int locMaPhong = (cboLocPhong.SelectedValue as int?) ?? 0;
                int locMaTinh = (cboLocTinh.SelectedValue as int?) ?? 0;

                using var context = DbContextHelper.GetContext();

                IQueryable<KhachThue> query = context.KhachThues
                    .Include(k => k.MaPhongNavigation)
                    .AsNoTracking();

                // Lọc theo họ tên hoặc số điện thoại
                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(k => k.HoTen.Contains(tuKhoa) || k.SoDienThoai.Contains(tuKhoa));
                }

                // Lọc theo phòng
                if (locMaPhong > 0)
                {
                    query = query.Where(k => k.MaPhong == locMaPhong);
                }

                // Lọc theo tỉnh
                if (locMaTinh > 0)
                {
                    query = query.Where(k => k.MaTinh == locMaTinh);
                }

                var listRaw = await query
                    .OrderByDescending(k => k.MaKhach)
                    .ToListAsync();

                var viewList = listRaw.Select(k => new KhachThueViewItem
                {
                    MaKhach = k.MaKhach,
                    HoTen = k.HoTen,
                    GioiTinh = k.GioiTinh,
                    NgaySinh = k.NgaySinh,
                    SoDienThoai = k.SoDienThoai,
                    MaPhong = k.MaPhong,
                    TenPhong = k.MaPhongNavigation?.TenPhong ?? "—",
                    GiaThue = k.MaPhongNavigation?.GiaThue ?? 0,
                    MaTinh = k.MaTinh,
                    TenTinh = k.TenTinh,
                    MaPhuongXa = k.MaPhuongXa,
                    TenPhuongXa = k.TenPhuongXa,
                    DaDangKyTamTru = k.DaDangKyTamTru
                }).ToList();

                dgvKhachThue.DataSource = viewList;

                // Thống kê phòng
                var allRooms = await context.PhongTros.AsNoTracking().ToListAsync();
                int dangThueCount = allRooms.Count(p => p.TinhTrang == "Đang thuê");
                int trongCount = allRooms.Count(p => p.TinhTrang == "Trống");

                lblTongKet.Text = $"Tổng: {viewList.Count} khách | Đang thuê: {dangThueCount} phòng | Trống: {trongCount} phòng";
                lblTrangThai.Text = $"Hiển thị {viewList.Count} khách thuê.";

                ClearForm();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi truy xuất dữ liệu từ CSDL QL_NhaTro");
                MessageBox.Show("Không thể tải danh sách khách thuê từ cơ sở dữ liệu.\nVui lòng kiểm tra lại cấu hình kết nối SQL Server!",
                    "Lỗi truy cập CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTrangThai.Text = "Lỗi kết nối CSDL!";
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void ClearForm()
        {
            _selectedMaKhach = null;
            txtMaKhach.Clear();
            txtHoTen.Clear();
            rdoNam.Checked = true;
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            txtSoDienThoai.Clear();
            chkTamTru.Checked = false;

            if (cboPhong.Items.Count > 0)
                cboPhong.SelectedIndex = 0;

            if (_isApiAvailable && cboTinhThanh.Items.Count > 0)
            {
                cboTinhThanh.SelectedIndex = 0;
            }
            else
            {
                cboTinhThanh.Text = string.Empty;
                cboPhuongXa.Text = string.Empty;
            }

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvKhachThue.ClearSelection();
            txtHoTen.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên khách thuê!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }

            if (cboPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng trọ!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhong.Focus();
                return false;
            }

            string tenTinh = cboTinhThanh.Text.Trim();
            if (string.IsNullOrWhiteSpace(tenTinh))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Tỉnh/Thành phố quê quán!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTinhThanh.Focus();
                return false;
            }

            string tenPhuongXa = cboPhuongXa.Text.Trim();
            if (string.IsNullOrWhiteSpace(tenPhuongXa))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Phường/Xã quê quán!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhuongXa.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Nút Thêm khách: Cập nhật phòng thành "Đang thuê" và lưu thông tin
        /// </summary>
        private async void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                int maPhong = Convert.ToInt32(cboPhong.SelectedValue);

                int maTinh = 0;
                string tenTinh = cboTinhThanh.Text.Trim();
                if (cboTinhThanh.SelectedValue is int cTinh)
                    maTinh = cTinh;

                int maPhuongXa = 0;
                string tenPhuongXa = cboPhuongXa.Text.Trim();
                if (cboPhuongXa.SelectedValue is int cXa)
                    maPhuongXa = cXa;

                var khach = new KhachThue
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                    NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value.Date),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    MaPhong = maPhong,
                    MaTinh = maTinh,
                    TenTinh = tenTinh,
                    MaPhuongXa = maPhuongXa,
                    TenPhuongXa = tenPhuongXa,
                    DaDangKyTamTru = chkTamTru.Checked
                };

                using (var context = DbContextHelper.GetContext())
                {
                    context.KhachThues.Add(khach);

                    // Khi thêm khách vào phòng thì phòng chuyển sang "Đang thuê"
                    var phong = await context.PhongTros.FindAsync(maPhong);
                    if (phong != null && phong.TinhTrang != "Đang thuê")
                    {
                        phong.TinhTrang = "Đang thuê";
                    }

                    await context.SaveChangesAsync();
                }

                Log.Information("Thêm khách thuê thành công: MaKhach={MaKhach}, HoTen='{HoTen}', Phong={MaPhong}",
                    khach.MaKhach, khach.HoTen, khach.MaPhong);

                MessageBox.Show("Thêm khách thuê vào phòng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadRoomsAsync();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi thêm khách thuê vào CSDL");
                MessageBox.Show("Đã xảy ra lỗi khi lưu khách thuê vào cơ sở dữ liệu!",
                    "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút Sửa khách: Xử lý đổi phòng và cập nhật trạng thái các phòng liên quan
        /// </summary>
        private async void BtnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaKhach == null)
            {
                MessageBox.Show("Vui lòng chọn khách thuê trên lưới để sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                int newMaPhong = Convert.ToInt32(cboPhong.SelectedValue);

                int maTinh = 0;
                string tenTinh = cboTinhThanh.Text.Trim();
                if (cboTinhThanh.SelectedValue is int cTinh)
                    maTinh = cTinh;

                int maPhuongXa = 0;
                string tenPhuongXa = cboPhuongXa.Text.Trim();
                if (cboPhuongXa.SelectedValue is int cXa)
                    maPhuongXa = cXa;

                using (var context = DbContextHelper.GetContext())
                {
                    var khach = await context.KhachThues.FirstOrDefaultAsync(k => k.MaKhach == _selectedMaKhach.Value);
                    if (khach == null)
                    {
                        MessageBox.Show("Khách thuê không còn tồn tại trên hệ thống!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        await LoadDataAsync();
                        return;
                    }

                    int oldMaPhong = khach.MaPhong;

                    khach.HoTen = txtHoTen.Text.Trim();
                    khach.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                    khach.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value.Date);
                    khach.SoDienThoai = txtSoDienThoai.Text.Trim();
                    khach.MaPhong = newMaPhong;
                    khach.MaTinh = maTinh;
                    khach.TenTinh = tenTinh;
                    khach.MaPhuongXa = maPhuongXa;
                    khach.TenPhuongXa = tenPhuongXa;
                    khach.DaDangKyTamTru = chkTamTru.Checked;

                    // Nếu khách đổi phòng trọ
                    if (oldMaPhong != newMaPhong)
                    {
                        // Phòng mới chắc chắn chuyển sang "Đang thuê"
                        var newPhong = await context.PhongTros.FindAsync(newMaPhong);
                        if (newPhong != null) newPhong.TinhTrang = "Đang thuê";

                        // Kiểm tra phòng cũ: nếu không còn khách nào khác thì quay về "Trống"
                        bool oldPhongConNguoi = await context.KhachThues
                            .AnyAsync(k => k.MaPhong == oldMaPhong && k.MaKhach != khach.MaKhach);
                        if (!oldPhongConNguoi)
                        {
                            var oldPhong = await context.PhongTros.FindAsync(oldMaPhong);
                            if (oldPhong != null) oldPhong.TinhTrang = "Trống";
                        }
                    }

                    await context.SaveChangesAsync();
                }

                Log.Information("Cập nhật khách thuê thành công: MaKhach={MaKhach}, HoTen='{HoTen}'",
                    _selectedMaKhach.Value, txtHoTen.Text.Trim());

                MessageBox.Show("Cập nhật thông tin khách thuê thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadRoomsAsync();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi cập nhật khách thuê MaKhach={MaKhach}", _selectedMaKhach);
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật vào cơ sở dữ liệu!",
                    "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút Xóa khách: Nếu là người cuối cùng của phòng thì phòng trở lại "Trống"
        /// </summary>
        private async void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaKhach == null)
            {
                MessageBox.Show("Vui lòng chọn khách thuê trên lưới để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách thuê [Mã: {_selectedMaKhach}] - \"{txtHoTen.Text}\" không?",
                "Xác nhận xóa khách thuê",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var context = DbContextHelper.GetContext())
                {
                    var khach = await context.KhachThues.FirstOrDefaultAsync(k => k.MaKhach == _selectedMaKhach.Value);
                    if (khach != null)
                    {
                        int maPhong = khach.MaPhong;
                        context.KhachThues.Remove(khach);

                        // Kiểm tra nếu xóa người cuối cùng của phòng thì phòng trở lại "Trống"
                        bool conKhachKhac = await context.KhachThues
                            .AnyAsync(k => k.MaPhong == maPhong && k.MaKhach != khach.MaKhach);

                        if (!conKhachKhac)
                        {
                            var phong = await context.PhongTros.FindAsync(maPhong);
                            if (phong != null)
                            {
                                phong.TinhTrang = "Trống";
                            }
                        }

                        await context.SaveChangesAsync();
                    }
                }

                Log.Information("Xóa khách thuê thành công: MaKhach={MaKhach}", _selectedMaKhach.Value);

                MessageBox.Show("Đã xóa khách thuê thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadRoomsAsync();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa khách thuê MaKhach={MaKhach}", _selectedMaKhach);
                MessageBox.Show("Đã xảy ra lỗi khi xóa khách thuê khỏi cơ sở dữ liệu!",
                    "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblTrangThai.Text = "Đã làm mới form nhập liệu.";
        }

        /// <summary>
        /// Nút kiểm thử: Gây lỗi bất ngờ để test UnhandledException handler (Task 7)
        /// </summary>
        private void BtnGayLoiThu_Click(object sender, EventArgs e)
        {
            // Cố ý ném lỗi để kiểm tra Application.ThreadException bắt lỗi an toàn
            throw new InvalidOperationException("⚡ Ngoại lệ kiểm thử do nút 'Gây lỗi thử' tạo ra! Hệ thống đã bắt lỗi an toàn và ghi log thành công.");
        }

        private void DgvKhachThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            PopulateSelectedRow();
        }

        private void DgvKhachThue_SelectionChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            PopulateSelectedRow();
        }

        private async void PopulateSelectedRow()
        {
            if (dgvKhachThue.CurrentRow == null || dgvKhachThue.CurrentRow.DataBoundItem is not KhachThueViewItem item)
            {
                return;
            }

            _selectedMaKhach = item.MaKhach;
            txtMaKhach.Text = item.MaKhach.ToString();
            txtHoTen.Text = item.HoTen;

            if (item.GioiTinh == "Nữ")
                rdoNu.Checked = true;
            else
                rdoNam.Checked = true;

            DateTime ngaySinhDt = item.NgaySinh.ToDateTime(TimeOnly.MinValue);
            dtpNgaySinh.Value = ngaySinhDt <= dtpNgaySinh.MaxDate ? ngaySinhDt : DateTime.Today;

            txtSoDienThoai.Text = item.SoDienThoai;
            chkTamTru.Checked = item.DaDangKyTamTru;

            cboPhong.SelectedValue = item.MaPhong;

            // Xử lý nạp địa chỉ
            if (_isApiAvailable && item.MaTinh > 0)
            {
                cboTinhThanh.SelectedValue = item.MaTinh;
                await LoadWardsForProvinceAsync(item.MaTinh, item.MaPhuongXa);
            }
            else
            {
                cboTinhThanh.Text = item.TenTinh;
                cboPhuongXa.Text = item.TenPhuongXa;
            }

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            lblTrangThai.Text = $"Đang chọn khách: {item.HoTen} (Phòng: {item.TenPhong})";
        }

        // ================== TÌM KIẾM & BỘ LỌC ==================

        private async void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            await LoadDataAsync();
        }

        private async void CboLocPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            await LoadDataAsync();
        }

        private async void CboLocTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            await LoadDataAsync();
        }

        private async void BtnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocPhong.SelectedIndex = 0;
            cboLocTinh.SelectedIndex = 0;
            await LoadDataAsync();
        }
    }
}
