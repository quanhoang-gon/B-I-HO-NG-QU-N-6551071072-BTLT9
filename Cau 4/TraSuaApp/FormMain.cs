using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TraSuaApp.Models;

namespace TraSuaApp;

public partial class FormMain : Form
{
    private readonly BindingList<CartItem> _cartItems = new();
    private int _selectedMonId = -1;
    private readonly HttpClient _httpClient = new() { Timeout = TimeSpan.FromSeconds(10) };

    public FormMain()
    {
        InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
        // Khởi tạo Binding giỏ hàng
        dgvGioHang.DataSource = _cartItems;
        FormatCartGrid();

        LoadCategories();
        LoadThucDon();
        LoadBanHangMenu();
        LoadHoaDonList();
    }

    private void FormatCartGrid()
    {
        if (dgvGioHang.Columns["MaMon"] != null) dgvGioHang.Columns["MaMon"].Visible = false;
        if (dgvGioHang.Columns["TenMon"] != null) dgvGioHang.Columns["TenMon"].HeaderText = "Tên món";
        if (dgvGioHang.Columns["SoLy"] != null)
        {
            dgvGioHang.Columns["SoLy"].HeaderText = "Số lượng";
            dgvGioHang.Columns["SoLy"].Width = 80;
        }
        if (dgvGioHang.Columns["DonGia"] != null)
        {
            dgvGioHang.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Format = "#,##0 đ";
            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        if (dgvGioHang.Columns["ThanhTien"] != null)
        {
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "#,##0 đ";
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }

    private void LoadCategories()
    {
        try
        {
            using var context = new QLTraSuaContext();
            var categories = context.DanhMucMons.AsNoTracking().ToList();

            // Cho Tab Thực đơn
            cboDanhMuc.DataSource = new List<DanhMucMon>(categories);
            cboDanhMuc.DisplayMember = "TenDM";
            cboDanhMuc.ValueMember = "MaDM";

            var filterList = new List<DanhMucMon>
            {
                new DanhMucMon { MaDm = 0, TenDm = "Tất cả danh mục" }
            };
            filterList.AddRange(categories);
            cboLocDanhMuc.DataSource = new List<DanhMucMon>(filterList);
            cboLocDanhMuc.DisplayMember = "TenDm";
            cboLocDanhMuc.ValueMember = "MaDm";
            cboLocDanhMuc.SelectedIndex = 0;

            // Cho Tab Bán hàng
            var banHangFilterList = new List<DanhMucMon>
            {
                new DanhMucMon { MaDm = 0, TenDm = "Tất cả món" }
            };
            banHangFilterList.AddRange(categories);
            cboBanHangDanhMuc.DataSource = banHangFilterList;
            cboBanHangDanhMuc.DisplayMember = "TenDM";
            cboBanHangDanhMuc.ValueMember = "MaDM";
            cboBanHangDanhMuc.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp danh mục món.");
        }
    }

    #region TAB THỰC ĐƠN (CRUD + TÌM KIẾM JOIN)

    private void LoadThucDon()
    {
        try
        {
            using var context = new QLTraSuaContext();
            var query = context.Mons.Include(m => m.MaDmNavigation).AsNoTracking().AsQueryable();

            string keyword = txtTimTenMon.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(m => m.TenMon.Contains(keyword));
            }

            if (cboLocDanhMuc.SelectedValue is int catId && catId > 0)
            {
                query = query.Where(m => m.MaDm == catId);
            }

            var list = query.OrderBy(m => m.MaDm).ThenBy(m => m.TenMon).ToList();

            dgvThucDon.DataSource = list.Select(m => new
            {
                m.MaMon,
                m.TenMon,
                TenDanhMuc = m.MaDmNavigation != null ? m.MaDmNavigation.TenDm : "",
                GiaBan = m.GiaBan.ToString("#,##0") + " đ",
                DangBan = m.DangBan ? "Đang bán" : "Ngừng bán",
                m.MaDm,
                RawGiaBan = m.GiaBan,
                RawDangBan = m.DangBan
            }).ToList();

            if (dgvThucDon.Columns["MaMon"] != null) dgvThucDon.Columns["MaMon"].HeaderText = "Mã";
            if (dgvThucDon.Columns["TenMon"] != null) dgvThucDon.Columns["TenMon"].HeaderText = "Tên món";
            if (dgvThucDon.Columns["TenDanhMuc"] != null) dgvThucDon.Columns["TenDanhMuc"].HeaderText = "Danh mục";
            if (dgvThucDon.Columns["GiaBan"] != null)
            {
                dgvThucDon.Columns["GiaBan"].HeaderText = "Giá bán";
                dgvThucDon.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvThucDon.Columns["DangBan"] != null) dgvThucDon.Columns["DangBan"].HeaderText = "Trạng thái";

            string[] hidden = { "MaDm", "RawGiaBan", "RawDangBan" };
            foreach (var col in hidden)
            {
                if (dgvThucDon.Columns[col] != null) dgvThucDon.Columns[col].Visible = false;
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi nạp danh sách món trong thực đơn.");
        }
    }

    private void dgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && dgvThucDon.Rows[e.RowIndex].DataBoundItem != null)
        {
            dynamic item = dgvThucDon.Rows[e.RowIndex].DataBoundItem;
            _selectedMonId = item.MaMon;
            txtTenMon.Text = item.TenMon;
            cboDanhMuc.SelectedValue = item.MaDm;
            numGiaBan.Value = (decimal)item.RawGiaBan;
            chkDangBan.Checked = item.RawDangBan;

            btnThemMon.Enabled = false;
            btnSuaMon.Enabled = true;
            btnXoaMon.Enabled = true;
        }
    }

