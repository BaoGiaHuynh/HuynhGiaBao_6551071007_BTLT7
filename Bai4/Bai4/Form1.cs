using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Bai4.Models;

namespace Bai4
{
    public partial class Form1 : Form
    {
        private readonly AnKhangClinicContext _context = new AnKhangClinicContext();
        private int _selectedMaLich = 0;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            // 1. Cấu hình định dạng ngày/giờ
            dtpNgayKham.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Format = DateTimePickerFormat.Short;

            dtpGioKham.Format = DateTimePickerFormat.Custom;
            dtpGioKham.CustomFormat = "HH:mm";
            dtpGioKham.ShowUpDown = true;

            // 2. Nạp dữ liệu ComboBox Trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[] { "Chờ khám", "Đã khám", "Đã hủy" });
            cboTrangThai.SelectedIndex = 0;

            // 3. Nạp danh sách Bác sĩ
            await LoadBacSiComboBoxAsync();

            // 4. Đặt ngày lọc tìm kiếm mặc định
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today.AddDays(30);

            // 5. Tải danh sách lịch khám
            await LoadDataAsync();
        }

        private async Task LoadBacSiComboBoxAsync()
        {
            var dsBacSi = await _context.BacSis.ToListAsync();

            var dsHienThi = dsBacSi.Select(b => new
            {
                b.MaBs,
                TenHienThi = $"BS. {b.HoTen} - {b.ChuyenKhoa}"
            }).ToList();

            cboBacSi.DataSource = dsHienThi;
            cboBacSi.DisplayMember = "TenHienThi";
            cboBacSi.ValueMember = "MaBs";

            var dsTim = dsHienThi.ToList();
            dsTim.Insert(0, new { MaBs = 0, TenHienThi = "-- Tất cả Bác sĩ --" });
            cboTimBacSi.DataSource = dsTim;
            cboTimBacSi.DisplayMember = "TenHienThi";
            cboTimBacSi.ValueMember = "MaBs";
        }

        private async Task LoadDataAsync()
        {
            var list = await _context.LichKhams
                .Include(l => l.MaBsNavigation)
                .ToListAsync();

            BindGrid(list);
        }

        private void BindGrid(System.Collections.Generic.List<LichKham> list)
        {
            var displayList = list.Select(l => new
            {
                MaLich = l.MaLich,
                TenBenhNhan = l.TenBenhNhan,
                SDT = l.Sdt,
                NgayKham = l.NgayKham.HasValue ? l.NgayKham.Value.ToString("dd/MM/yyyy") : "",
                GioKham = l.GioKham,
                BacSi = l.MaBsNavigation != null ? $"BS. {l.MaBsNavigation.HoTen}" : "",
                ChuyenKhoa = l.MaBsNavigation?.ChuyenKhoa,
                TrangThai = l.TrangThai,
                MaBS = l.MaBs
            }).ToList();

            dgvLichKham.DataSource = displayList;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenBenhNhan.Text))
            {
                MessageBox.Show("Tên bệnh nhân không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenBenhNhan.Focus();
                return false;
            }

            if (cboBacSi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Bác sĩ phụ trách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpNgayKham.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Không thể đặt lịch khám vào ngày trong quá khứ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayKham.Focus();
                return false;
            }

            return true;
        }

        private void dgvLichKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLichKham.Rows[e.RowIndex].Cells["MaLich"].Value != null)
            {
                DataGridViewRow row = dgvLichKham.Rows[e.RowIndex];
                _selectedMaLich = Convert.ToInt32(row.Cells["MaLich"].Value);

                txtTenBenhNhan.Text = row.Cells["TenBenhNhan"].Value?.ToString();
                txtSDT.Text = row.Cells["SDT"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgayKham"].Value?.ToString(), out DateTime ngayKham))
                {
                    dtpNgayKham.Value = ngayKham;
                }

                if (TimeSpan.TryParse(row.Cells["GioKham"].Value?.ToString(), out TimeSpan gioKham))
                {
                    dtpGioKham.Value = DateTime.Today.Add(gioKham);
                }

                if (row.Cells["MaBS"].Value != null)
                {
                    cboBacSi.SelectedValue = Convert.ToInt32(row.Cells["MaBS"].Value);
                }

                cboTrangThai.SelectedItem = row.Cells["TrangThai"].Value?.ToString();
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var lk = new LichKham
            {
                TenBenhNhan = txtTenBenhNhan.Text.Trim(),
                Sdt = txtSDT.Text.Trim(),
                NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value),
                GioKham = dtpGioKham.Value.ToString("HH:mm"),
                MaBs = Convert.ToInt32(cboBacSi.SelectedValue),
                TrangThai = cboTrangThai.SelectedItem?.ToString()
            };

            _context.LichKhams.Add(lk);
            await _context.SaveChangesAsync();

            MessageBox.Show("Đặt lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadDataAsync();
            ResetForm();
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaLich == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch khám cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            var lk = await _context.LichKhams.FindAsync(_selectedMaLich);
            if (lk != null)
            {
                lk.TenBenhNhan = txtTenBenhNhan.Text.Trim();
                lk.Sdt = txtSDT.Text.Trim();
                lk.NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value);
                lk.GioKham = dtpGioKham.Value.ToString("HH:mm");
                lk.MaBs = Convert.ToInt32(cboBacSi.SelectedValue);
                lk.TrangThai = cboTrangThai.SelectedItem?.ToString();

                await _context.SaveChangesAsync();

                MessageBox.Show("Cập nhật lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ResetForm();
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaLich == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch khám cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa lịch khám này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var lk = await _context.LichKhams.FindAsync(_selectedMaLich);
                if (lk != null)
                {
                    _context.LichKhams.Remove(lk);
                    await _context.SaveChangesAsync();

                    MessageBox.Show("Xóa lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ResetForm();
                }
            }
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            var tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
            var denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);
            int maBsTim = cboTimBacSi.SelectedValue != null ? Convert.ToInt32(cboTimBacSi.SelectedValue) : 0;

            var query = _context.LichKhams.Include(l => l.MaBsNavigation).AsQueryable();

            query = query.Where(l => l.NgayKham >= tuNgay && l.NgayKham <= denNgay);

            if (maBsTim > 0)
            {
                query = query.Where(l => l.MaBs == maBsTim);
            }

            var result = await query.ToListAsync();
            BindGrid(result);
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            cboTimBacSi.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today.AddDays(30);
            await LoadDataAsync();
        }

        private void ResetForm()
        {
            _selectedMaLich = 0;
            txtTenBenhNhan.Clear();
            txtSDT.Clear();
            dtpNgayKham.Value = DateTime.Today;
            dtpGioKham.Value = DateTime.Now;
            if (cboBacSi.Items.Count > 0) cboBacSi.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
        }

        private void dgvLichKham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvLichKham_CellClick(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txtSDT_TextChanged(object sender, EventArgs e) { }
        private void dtpNgayKham_ValueChanged(object sender, EventArgs e) { }
        private void dtpGioKham_ValueChanged(object sender, EventArgs e) { }
        private void cboBacSi_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e) { }
        private void dtpDenNgay_ValueChanged(object sender, EventArgs e) { }
        private void cboTimBacSi_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}