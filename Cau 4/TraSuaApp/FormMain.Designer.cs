namespace TraSuaApp;

partial class FormMain
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.tabControlMain = new System.Windows.Forms.TabControl();
        this.tabThucDon = new System.Windows.Forms.TabPage();
        this.tabBanHang = new System.Windows.Forms.TabPage();
        this.tabHoaDon = new System.Windows.Forms.TabPage();

        // 1. Controls của tabThucDon
        this.grpThucDonInput = new System.Windows.Forms.GroupBox();
        this.lblTenMon = new System.Windows.Forms.Label();
        this.txtTenMon = new System.Windows.Forms.TextBox();
        this.lblDanhMuc = new System.Windows.Forms.Label();
        this.cboDanhMuc = new System.Windows.Forms.ComboBox();
        this.lblGiaBan = new System.Windows.Forms.Label();
        this.numGiaBan = new System.Windows.Forms.NumericUpDown();
        this.chkDangBan = new System.Windows.Forms.CheckBox();
        this.btnThemMon = new System.Windows.Forms.Button();
        this.btnSuaMon = new System.Windows.Forms.Button();
        this.btnXoaMon = new System.Windows.Forms.Button();
        this.btnLamMoiMon = new System.Windows.Forms.Button();
        this.grpThucDonFilter = new System.Windows.Forms.GroupBox();
        this.lblTimTenMon = new System.Windows.Forms.Label();
        this.txtTimTenMon = new System.Windows.Forms.TextBox();
        this.lblLocDanhMuc = new System.Windows.Forms.Label();
        this.cboLocDanhMuc = new System.Windows.Forms.ComboBox();
        this.btnBoLocMon = new System.Windows.Forms.Button();
        this.dgvThucDon = new System.Windows.Forms.DataGridView();

        // 2. Controls của tabBanHang
        this.lblBanHangDanhMuc = new System.Windows.Forms.Label();
        this.cboBanHangDanhMuc = new System.Windows.Forms.ComboBox();
        this.lblDanhSachMon = new System.Windows.Forms.Label();
        this.dgvMenuBanHang = new System.Windows.Forms.DataGridView();
        this.lblSoLy = new System.Windows.Forms.Label();
        this.numSoLy = new System.Windows.Forms.NumericUpDown();
        this.btnThemVaoDon = new System.Windows.Forms.Button();
        this.lblGioHang = new System.Windows.Forms.Label();
        this.dgvGioHang = new System.Windows.Forms.DataGridView();
        this.btnXoaDongGioHang = new System.Windows.Forms.Button();
        this.lblTongTienDon = new System.Windows.Forms.Label();
        this.btnThanhToanChuyenKhoan = new System.Windows.Forms.Button();
        this.btnThanhToanTienMat = new System.Windows.Forms.Button();
        this.grpVietQR = new System.Windows.Forms.GroupBox();
        this.picQR = new System.Windows.Forms.PictureBox();
        this.lblQRThongTin = new System.Windows.Forms.Label();
        this.btnDaNhanTien = new System.Windows.Forms.Button();

        // 3. Controls của tabHoaDon
        this.lblNgayHoaDon = new System.Windows.Forms.Label();
        this.dtpNgayHoaDon = new System.Windows.Forms.DateTimePicker();
        this.lblDoanhThuNgay = new System.Windows.Forms.Label();
        this.lblDanhSachHD = new System.Windows.Forms.Label();
        this.dgvHoaDon = new System.Windows.Forms.DataGridView();
        this.lblChiTietHD = new System.Windows.Forms.Label();
        this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();

        this.tabControlMain.SuspendLayout();
        this.tabThucDon.SuspendLayout();
        this.tabBanHang.SuspendLayout();
        this.tabHoaDon.SuspendLayout();
        this.grpThucDonInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numGiaBan)).BeginInit();
        this.grpThucDonFilter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvMenuBanHang)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numSoLy)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
        this.grpVietQR.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
        this.SuspendLayout();

        // 
        // tabControlMain
        // 
        this.tabControlMain.Controls.Add(this.tabBanHang);
        this.tabControlMain.Controls.Add(this.tabThucDon);
        this.tabControlMain.Controls.Add(this.tabHoaDon);
        this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.tabControlMain.Location = new System.Drawing.Point(0, 0);
        this.tabControlMain.Name = "tabControlMain";
        this.tabControlMain.SelectedIndex = 0;
        this.tabControlMain.Size = new System.Drawing.Size(1240, 680);
        this.tabControlMain.TabIndex = 0;

        // ==========================================
        // TAB 1: BÁN HÀNG & VIETQR
        // ==========================================
        this.tabBanHang.Controls.Add(this.lblBanHangDanhMuc);
        this.tabBanHang.Controls.Add(this.cboBanHangDanhMuc);
        this.tabBanHang.Controls.Add(this.lblDanhSachMon);
        this.tabBanHang.Controls.Add(this.dgvMenuBanHang);
        this.tabBanHang.Controls.Add(this.lblSoLy);
        this.tabBanHang.Controls.Add(this.numSoLy);
        this.tabBanHang.Controls.Add(this.btnThemVaoDon);
        this.tabBanHang.Controls.Add(this.lblGioHang);
        this.tabBanHang.Controls.Add(this.dgvGioHang);
        this.tabBanHang.Controls.Add(this.btnXoaDongGioHang);
        this.tabBanHang.Controls.Add(this.lblTongTienDon);
        this.tabBanHang.Controls.Add(this.btnThanhToanChuyenKhoan);
        this.tabBanHang.Controls.Add(this.btnThanhToanTienMat);
        this.tabBanHang.Controls.Add(this.grpVietQR);
        this.tabBanHang.Location = new System.Drawing.Point(4, 25);
        this.tabBanHang.Name = "tabBanHang";
        this.tabBanHang.Padding = new System.Windows.Forms.Padding(3);
        this.tabBanHang.Size = new System.Drawing.Size(1232, 651);
        this.tabBanHang.Text = "  ☕ Lập đơn & Thanh toán (VietQR)  ";
        this.tabBanHang.UseVisualStyleBackColor = true;

        // Chọn Danh mục & Menu món
        this.lblBanHangDanhMuc.Location = new System.Drawing.Point(15, 15);
        this.lblBanHangDanhMuc.Text = "Chọn danh mục:";
        this.lblBanHangDanhMuc.Size = new System.Drawing.Size(110, 23);

        this.cboBanHangDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboBanHangDanhMuc.Location = new System.Drawing.Point(130, 12);
        this.cboBanHangDanhMuc.Size = new System.Drawing.Size(260, 24);
        this.cboBanHangDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboBanHangDanhMuc_SelectedIndexChanged);

        this.lblDanhSachMon.Location = new System.Drawing.Point(15, 48);
        this.lblDanhSachMon.Text = "Danh sách món đang bán:";
        this.lblDanhSachMon.Size = new System.Drawing.Size(200, 20);

        this.dgvMenuBanHang.AllowUserToAddRows = false;
        this.dgvMenuBanHang.AllowUserToDeleteRows = false;
        this.dgvMenuBanHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvMenuBanHang.BackgroundColor = System.Drawing.Color.White;
        this.dgvMenuBanHang.Location = new System.Drawing.Point(15, 72);
        this.dgvMenuBanHang.MultiSelect = false;
        this.dgvMenuBanHang.Name = "dgvMenuBanHang";
        this.dgvMenuBanHang.ReadOnly = true;
        this.dgvMenuBanHang.RowHeadersVisible = false;
        this.dgvMenuBanHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvMenuBanHang.Size = new System.Drawing.Size(375, 520);

        // Số ly & Nút thêm
        this.lblSoLy.Location = new System.Drawing.Point(15, 608);
        this.lblSoLy.Text = "Số ly:";
        this.lblSoLy.Size = new System.Drawing.Size(50, 23);

        this.numSoLy.Location = new System.Drawing.Point(65, 605);
        this.numSoLy.Minimum = 1M;
        this.numSoLy.Value = 1M;
        this.numSoLy.Size = new System.Drawing.Size(80, 24);

        this.btnThemVaoDon.Text = "👉 Thêm vào đơn";
        this.btnThemVaoDon.BackColor = System.Drawing.Color.PaleGreen;
        this.btnThemVaoDon.Location = new System.Drawing.Point(160, 600);
        this.btnThemVaoDon.Size = new System.Drawing.Size(230, 35);
        this.btnThemVaoDon.Click += new System.EventHandler(this.btnThemVaoDon_Click);

        // Giỏ hàng
        this.lblGioHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblGioHang.Location = new System.Drawing.Point(410, 15);
        this.lblGioHang.Text = "Chi tiết giỏ hàng hiện tại:";
        this.lblGioHang.Size = new System.Drawing.Size(250, 23);

        this.dgvGioHang.AllowUserToAddRows = false;
        this.dgvGioHang.AllowUserToDeleteRows = false;
        this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
        this.dgvGioHang.Location = new System.Drawing.Point(410, 45);
        this.dgvGioHang.MultiSelect = false;
        this.dgvGioHang.Name = "dgvGioHang";
        this.dgvGioHang.ReadOnly = true;
        this.dgvGioHang.RowHeadersVisible = false;
        this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvGioHang.Size = new System.Drawing.Size(460, 480);

        this.btnXoaDongGioHang.Text = "❌ Xóa dòng đã chọn";
        this.btnXoaDongGioHang.Location = new System.Drawing.Point(410, 535);
        this.btnXoaDongGioHang.Size = new System.Drawing.Size(160, 32);
        this.btnXoaDongGioHang.Click += new System.EventHandler(this.btnXoaDongGioHang_Click);

        this.lblTongTienDon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTongTienDon.ForeColor = System.Drawing.Color.Crimson;
        this.lblTongTienDon.Location = new System.Drawing.Point(410, 575);
        this.lblTongTienDon.Text = "Tổng tiền: 0 đ";
        this.lblTongTienDon.Size = new System.Drawing.Size(460, 30);

        this.btnThanhToanChuyenKhoan.Text = "💳 Thanh toán chuyển khoản (VietQR)";
        this.btnThanhToanChuyenKhoan.BackColor = System.Drawing.Color.LightSkyBlue;
        this.btnThanhToanChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnThanhToanChuyenKhoan.Location = new System.Drawing.Point(410, 610);
        this.btnThanhToanChuyenKhoan.Size = new System.Drawing.Size(270, 35);
        this.btnThanhToanChuyenKhoan.Click += new System.EventHandler(this.btnThanhToanChuyenKhoan_Click);

        this.btnThanhToanTienMat.Text = "💵 Tiền mặt";
        this.btnThanhToanTienMat.BackColor = System.Drawing.Color.Khaki;
        this.btnThanhToanTienMat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnThanhToanTienMat.Location = new System.Drawing.Point(690, 610);
        this.btnThanhToanTienMat.Size = new System.Drawing.Size(180, 35);
        this.btnThanhToanTienMat.Click += new System.EventHandler(this.btnThanhToanTienMat_Click);

        // Khung VietQR
        this.grpVietQR.Controls.Add(this.picQR);
        this.grpVietQR.Controls.Add(this.lblQRThongTin);
        this.grpVietQR.Controls.Add(this.btnDaNhanTien);
        this.grpVietQR.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpVietQR.Location = new System.Drawing.Point(890, 15);
        this.grpVietQR.Name = "grpVietQR";
        this.grpVietQR.Size = new System.Drawing.Size(330, 630);
        this.grpVietQR.TabIndex = 2;
        this.grpVietQR.TabStop = false;
        this.grpVietQR.Text = "Mã thanh toán VietQR";

        this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.picQR.Location = new System.Drawing.Point(20, 30);
        this.picQR.Name = "picQR";
        this.picQR.Size = new System.Drawing.Size(290, 290);
        this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

        this.lblQRThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblQRThongTin.Location = new System.Drawing.Point(20, 335);
        this.lblQRThongTin.Size = new System.Drawing.Size(290, 180);
        this.lblQRThongTin.Text = "Chưa tạo mã VietQR";

        this.btnDaNhanTien.Text = "✅ ĐÃ NHẬN TIỀN (Lưu HD)";
        this.btnDaNhanTien.BackColor = System.Drawing.Color.LightGreen;
        this.btnDaNhanTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnDaNhanTien.Location = new System.Drawing.Point(20, 560);
        this.btnDaNhanTien.Size = new System.Drawing.Size(290, 45);
        this.btnDaNhanTien.Enabled = false;
        this.btnDaNhanTien.Click += new System.EventHandler(this.btnDaNhanTien_Click);

        // ==========================================
        // TAB 2: THỰC ĐƠN
        // ==========================================
        this.tabThucDon.Controls.Add(this.dgvThucDon);
        this.tabThucDon.Controls.Add(this.grpThucDonFilter);
        this.tabThucDon.Controls.Add(this.grpThucDonInput);
        this.tabThucDon.Location = new System.Drawing.Point(4, 25);
        this.tabThucDon.Name = "tabThucDon";
        this.tabThucDon.Padding = new System.Windows.Forms.Padding(3);
        this.tabThucDon.Size = new System.Drawing.Size(1232, 651);
        this.tabThucDon.Text = "  📋 Quản lý thực đơn (CRUD)  ";
        this.tabThucDon.UseVisualStyleBackColor = true;

        this.grpThucDonInput.Controls.Add(this.lblTenMon);
        this.grpThucDonInput.Controls.Add(this.txtTenMon);
        this.grpThucDonInput.Controls.Add(this.lblDanhMuc);
        this.grpThucDonInput.Controls.Add(this.cboDanhMuc);
        this.grpThucDonInput.Controls.Add(this.lblGiaBan);
        this.grpThucDonInput.Controls.Add(this.numGiaBan);
        this.grpThucDonInput.Controls.Add(this.chkDangBan);
        this.grpThucDonInput.Controls.Add(this.btnThemMon);
        this.grpThucDonInput.Controls.Add(this.btnSuaMon);
        this.grpThucDonInput.Controls.Add(this.btnXoaMon);
        this.grpThucDonInput.Controls.Add(this.btnLamMoiMon);
        this.grpThucDonInput.Location = new System.Drawing.Point(15, 15);
        this.grpThucDonInput.Size = new System.Drawing.Size(400, 360);
        this.grpThucDonInput.Text = "Thông tin món";

        this.lblTenMon.Location = new System.Drawing.Point(15, 30);
        this.lblTenMon.Text = "Tên món (*):";
        this.lblTenMon.Size = new System.Drawing.Size(95, 23);
        this.txtTenMon.Location = new System.Drawing.Point(120, 27);
        this.txtTenMon.Size = new System.Drawing.Size(260, 24);

        this.lblDanhMuc.Location = new System.Drawing.Point(15, 70);
        this.lblDanhMuc.Text = "Danh mục:";
        this.lblDanhMuc.Size = new System.Drawing.Size(95, 23);
        this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboDanhMuc.Location = new System.Drawing.Point(120, 67);
        this.cboDanhMuc.Size = new System.Drawing.Size(260, 24);

        this.lblGiaBan.Location = new System.Drawing.Point(15, 110);
        this.lblGiaBan.Text = "Giá bán (đ):";
        this.lblGiaBan.Size = new System.Drawing.Size(95, 23);
        this.numGiaBan.Location = new System.Drawing.Point(120, 107);
        this.numGiaBan.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
        this.numGiaBan.Increment = 1000M;
        this.numGiaBan.ThousandsSeparator = true;
        this.numGiaBan.Size = new System.Drawing.Size(260, 24);

        this.chkDangBan.Location = new System.Drawing.Point(120, 145);
        this.chkDangBan.Text = "Đang bán";
        this.chkDangBan.Checked = true;
        this.chkDangBan.Size = new System.Drawing.Size(150, 24);

        this.btnThemMon.Text = "Thêm";
        this.btnThemMon.Location = new System.Drawing.Point(15, 200);
        this.btnThemMon.Size = new System.Drawing.Size(85, 35);
        this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);

        this.btnSuaMon.Text = "Sửa";
        this.btnSuaMon.Location = new System.Drawing.Point(110, 200);
        this.btnSuaMon.Size = new System.Drawing.Size(85, 35);
        this.btnSuaMon.Click += new System.EventHandler(this.btnSuaMon_Click);

        this.btnXoaMon.Text = "Xóa";
        this.btnXoaMon.Location = new System.Drawing.Point(205, 200);
        this.btnXoaMon.Size = new System.Drawing.Size(85, 35);
        this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click);

        this.btnLamMoiMon.Text = "Làm mới";
        this.btnLamMoiMon.Location = new System.Drawing.Point(300, 200);
        this.btnLamMoiMon.Size = new System.Drawing.Size(85, 35);
        this.btnLamMoiMon.Click += new System.EventHandler(this.btnLamMoiMon_Click);

        this.grpThucDonFilter.Controls.Add(this.lblTimTenMon);
        this.grpThucDonFilter.Controls.Add(this.txtTimTenMon);
        this.grpThucDonFilter.Controls.Add(this.lblLocDanhMuc);
        this.grpThucDonFilter.Controls.Add(this.cboLocDanhMuc);
        this.grpThucDonFilter.Controls.Add(this.btnBoLocMon);
        this.grpThucDonFilter.Location = new System.Drawing.Point(430, 15);
        this.grpThucDonFilter.Size = new System.Drawing.Size(785, 80);
        this.grpThucDonFilter.Text = "Tìm kiếm & Lọc thực đơn";

        this.lblTimTenMon.Location = new System.Drawing.Point(15, 30);
        this.lblTimTenMon.Text = "Tên món:";
        this.lblTimTenMon.Size = new System.Drawing.Size(70, 20);
        this.txtTimTenMon.Location = new System.Drawing.Point(90, 27);
        this.txtTimTenMon.Size = new System.Drawing.Size(200, 24);
        this.txtTimTenMon.TextChanged += new System.EventHandler(this.ThucDonFilterChanged);

        this.lblLocDanhMuc.Location = new System.Drawing.Point(310, 30);
        this.lblLocDanhMuc.Text = "Danh mục:";
        this.lblLocDanhMuc.Size = new System.Drawing.Size(75, 20);
        this.cboLocDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboLocDanhMuc.Location = new System.Drawing.Point(390, 27);
        this.cboLocDanhMuc.Size = new System.Drawing.Size(200, 24);
        this.cboLocDanhMuc.SelectedIndexChanged += new System.EventHandler(this.ThucDonFilterChanged);

        this.btnBoLocMon.Text = "Bỏ lọc";
        this.btnBoLocMon.Location = new System.Drawing.Point(620, 22);
        this.btnBoLocMon.Size = new System.Drawing.Size(90, 35);
        this.btnBoLocMon.Click += new System.EventHandler(this.btnBoLocMon_Click);

        this.dgvThucDon.AllowUserToAddRows = false;
        this.dgvThucDon.AllowUserToDeleteRows = false;
        this.dgvThucDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvThucDon.BackgroundColor = System.Drawing.Color.White;
        this.dgvThucDon.Location = new System.Drawing.Point(430, 105);
        this.dgvThucDon.MultiSelect = false;
        this.dgvThucDon.Name = "dgvThucDon";
        this.dgvThucDon.ReadOnly = true;
        this.dgvThucDon.RowHeadersVisible = false;
        this.dgvThucDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvThucDon.Size = new System.Drawing.Size(785, 520);
        this.dgvThucDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThucDon_CellClick);

        // ==========================================
        // TAB 3: HÓA ĐƠN & DOANH THU
        // ==========================================
        this.tabHoaDon.Controls.Add(this.lblNgayHoaDon);
        this.tabHoaDon.Controls.Add(this.dtpNgayHoaDon);
        this.tabHoaDon.Controls.Add(this.lblDoanhThuNgay);
        this.tabHoaDon.Controls.Add(this.lblDanhSachHD);
        this.tabHoaDon.Controls.Add(this.dgvHoaDon);
        this.tabHoaDon.Controls.Add(this.lblChiTietHD);
        this.tabHoaDon.Controls.Add(this.dgvChiTietHoaDon);
        this.tabHoaDon.Location = new System.Drawing.Point(4, 25);
        this.tabHoaDon.Name = "tabHoaDon";
        this.tabHoaDon.Padding = new System.Windows.Forms.Padding(3);
        this.tabHoaDon.Size = new System.Drawing.Size(1232, 651);
        this.tabHoaDon.Text = "  🧾 Danh sách hóa đơn & Doanh thu  ";
        this.tabHoaDon.UseVisualStyleBackColor = true;

        this.lblNgayHoaDon.Location = new System.Drawing.Point(20, 20);
        this.lblNgayHoaDon.Text = "Chọn ngày xem:";
        this.lblNgayHoaDon.Size = new System.Drawing.Size(110, 23);

        this.dtpNgayHoaDon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpNgayHoaDon.Location = new System.Drawing.Point(140, 17);
        this.dtpNgayHoaDon.Size = new System.Drawing.Size(150, 24);
        this.dtpNgayHoaDon.ValueChanged += new System.EventHandler(this.dtpNgayHoaDon_ValueChanged);

        this.lblDoanhThuNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblDoanhThuNgay.ForeColor = System.Drawing.Color.DarkBlue;
        this.lblDoanhThuNgay.Location = new System.Drawing.Point(340, 15);
        this.lblDoanhThuNgay.Size = new System.Drawing.Size(400, 28);
        this.lblDoanhThuNgay.Text = "Doanh thu ngày: 0 đ";

        this.lblDanhSachHD.Location = new System.Drawing.Point(20, 60);
        this.lblDanhSachHD.Text = "Danh sách hóa đơn trong ngày:";
        this.lblDanhSachHD.Size = new System.Drawing.Size(250, 20);

        this.dgvHoaDon.AllowUserToAddRows = false;
        this.dgvHoaDon.AllowUserToDeleteRows = false;
        this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
        this.dgvHoaDon.Location = new System.Drawing.Point(20, 85);
        this.dgvHoaDon.MultiSelect = false;
        this.dgvHoaDon.Name = "dgvHoaDon";
        this.dgvHoaDon.ReadOnly = true;
        this.dgvHoaDon.RowHeadersVisible = false;
        this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvHoaDon.Size = new System.Drawing.Size(650, 530);
        this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick);

        this.lblChiTietHD.Location = new System.Drawing.Point(700, 60);
        this.lblChiTietHD.Text = "Chi tiết các món của hóa đơn:";
        this.lblChiTietHD.Size = new System.Drawing.Size(250, 20);

        this.dgvChiTietHoaDon.AllowUserToAddRows = false;
        this.dgvChiTietHoaDon.AllowUserToDeleteRows = false;
        this.dgvChiTietHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvChiTietHoaDon.BackgroundColor = System.Drawing.Color.White;
        this.dgvChiTietHoaDon.Location = new System.Drawing.Point(700, 85);
        this.dgvChiTietHoaDon.MultiSelect = false;
        this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
        this.dgvChiTietHoaDon.ReadOnly = true;
        this.dgvChiTietHoaDon.RowHeadersVisible = false;
        this.dgvChiTietHoaDon.Size = new System.Drawing.Size(510, 530);

        // 
        // FormMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1240, 680);
        this.Controls.Add(this.tabControlMain);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "FormMain";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Quản lý quán trà sữa - Tích hợp thanh toán VietQR";
        this.Load += new System.EventHandler(this.FormMain_Load);

        this.tabControlMain.ResumeLayout(false);
        this.tabThucDon.ResumeLayout(false);
        this.tabBanHang.ResumeLayout(false);
        this.tabHoaDon.ResumeLayout(false);
        this.grpThucDonInput.ResumeLayout(false);
        this.grpThucDonInput.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numGiaBan)).EndInit();
        this.grpThucDonFilter.ResumeLayout(false);
        this.grpThucDonFilter.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvMenuBanHang)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numSoLy)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
        this.grpVietQR.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.TabControl tabControlMain;
    private System.Windows.Forms.TabPage tabBanHang;
    private System.Windows.Forms.TabPage tabThucDon;
    private System.Windows.Forms.TabPage tabHoaDon;

    // Controls tabThucDon
    private System.Windows.Forms.GroupBox grpThucDonInput;
    private System.Windows.Forms.Label lblTenMon;
    private System.Windows.Forms.TextBox txtTenMon;
    private System.Windows.Forms.Label lblDanhMuc;
    private System.Windows.Forms.ComboBox cboDanhMuc;
    private System.Windows.Forms.Label lblGiaBan;
    private System.Windows.Forms.NumericUpDown numGiaBan;
    private System.Windows.Forms.CheckBox chkDangBan;
    private System.Windows.Forms.Button btnThemMon;
    private System.Windows.Forms.Button btnSuaMon;
    private System.Windows.Forms.Button btnXoaMon;
    private System.Windows.Forms.Button btnLamMoiMon;
    private System.Windows.Forms.GroupBox grpThucDonFilter;
    private System.Windows.Forms.Label lblTimTenMon;
    private System.Windows.Forms.TextBox txtTimTenMon;
    private System.Windows.Forms.Label lblLocDanhMuc;
    private System.Windows.Forms.ComboBox cboLocDanhMuc;
    private System.Windows.Forms.Button btnBoLocMon;
    private System.Windows.Forms.DataGridView dgvThucDon;

    // Controls tabBanHang
    private System.Windows.Forms.Label lblBanHangDanhMuc;
    private System.Windows.Forms.ComboBox cboBanHangDanhMuc;
    private System.Windows.Forms.Label lblDanhSachMon;
    private System.Windows.Forms.DataGridView dgvMenuBanHang;
    private System.Windows.Forms.Label lblSoLy;
    private System.Windows.Forms.NumericUpDown numSoLy;
    private System.Windows.Forms.Button btnThemVaoDon;
    private System.Windows.Forms.Label lblGioHang;
    private System.Windows.Forms.DataGridView dgvGioHang;
    private System.Windows.Forms.Button btnXoaDongGioHang;
    private System.Windows.Forms.Label lblTongTienDon;
    private System.Windows.Forms.Button btnThanhToanChuyenKhoan;
    private System.Windows.Forms.Button btnThanhToanTienMat;
    private System.Windows.Forms.GroupBox grpVietQR;
    private System.Windows.Forms.PictureBox picQR;
    private System.Windows.Forms.Label lblQRThongTin;
    private System.Windows.Forms.Button btnDaNhanTien;

    // Controls tabHoaDon
    private System.Windows.Forms.Label lblNgayHoaDon;
    private System.Windows.Forms.DateTimePicker dtpNgayHoaDon;
    private System.Windows.Forms.Label lblDoanhThuNgay;
    private System.Windows.Forms.Label lblDanhSachHD;
    private System.Windows.Forms.DataGridView dgvHoaDon;
    private System.Windows.Forms.Label lblChiTietHD;
    private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
}