    private void btnThemMon_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTenMon.Text))
        {
            MessageBox.Show("Vui lòng nhập tên món!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var context = new QLTraSuaContext();
            var mon = new Mon
            {
                TenMon = txtTenMon.Text.Trim(),
                MaDm = (int)cboDanhMuc.SelectedValue!,
                GiaBan = numGiaBan.Value,
                DangBan = chkDangBan.Checked
            };

            context.Mons.Add(mon);
            context.SaveChanges();

            Log.Information("Thêm món mới thành công: MaMon={MaMon}, TenMon={TenMon}", mon.MaMon, mon.TenMon);
            MessageBox.Show("Thêm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnLamMoiMon_Click(sender, e);
            LoadThucDon();
            LoadBanHangMenu();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi thêm món mới.");
        }
    }

    private void btnSuaMon_Click(object sender, EventArgs e)
    {
        if (_selectedMonId <= 0) return;

        try
        {
            using var context = new QLTraSuaContext();
            var mon = context.Mons.Find(_selectedMonId);
            if (mon != null)
            {
                mon.TenMon = txtTenMon.Text.Trim();
                mon.MaDm = (int)cboDanhMuc.SelectedValue!;
                mon.GiaBan = numGiaBan.Value;
                mon.DangBan = chkDangBan.Checked;

                context.SaveChanges();
                Log.Information("Cập nhật món MaMon={MaMon}", _selectedMonId);
                MessageBox.Show("Cập nhật món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnLamMoiMon_Click(sender, e);
            LoadThucDon();
            LoadBanHangMenu();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi cập nhật món MaMon={MaMon}", _selectedMonId);
        }
    }

    private void btnXoaMon_Click(object sender, EventArgs e)
    {
        if (_selectedMonId <= 0) return;

        if (MessageBox.Show($"Bạn có chắc chắn muốn xóa món '{txtTenMon.Text}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            try
            {
                using var context = new QLTraSuaContext();
                var mon = context.Mons.Find(_selectedMonId);
                if (mon != null)
                {
                    context.Mons.Remove(mon);
                    context.SaveChanges();
                    Log.Information("Xóa món MaMon={MaMon}", _selectedMonId);
                    MessageBox.Show("Đã xóa món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                btnLamMoiMon_Click(sender, e);
                LoadThucDon();
                LoadBanHangMenu();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa món MaMon={MaMon}", _selectedMonId);
                MessageBox.Show("Không thể xóa món này do đã có trong hóa đơn cũ. Bạn có thể chọn 'Ngừng bán' thay vì xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    private void btnLamMoiMon_Click(object sender, EventArgs e)
    {
        _selectedMonId = -1;
        txtTenMon.Clear();
        if (cboDanhMuc.Items.Count > 0) cboDanhMuc.SelectedIndex = 0;
        numGiaBan.Value = 30000;
        chkDangBan.Checked = true;

        btnThemMon.Enabled = true;
        btnSuaMon.Enabled = false;
        btnXoaMon.Enabled = false;
        dgvThucDon.ClearSelection();
    }

    private void ThucDonFilterChanged(object? sender, EventArgs e)
    {
        LoadThucDon();
    }

    private void btnBoLocMon_Click(object sender, EventArgs e)
    {
        txtTimTenMon.Clear();
        cboLocDanhMuc.SelectedIndex = 0;
        LoadThucDon();
    }

    #endregion

    #region TAB BÁN HÀNG & VIETQR

    private void LoadBanHangMenu()
    {
        try
        {
            using var context = new QLTraSuaContext();
            var query = context.Mons.Where(m => m.DangBan).AsNoTracking().AsQueryable();

            if (cboBanHangDanhMuc.SelectedValue is int catId && catId > 0)
            {
                query = query.Where(m => m.MaDm == catId);
            }

            var list = query.OrderBy(m => m.TenMon).ToList();

            dgvMenuBanHang.DataSource = list.Select(m => new
            {
                m.MaMon,
                m.TenMon,
                Gia = m.GiaBan.ToString("#,##0") + " đ",
                RawGia = m.GiaBan
            }).ToList();

            if (dgvMenuBanHang.Columns["MaMon"] != null) dgvMenuBanHang.Columns["MaMon"].Visible = false;
            if (dgvMenuBanHang.Columns["TenMon"] != null) dgvMenuBanHang.Columns["TenMon"].HeaderText = "Tên món";
            if (dgvMenuBanHang.Columns["Gia"] != null)
            {
                dgvMenuBanHang.Columns["Gia"].HeaderText = "Giá bán";
                dgvMenuBanHang.Columns["Gia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvMenuBanHang.Columns["RawGia"] != null) dgvMenuBanHang.Columns["RawGia"].Visible = false;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi nạp menu bán hàng.");
        }
    }

    private void cboBanHangDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadBanHangMenu();
    }

    private void btnThemVaoDon_Click(object sender, EventArgs e)
    {
        if (dgvMenuBanHang.CurrentRow == null || dgvMenuBanHang.CurrentRow.DataBoundItem == null)
        {
            MessageBox.Show("Vui lòng chọn một món trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        dynamic item = dgvMenuBanHang.CurrentRow.DataBoundItem;
        int maMon = item.MaMon;
        string tenMon = item.TenMon;
        decimal donGia = (decimal)item.RawGia;
        int soLy = (int)numSoLy.Value;

        var existing = _cartItems.FirstOrDefault(c => c.MaMon == maMon);
        if (existing != null)
        {
            existing.SoLy += soLy;
            dgvGioHang.Refresh();
        }
        else
        {
            _cartItems.Add(new CartItem
            {
                MaMon = maMon,
                TenMon = tenMon,
                SoLy = soLy,
                DonGia = donGia
            });
        }

        UpdateTongTienGioHang();
    }

    private void btnXoaDongGioHang_Click(object sender, EventArgs e)
    {
        if (dgvGioHang.CurrentRow != null && dgvGioHang.CurrentRow.DataBoundItem is CartItem item)
        {
            _cartItems.Remove(item);
            UpdateTongTienGioHang();
        }
    }

    private decimal GetCartTotal()
    {
        return _cartItems.Sum(c => c.ThanhTien);
    }

    private void UpdateTongTienGioHang()
    {
        decimal total = GetCartTotal();
        lblTongTienDon.Text = $"Tổng tiền: {total:#,##0} đ";
    }

    private async void btnThanhToanChuyenKhoan_Click(object sender, EventArgs e)
    {
        decimal total = GetCartTotal();
        if (total <= 0)
        {
            MessageBox.Show("Giỏ hàng đang trống! Vui lòng thêm món vào đơn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var p = ConfigurationHelper.GetPaymentConfig();
        string noiDung = $"TRASUA HD{DateTime.Now:HHmmss}";
        string qrUrl = $"https://img.vietqr.io/image/{p.BankId}-{p.AccountNo}-{p.Template}.png?amount={(long)total}&addInfo={Uri.EscapeDataString(noiDung)}&accountName={Uri.EscapeDataString(p.AccountName)}";

        lblQRThongTin.Text = $"Quán: {p.ShopName}\n" +
                             $"Ngân hàng (BIN): {p.BankId}\n" +
                             $"Số TK: {p.AccountNo}\n" +
                             $"Chủ TK: {p.AccountName}\n" +
                             $"Số tiền: {total:#,##0} đ\n" +
                             $"Nội dung: {noiDung}\n" +
                             $"(Đang tải mã QR...)";

        try
        {
            Log.Information("Bắt đầu tạo mã VietQR: Số tiền={TongTien}, Nội dung={NoiDung}", total, noiDung);
            byte[] imgBytes = await _httpClient.GetByteArrayAsync(qrUrl);
            using var ms = new MemoryStream(imgBytes);
            picQR.Image = Image.FromStream(ms);

            lblQRThongTin.Text = $"Quán: {p.ShopName}\n" +
                                 $"Ngân hàng (BIN): {p.BankId}\n" +
                                 $"Số TK: {p.AccountNo}\n" +
                                 $"Chủ TK: {p.AccountName}\n" +
                                 $"Số tiền: {total:#,##0} đ\n" +
                                 $"Nội dung: {noiDung}";

            btnDaNhanTien.Enabled = true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Tải ảnh VietQR thất bại từ {Url}", qrUrl);
            picQR.Image = null;
            lblQRThongTin.Text = $"⚠️ Mất kết nối tải ảnh QR!\n\n" +
                                 $"Quý khách vui lòng chuyển khoản thủ công:\n" +
                                 $"• Ngân hàng: {p.BankId}\n" +
                                 $"• Số TK: {p.AccountNo}\n" +
                                 $"• Tên TK: {p.AccountName}\n" +
                                 $"• Số tiền: {total:#,##0} đ\n" +
                                 $"• Nội dung: {noiDung}";
            btnDaNhanTien.Enabled = true; // Cho phép vẫn bấm đã nhận tiền sau khi khách chuyển tay
        }
    }

    private void btnDaNhanTien_Click(object sender, EventArgs e)
    {
        LuuHoaDon("Chuyển khoản");
    }

    private void btnThanhToanTienMat_Click(object sender, EventArgs e)
    {
        decimal total = GetCartTotal();
        if (total <= 0)
        {
            MessageBox.Show("Giỏ hàng đang trống! Vui lòng thêm món vào đơn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (MessageBox.Show($"Xác nhận thanh toán tiền mặt {total:#,##0} đ và lưu hóa đơn?", "Thanh toán tiền mặt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            LuuHoaDon("Tiền mặt");
        }
    }

    private void LuuHoaDon(string hinhThuc)
    {
        decimal total = GetCartTotal();
        if (total <= 0) return;

        try
        {
            using var context = new QLTraSuaContext();

            var hd = new HoaDon
            {
                GioLap = DateTime.Now,
                HinhThuc = hinhThuc,
                TongTien = total,
                DaThanhToan = true
            };

            foreach (var item in _cartItems)
            {
                hd.ChiTietHoaDons.Add(new ChiTietHoaDon
                {
                    MaMon = item.MaMon,
                    SoLy = item.SoLy,
                    DonGia = item.DonGia
                });
            }

            context.HoaDons.Add(hd);
            context.SaveChanges();

            Log.Information("Lưu hóa đơn thành công. MaHD={MaHD}, Hình thức={HinhThuc}, Tổng tiền={TongTien}", hd.MaHd, hinhThuc, total);
            MessageBox.Show($"Lưu hóa đơn #{hd.MaHd} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa sạch giỏ hàng & QR
            _cartItems.Clear();
            UpdateTongTienGioHang();
            picQR.Image = null;
            lblQRThongTin.Text = "Chưa tạo mã VietQR";
            btnDaNhanTien.Enabled = false;

            // Nạp lại tab hóa đơn
            dtpNgayHoaDon.Value = DateTime.Today;
            LoadHoaDonList();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi lưu hóa đơn vào CSDL.");
            MessageBox.Show("Đã xảy ra lỗi khi lưu hóa đơn vào cơ sở dữ liệu.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    #endregion

    #region TAB HÓA ĐƠN & DOANH THU

    private void LoadHoaDonList()
    {
        try
        {
            using var context = new QLTraSuaContext();
            DateTime selectedDate = dtpNgayHoaDon.Value.Date;
            DateTime nextDate = selectedDate.AddDays(1);

            var list = context.HoaDons.AsNoTracking()
                .Where(h => h.GioLap >= selectedDate && h.GioLap < nextDate)
                .OrderByDescending(h => h.GioLap)
                .ToList();

            dgvHoaDon.DataSource = list.Select(h => new
            {
                h.MaHd,
                GioLap = h.GioLap.ToString("HH:mm:ss"),
                h.HinhThuc,
                TongTien = h.TongTien.ToString("#,##0") + " đ",
                RawTongTien = h.TongTien
            }).ToList();

            if (dgvHoaDon.Columns["MaHd"] != null) dgvHoaDon.Columns["MaHd"].HeaderText = "Mã HD";
            if (dgvHoaDon.Columns["GioLap"] != null) dgvHoaDon.Columns["GioLap"].HeaderText = "Giờ lập";
            if (dgvHoaDon.Columns["HinhThuc"] != null) dgvHoaDon.Columns["HinhThuc"].HeaderText = "Hình thức";
            if (dgvHoaDon.Columns["TongTien"] != null)
            {
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvHoaDon.Columns["RawTongTien"] != null) dgvHoaDon.Columns["RawTongTien"].Visible = false;

            decimal doanhThu = list.Sum(h => h.TongTien);
            lblDoanhThuNgay.Text = $"Doanh thu ngày: {doanhThu:#,##0} đ";

            dgvChiTietHoaDon.DataSource = null;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp danh sách hóa đơn theo ngày.");
        }
    }

    private void dtpNgayHoaDon_ValueChanged(object sender, EventArgs e)
    {
        LoadHoaDonList();
    }

    private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && dgvHoaDon.Rows[e.RowIndex].DataBoundItem != null)
        {
            dynamic item = dgvHoaDon.Rows[e.RowIndex].DataBoundItem;
            int maHd = item.MaHd;

            try
            {
                using var context = new QLTraSuaContext();
                var details = context.ChiTietHoaDons
                    .Include(c => c.MaMonNavigation)
                    .Where(c => c.MaHd == maHd)
                    .AsNoTracking()
                    .ToList();

                dgvChiTietHoaDon.DataSource = details.Select(c => new
                {
                    TenMon = c.MaMonNavigation != null ? c.MaMonNavigation.TenMon : "",
                    c.SoLy,
                    DonGia = c.DonGia.ToString("#,##0") + " đ",
                    ThanhTien = (c.SoLy * c.DonGia).ToString("#,##0") + " đ"
                }).ToList();

                if (dgvChiTietHoaDon.Columns["TenMon"] != null) dgvChiTietHoaDon.Columns["TenMon"].HeaderText = "Tên món";
                if (dgvChiTietHoaDon.Columns["SoLy"] != null) dgvChiTietHoaDon.Columns["SoLy"].HeaderText = "SL";
                if (dgvChiTietHoaDon.Columns["DonGia"] != null)
                {
                    dgvChiTietHoaDon.Columns["DonGia"].HeaderText = "Đơn giá";
                    dgvChiTietHoaDon.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvChiTietHoaDon.Columns["ThanhTien"] != null)
                {
                    dgvChiTietHoaDon.Columns["ThanhTien"].HeaderText = "Thành tiền";
                    dgvChiTietHoaDon.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi xem chi tiết hóa đơn #{MaHD}", maHd);
            }
        }
    }

    #endregion
}
