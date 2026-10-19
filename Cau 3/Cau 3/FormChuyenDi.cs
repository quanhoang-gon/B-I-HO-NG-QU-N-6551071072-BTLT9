using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
    public partial class FormChuyenDi : Form
    {
        private int? _selectedMaChuyen = null;
        private bool _isLoading = false;
        private bool _isSwitchingLanguage = false;

        public class ChuyenDiViewItem
        {
            public int MaChuyen { get; set; }
            public string TenChuyen { get; set; } = string.Empty;
            public string DiaDiem { get; set; } = string.Empty;
            public DateOnly NgayDi { get; set; }
            public string NgayDiFormat => Strings.CurrentCulture == "en-US"
                ? NgayDi.ToString("MM/dd/yyyy", Strings.CurrentCultureInfo)
                : NgayDi.ToString("dd/MM/yyyy", Strings.CurrentCultureInfo);
            public int SoNguoi { get; set; }
            public decimal NganSach { get; set; }
            public string NganSachFormat => Strings.CurrentCulture == "en-US"
                ? (NganSach / 25000m).ToString("C0", Strings.CurrentCultureInfo)
                : NganSach.ToString("N0", Strings.CurrentCultureInfo) + " đ";
            public string PhuongTien { get; set; } = string.Empty;
            public string PhuongTienLocal => MapVehicleToLocal(PhuongTien);
            public bool DaHoanThanh { get; set; }
            public string? GhiChu { get; set; }

            private static string MapVehicleToLocal(string phuongTien)
            {
                return phuongTien switch
                {
                    "Xe máy" => Strings.Get("VehicleMotorbike"),
                    "Ô tô" => Strings.Get("VehicleCar"),
                    "Xe khách" => Strings.Get("VehicleCoach"),
                    "Tàu hỏa" => Strings.Get("VehicleTrain"),
                    _ => phuongTien
                };
            }
        }

        public FormChuyenDi()
        {
            InitializeComponent();
        }

        private async void FormChuyenDi_Load(object sender, EventArgs e)
        {
            try
            {
                // Nạp cấu hình ngôn ngữ từ usersettings.json
                var userSettings = UserSettings.Load();
                string savedCulture = userSettings.Culture ?? "vi-VN";
                Strings.SetCulture(savedCulture);

                _isSwitchingLanguage = true;
                if (savedCulture == "en-US")
                    rdoEnglish.Checked = true;
                else
                    rdoVietnamese.Checked = true;
                _isSwitchingLanguage = false;

                dtpNgayDi.Value = DateTime.Today.AddDays(1);
                dtpTuNgay.Value = DateTime.Today;
                dtpDenNgay.Value = DateTime.Today.AddMonths(1);

                ApplyLanguage();

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi khởi động FormChuyenDi");
                MessageBox.Show("Có lỗi xảy ra khi khởi động: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Áp dụng đa ngôn ngữ tức thời lên toàn bộ giao diện (Mục 9.4)
        /// </summary>
        private void ApplyLanguage()
        {
            Text = $"{Strings.Get("AppTitle")} - QL_DaNgoai";
            lblTitle.Text = Strings.Get("AppTitle").ToUpper();
            lblSubTitle.Text = Strings.Get("SubTitle");
            lblLanguage.Text = Strings.Get("Language");
            rdoVietnamese.Text = Strings.Get("Vietnamese");
            rdoEnglish.Text = Strings.Get("English");

            grpThongTin.Text = Strings.Get("TripInfoGroup");
            lblTenChuyen.Text = Strings.Get("TripName");
            lblDiaDiem.Text = Strings.Get("Location");
            lblNgayDi.Text = Strings.Get("DepartDate");
            lblSoNguoi.Text = Strings.Get("PeopleCount");
            lblNganSach.Text = Strings.Get("Budget");
            lblPhuongTien.Text = Strings.Get("Vehicle");
            chkDaHoanThanh.Text = Strings.Get("Completed");
            lblGhiChu.Text = Strings.Get("Note");

            btnThem.Text = Strings.Get("BtnAdd");
            btnSua.Text = Strings.Get("BtnEdit");
            btnXoa.Text = Strings.Get("BtnDelete");
            btnLamMoi.Text = Strings.Get("BtnReset");

            grpBoLoc.Text = Strings.Get("FilterGroup");
            lblTimKiem.Text = Strings.CurrentCulture == "en-US" ? "Search:" : "Tìm kiếm:";
            txtTimKiem.PlaceholderText = Strings.Get("SearchPlaceholder");
            chkChuaHoanThanh.Text = Strings.Get("OnlyIncomplete");
            chkLocTheoNgay.Text = Strings.Get("FilterByDate");
            lblDenNgay.Text = Strings.Get("To");
            btnBoLoc.Text = Strings.Get("BtnClearFilter");

            grpWeather.Text = Strings.Get("WeatherGroup");
            btnXemThoiTiet.Text = Strings.Get("BtnCheckWeather");
            lblWeatherStatus.Text = Strings.Get("WeatherReady");
            lblRainWarning.Text = Strings.Get("RainWarning");

            grpDanhSach.Text = Strings.Get("TripListGroup");
            colMaChuyen.HeaderText = Strings.Get("ColID");
            colTenChuyen.HeaderText = Strings.Get("ColTripName");
            colDiaDiem.HeaderText = Strings.Get("ColLocation");
            colNgayDi.HeaderText = Strings.Get("ColDepartDate");
            colSoNguoi.HeaderText = Strings.Get("ColPeople");
            colNganSach.HeaderText = Strings.Get("ColBudget");
            colPhuongTien.HeaderText = Strings.Get("ColVehicle");
            colDaHoanThanh.HeaderText = Strings.Get("ColStatus");
            colGhiChu.HeaderText = Strings.Get("ColNote");

            // Cập nhật các lựa chọn phương tiện
            int oldIndex = cboPhuongTien.SelectedIndex;
            cboPhuongTien.Items.Clear();
            cboPhuongTien.Items.Add(Strings.Get("VehicleMotorbike"));
            cboPhuongTien.Items.Add(Strings.Get("VehicleCar"));
            cboPhuongTien.Items.Add(Strings.Get("VehicleCoach"));
            cboPhuongTien.Items.Add(Strings.Get("VehicleTrain"));
            cboPhuongTien.SelectedIndex = (oldIndex >= 0 && oldIndex < cboPhuongTien.Items.Count) ? oldIndex : 0;

            // Định dạng ngày theo ngôn ngữ
            dtpNgayDi.CustomFormat = Strings.CurrentCulture == "en-US" ? "MM/dd/yyyy" : "dd/MM/yyyy";
            dtpTuNgay.CustomFormat = Strings.CurrentCulture == "en-US" ? "MM/dd/yyyy" : "dd/MM/yyyy";
            dtpDenNgay.CustomFormat = Strings.CurrentCulture == "en-US" ? "MM/dd/yyyy" : "dd/MM/yyyy";
        }

        private async void RdoLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (_isSwitchingLanguage) return;

            string newCulture = rdoEnglish.Checked ? "en-US" : "vi-VN";
            if (newCulture != Strings.CurrentCulture)
            {
                Strings.SetCulture(newCulture);

                // Lưu vào usersettings.json trong %LocalAppData%
                var userSettings = new UserSettings { Culture = newCulture };
                userSettings.Save();

                ApplyLanguage();
                await LoadDataAsync();
            }
        }

        /// <summary>
        /// Nạp và lọc danh sách chuyến đi từ CSDL
        /// </summary>
        private async Task LoadDataAsync()
        {
            try
            {
                _isLoading = true;
                lblTrangThai.Text = Strings.CurrentCulture == "en-US" ? "Loading trips..." : "Đang tải danh sách chuyến đi...";

                string tuKhoa = txtTimKiem.Text.Trim();
                bool chiChuaHoanThanh = chkChuaHoanThanh.Checked;
                bool locTheoNgay = chkLocTheoNgay.Checked;
                DateOnly tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
                DateOnly denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);

                using var context = DbContextHelper.GetContext();

                IQueryable<ChuyenDi> query = context.ChuyenDis.AsNoTracking();

                // Lọc theo tên chuyến hoặc địa điểm
                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(c => c.TenChuyen.Contains(tuKhoa) || c.DiaDiem.Contains(tuKhoa));
                }

                // Lọc chỉ chuyến chưa hoàn thành
                if (chiChuaHoanThanh)
                {
                    query = query.Where(c => !c.DaHoanThanh);
                }

                // Lọc theo khoảng ngày đi
                if (locTheoNgay)
                {
                    query = query.Where(c => c.NgayDi >= tuNgay && c.NgayDi <= denNgay);
                }

                var rawList = await query
                    .OrderBy(c => c.NgayDi)
                    .ThenBy(c => c.MaChuyen)
                    .ToListAsync();

                var viewList = rawList.Select(c => new ChuyenDiViewItem
                {
                    MaChuyen = c.MaChuyen,
                    TenChuyen = c.TenChuyen,
                    DiaDiem = c.DiaDiem,
                    NgayDi = c.NgayDi,
                    SoNguoi = c.SoNguoi,
                    NganSach = c.NganSach,
                    PhuongTien = c.PhuongTien,
                    DaHoanThanh = c.DaHoanThanh,
                    GhiChu = c.GhiChu
                }).ToList();

                dgvChuyenDi.DataSource = viewList;

                decimal tongNganSach = viewList.Sum(c => c.NganSach);
                string tongTienStr = Strings.CurrentCulture == "en-US"
                    ? (tongNganSach / 25000m).ToString("C0", Strings.CurrentCultureInfo)
                    : tongNganSach.ToString("N0", Strings.CurrentCultureInfo) + " đ";

                lblTongKet.Text = Strings.Format("SummaryLabel", viewList.Count, tongTienStr);
                lblTrangThai.Text = Strings.CurrentCulture == "en-US"
                    ? $"Showing {viewList.Count} trips."
                    : $"Hiển thị {viewList.Count} chuyến đi.";

                ClearForm();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi truy vấn danh sách chuyến đi từ CSDL");
                MessageBox.Show(Strings.Get("NetworkError"), "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void ClearForm()
        {
            _selectedMaChuyen = null;
            txtMaChuyen.Clear();
            txtTenChuyen.Clear();
            txtDiaDiem.Clear();
            dtpNgayDi.Value = DateTime.Today.AddDays(1);
            nudSoNguoi.Value = 1;
            nudNganSach.Value = 0;
            if (cboPhuongTien.Items.Count > 0)
                cboPhuongTien.SelectedIndex = 0;
            chkDaHoanThanh.Checked = false;
            txtGhiChu.Clear();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvChuyenDi.ClearSelection();
            txtTenChuyen.Focus();

            ResetWeatherPanel();
        }

        private void ResetWeatherPanel()
        {
            lblWeatherIcon.Text = "⛅";
            lblWeatherDesc.Text = Strings.Get("WeatherReady");
            lblTemp.Text = $"{Strings.Get("WeatherTempRange")} -";
            lblRainProb.Text = $"{Strings.Get("WeatherRainProb")} -";
            pnlRainWarning.Visible = false;
            grpWeather.BackColor = Color.FromArgb(245, 250, 252);
            lblWeatherStatus.Text = Strings.Get("WeatherReady");
        }

        private bool ValidateInput(bool isCreatingNew)
        {
            if (string.IsNullOrWhiteSpace(txtTenChuyen.Text))
            {
                MessageBox.Show(Strings.Get("MsgTripNameEmpty"), "Validation Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenChuyen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaDiem.Text))
            {
                MessageBox.Show(Strings.Get("MsgLocationEmpty"), "Validation Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaDiem.Focus();
                return false;
            }

            // Khi thêm mới: Ngày đi không được nhỏ hơn hôm nay
            if (isCreatingNew && dtpNgayDi.Value.Date < DateTime.Today)
            {
                MessageBox.Show(Strings.Get("MsgDepartDatePast"), "Validation Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayDi.Focus();
                return false;
            }

            if (nudSoNguoi.Value < 1)
            {
                MessageBox.Show(Strings.Get("MsgPeopleMin"), "Validation Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudSoNguoi.Focus();
                return false;
            }

            if (nudNganSach.Value < 0)
            {
                MessageBox.Show(Strings.Get("MsgBudgetMin"), "Validation Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudNganSach.Focus();
                return false;
            }

            return true;
        }

        private string GetStandardVehicleString()
        {
            int index = cboPhuongTien.SelectedIndex;
            return index switch
            {
                0 => "Xe máy",
                1 => "Ô tô",
                2 => "Xe khách",
                3 => "Tàu hỏa",
                _ => "Xe khách"
            };
        }

        private void SetVehicleDropdown(string standardVehicle)
        {
            int index = standardVehicle switch
            {
                "Xe máy" => 0,
                "Ô tô" => 1,
                "Xe khách" => 2,
                "Tàu hỏa" => 3,
                _ => 0
            };
            if (index >= 0 && index < cboPhuongTien.Items.Count)
                cboPhuongTien.SelectedIndex = index;
        }

        private async void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(isCreatingNew: true)) return;

            try
            {
                var cd = new ChuyenDi
                {
                    TenChuyen = txtTenChuyen.Text.Trim(),
                    DiaDiem = txtDiaDiem.Text.Trim(),
                    NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date),
                    SoNguoi = (int)nudSoNguoi.Value,
                    NganSach = nudNganSach.Value,
                    PhuongTien = GetStandardVehicleString(),
                    DaHoanThanh = chkDaHoanThanh.Checked,
                    GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
                };

                using (var context = DbContextHelper.GetContext())
                {
                    context.ChuyenDis.Add(cd);
                    await context.SaveChangesAsync();
                }

                Log.Information("Thêm chuyến đi thành công: MaChuyen={MaChuyen}, TenChuyen='{TenChuyen}', DiaDiem='{DiaDiem}'",
                    cd.MaChuyen, cd.TenChuyen, cd.DiaDiem);

                MessageBox.Show(Strings.Get("MsgAddSuccess"), "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi thêm chuyến đi vào CSDL");
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaChuyen == null)
            {
                MessageBox.Show(Strings.Get("MsgPleaseSelectRow"), "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(isCreatingNew: false)) return;

            try
            {
                using (var context = DbContextHelper.GetContext())
                {
                    var cd = await context.ChuyenDis.FirstOrDefaultAsync(x => x.MaChuyen == _selectedMaChuyen.Value);
                    if (cd == null)
                    {
                        MessageBox.Show("Chuyến đi không còn tồn tại!", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        await LoadDataAsync();
                        return;
                    }

                    cd.TenChuyen = txtTenChuyen.Text.Trim();
                    cd.DiaDiem = txtDiaDiem.Text.Trim();
                    cd.NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date);
                    cd.SoNguoi = (int)nudSoNguoi.Value;
                    cd.NganSach = nudNganSach.Value;
                    cd.PhuongTien = GetStandardVehicleString();
                    cd.DaHoanThanh = chkDaHoanThanh.Checked;
                    cd.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

                    await context.SaveChangesAsync();
                }

                Log.Information("Cập nhật chuyến đi thành công: MaChuyen={MaChuyen}", _selectedMaChuyen.Value);

                MessageBox.Show(Strings.Get("MsgEditSuccess"), "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi cập nhật chuyến đi MaChuyen={MaChuyen}", _selectedMaChuyen);
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaChuyen == null)
            {
                MessageBox.Show(Strings.Get("MsgPleaseSelectRow"), "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string confirmMsg = Strings.Format("MsgConfirmDelete", _selectedMaChuyen.Value, txtTenChuyen.Text);
            var confirm = MessageBox.Show(confirmMsg, "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var context = DbContextHelper.GetContext())
                {
                    var cd = await context.ChuyenDis.FirstOrDefaultAsync(x => x.MaChuyen == _selectedMaChuyen.Value);
                    if (cd != null)
                    {
                        context.ChuyenDis.Remove(cd);
                        await context.SaveChangesAsync();
                    }
                }

                Log.Information("Xóa chuyến đi thành công: MaChuyen={MaChuyen}", _selectedMaChuyen.Value);

                MessageBox.Show(Strings.Get("MsgDeleteSuccess"), "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa chuyến đi MaChuyen={MaChuyen}", _selectedMaChuyen);
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblTrangThai.Text = Strings.CurrentCulture == "en-US" ? "Form reset." : "Đã làm mới form nhập liệu.";
        }

        private void DgvChuyenDi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            PopulateSelectedRow();
        }

        private void DgvChuyenDi_SelectionChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            PopulateSelectedRow();
        }

        private void PopulateSelectedRow()
        {
            if (dgvChuyenDi.CurrentRow == null || dgvChuyenDi.CurrentRow.DataBoundItem is not ChuyenDiViewItem item)
            {
                return;
            }

            _selectedMaChuyen = item.MaChuyen;
            txtMaChuyen.Text = item.MaChuyen.ToString();
            txtTenChuyen.Text = item.TenChuyen;
            txtDiaDiem.Text = item.DiaDiem;

            DateTime ngayDiDt = item.NgayDi.ToDateTime(TimeOnly.MinValue);
            dtpNgayDi.Value = ngayDiDt;

            nudSoNguoi.Value = Math.Max(1, item.SoNguoi);
            nudNganSach.Value = item.NganSach;
            SetVehicleDropdown(item.PhuongTien);
            chkDaHoanThanh.Checked = item.DaHoanThanh;
            txtGhiChu.Text = item.GhiChu ?? string.Empty;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            lblTrangThai.Text = Strings.CurrentCulture == "en-US"
                ? $"Selected trip: {item.TenChuyen} ({item.DiaDiem})"
                : $"Đang chọn chuyến: {item.TenChuyen} ({item.DiaDiem})";

            // Tự động tra cứu thời tiết nhanh khi chọn dòng
            _ = CheckWeatherAsync(item.DiaDiem, item.NgayDi);
        }

        /// <summary>
        /// Nút "Xem thời tiết": Gọi API Open-Meteo và hiển thị kết quả
        /// </summary>
        private async void BtnXemThoiTiet_Click(object sender, EventArgs e)
        {
            string diaDiem = txtDiaDiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(diaDiem))
            {
                MessageBox.Show(Strings.Get("MsgLocationEmpty"), "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaDiem.Focus();
                return;
            }

            DateOnly ngayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date);
            await CheckWeatherAsync(diaDiem, ngayDi);
        }

        private async Task CheckWeatherAsync(string diaDiem, DateOnly ngayDi)
        {
            try
            {
                btnXemThoiTiet.Enabled = false;
                prgLoading.Visible = true;
                lblWeatherStatus.Text = Strings.Get("WeatherLoading");

                var weather = await WeatherForecastService.GetWeatherForDateAsync(diaDiem, ngayDi);

                prgLoading.Visible = false;
                btnXemThoiTiet.Enabled = true;

                if (weather.Success)
                {
                    lblWeatherIcon.Text = weather.WeatherIcon;
                    lblWeatherDesc.Text = Strings.Get(weather.WeatherDescriptionKey);
                    lblTemp.Text = $"{Strings.Get("WeatherTempRange")} {weather.TempMin:F1}°C – {weather.TempMax:F1}°C";
                    lblRainProb.Text = $"{Strings.Get("WeatherRainProb")} {weather.RainProbability}%";

                    lblWeatherStatus.Text = $"{weather.LocationName} ({weather.Date:dd/MM/yyyy})";

                    // Nếu xác suất mưa >= 60% thì tô nền cam và hiện cảnh báo
                    if (weather.IsHighRainRisk)
                    {
                        pnlRainWarning.Visible = true;
                        grpWeather.BackColor = Color.FromArgb(255, 235, 215);
                    }
                    else
                    {
                        pnlRainWarning.Visible = false;
                        grpWeather.BackColor = Color.FromArgb(245, 250, 252);
                    }
                }
                else
                {
                    lblWeatherIcon.Text = "❓";
                    lblWeatherDesc.Text = weather.ErrorMessage ?? Strings.Get("NetworkError");
                    lblTemp.Text = $"{Strings.Get("WeatherTempRange")} -";
                    lblRainProb.Text = $"{Strings.Get("WeatherRainProb")} -";
                    pnlRainWarning.Visible = false;
                    grpWeather.BackColor = Color.FromArgb(245, 250, 252);
                    lblWeatherStatus.Text = weather.ErrorMessage ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                prgLoading.Visible = false;
                btnXemThoiTiet.Enabled = true;
                Log.Warning(ex, "Lỗi khi xử lý thời tiết trên FormChuyenDi");
                lblWeatherDesc.Text = Strings.Get("NetworkError");
            }
        }

        // ================== TÌM KIẾM & BỘ LỌC ==================

        private async void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            await LoadDataAsync();
        }

        private async void ChkChuaHoanThanh_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            await LoadDataAsync();
        }

        private async void ChkLocTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtpTuNgay.Enabled = chkLocTheoNgay.Checked;
            dtpDenNgay.Enabled = chkLocTheoNgay.Checked;
            if (_isLoading) return;
            await LoadDataAsync();
        }

        private async void DtpLocNgay_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoading || !chkLocTheoNgay.Checked) return;
            await LoadDataAsync();
        }

        private async void BtnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            chkChuaHoanThanh.Checked = false;
            chkLocTheoNgay.Checked = false;
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today.AddMonths(1);
            await LoadDataAsync();
        }
    }
}
