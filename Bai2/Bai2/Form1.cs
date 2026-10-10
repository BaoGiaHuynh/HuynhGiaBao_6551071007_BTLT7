using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Bai2.Models;

namespace Bai2
{
    public partial class Form1 : Form
    {
        private readonly FitZoneDbContext _context = new FitZoneDbContext();
        private int _selectedMaHV = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Short;

            cboHangThanhVien.Items.Clear();
            cboHangThanhVien.Items.AddRange(new string[] { "Basic", "VIP", "Premium" });
            cboHangThanhVien.SelectedIndex = 0;

            cboTimHangThanhVien.Items.Clear();
            cboTimHangThanhVien.Items.AddRange(new string[] { "Tất cả", "Basic", "VIP", "Premium" });
            cboTimHangThanhVien.SelectedIndex = 0;

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var list = await _context.HoiViens
                .Select(h => new
                {
                    MaHV = h.MaHv,
                    h.HoTen,
                    GioiTinh = h.GioiTinh == true ? "Nam" : "Nữ",
                    NgaySinh = h.NgaySinh.HasValue ? h.NgaySinh.Value.ToString("dd/MM/yyyy") : "",
                    SDT = h.Sdt,
                    h.Email,
                    h.HangThanhVien,
                    TrangThai = h.TrangThai == true ? "Đang hoạt động" : "Tạm ngưng"
                })
                .ToListAsync();

            dgvHoiVien.DataSource = list;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtSDT.Text.Trim(), @"^\d{9,11}$"))
            {
                MessageBox.Show("Số điện thoại phải là chữ số và có từ 9 đến 11 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email phải chứa ký tự '@'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            int tuoi = DateTime.Now.Year - dtpNgaySinh.Value.Year;
            if (dtpNgaySinh.Value.Date > DateTime.Now.AddYears(-tuoi)) tuoi--;

            if (tuoi < 15)
            {
                MessageBox.Show("Hội viên phải từ 15 tuổi trở lên mới được đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return false;
            }

            return true;
        }

        private void dgvHoiVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHoiVien.Rows[e.RowIndex].Cells["MaHV"].Value != null)
            {
                DataGridViewRow row = dgvHoiVien.Rows[e.RowIndex];
                _selectedMaHV = Convert.ToInt32(row.Cells["MaHV"].Value);

                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();

                string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                if (gioiTinh == "Nam") rdoNam.Checked = true;
                else rdoNu.Checked = true;

                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaySinh))
                {
                    dtpNgaySinh.Value = ngaySinh;
                }

                string hang = row.Cells["HangThanhVien"].Value?.ToString();
                cboHangThanhVien.SelectedItem = hang;

                string trangThai = row.Cells["TrangThai"].Value?.ToString();
                chkTrangThai.Checked = (trangThai == "Đang hoạt động");
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var hv = new HoiVien
            {
                HoTen = txtHoTen.Text.Trim(),
                GioiTinh = rdoNam.Checked,
                NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
                Sdt = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                HangThanhVien = cboHangThanhVien.SelectedItem?.ToString(),
                TrangThai = chkTrangThai.Checked,
                NgayDangKy = DateTime.Now
            };

            _context.HoiViens.Add(hv);
            await _context.SaveChangesAsync();

            MessageBox.Show("Thêm mới hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadDataAsync();
            ResetForm();
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaHV == 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            var hv = await _context.HoiViens.FindAsync(_selectedMaHV);
            if (hv != null)
            {
                hv.HoTen = txtHoTen.Text.Trim();
                hv.GioiTinh = rdoNam.Checked;
                hv.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
                hv.Sdt = txtSDT.Text.Trim();
                hv.Email = txtEmail.Text.Trim();
                hv.HangThanhVien = cboHangThanhVien.SelectedItem?.ToString();
                hv.TrangThai = chkTrangThai.Checked;

                await _context.SaveChangesAsync();

                MessageBox.Show("Cập nhật thông tin hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ResetForm();
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaHV == 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa hội viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                var hv = await _context.HoiViens.FindAsync(_selectedMaHV);
                if (hv != null)
                {
                    _context.HoiViens.Remove(hv);
                    await _context.SaveChangesAsync();

                    MessageBox.Show("Xóa hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ResetForm();
                }
            }
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimHoTen.Text.Trim();
            string hangChon = cboTimHangThanhVien.SelectedItem?.ToString();

            var query = _context.HoiViens.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa) && hangChon != "Tất cả")
            {
                query = query.Where(h => h.HoTen.Contains(tuKhoa) && h.HangThanhVien == hangChon);
            }
            else if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(h => h.HoTen.Contains(tuKhoa));
            }
            else if (hangChon != "Tất cả")
            {
                query = query.Where(h => h.HangThanhVien == hangChon);
            }

            var result = await query
                .Select(h => new
                {
                    MaHV = h.MaHv,
                    h.HoTen,
                    GioiTinh = h.GioiTinh == true ? "Nam" : "Nữ",
                    NgaySinh = h.NgaySinh.HasValue ? h.NgaySinh.Value.ToString("dd/MM/yyyy") : "",
                    SDT = h.Sdt,
                    h.Email,
                    h.HangThanhVien,
                    TrangThai = h.TrangThai == true ? "Đang hoạt động" : "Tạm ngưng"
                })
                .ToListAsync();

            dgvHoiVien.DataSource = result;
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            txtTimHoTen.Clear();
            cboTimHangThanhVien.SelectedIndex = 0;
            await LoadDataAsync();
        }

        private void ResetForm()
        {
            _selectedMaHV = 0;
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            rdoNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
            cboHangThanhVien.SelectedIndex = 0;
            chkTrangThai.Checked = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void txtHoTen_TextChanged(object sender, EventArgs e) { }
        private void txtSDT_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void cboHangThanhVien_SelectedIndexChanged(object sender, EventArgs e) { }
        private void grpGioiTinh_Enter(object sender, EventArgs e) { }
        private void rdoNam_CheckedChanged(object sender, EventArgs e) { }
        private void rdoNu_CheckedChanged(object sender, EventArgs e) { }
        private void cboTimHangThanhVien_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtTimHoTen_TextChanged(object sender, EventArgs e) { }
    }
}