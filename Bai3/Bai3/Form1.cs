using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Bai3.Models;

namespace Bai3
{
    public partial class Form1 : Form
    {
        private readonly SunriseHomestayContext _context = new SunriseHomestayContext();
        private int _selectedMaPhong = 0;
        private string _selectedFileName = "";

        public Form1()
        {
            InitializeComponent();
            // 🟢 Ép Form tự động gọi hàm Load khi chạy ứng dụng
            this.Load += new EventHandler(Form1_Load);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // 1. Tạo thư mục Images nếu chưa có
            string imageFolder = Path.Combine(Application.StartupPath, "Images");
            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }

            // 2. Nạp dữ liệu ComboBox Tình trạng
            cboTinhTrang.Items.Clear();
            cboTinhTrang.Items.AddRange(new string[] { "Trống", "Đang ở", "Đang dọn" });
            cboTinhTrang.SelectedIndex = 0;

            cboTimTinhTrang.Items.Clear();
            cboTimTinhTrang.Items.AddRange(new string[] { "Tất cả", "Trống", "Đang ở", "Đang dọn" });
            cboTimTinhTrang.SelectedIndex = 0;

            // 3. Nạp danh sách Loại phòng
            await LoadLoaiPhongComboBoxAsync();

            // 4. Tải danh sách phòng
            await LoadDataAsync();
        }

        private async Task LoadLoaiPhongComboBoxAsync()
        {
            var dsLoai = await _context.LoaiPhongs.ToListAsync();

            cboLoaiPhong.DataSource = dsLoai;
            cboLoaiPhong.DisplayMember = "TenLoai";
            cboLoaiPhong.ValueMember = "MaLoai";

            var dsTim = dsLoai.ToList();
            dsTim.Insert(0, new LoaiPhong { MaLoai = 0, TenLoai = "Tất cả" });
            cboTimLoaiPhong.DataSource = dsTim;
            cboTimLoaiPhong.DisplayMember = "TenLoai";
            cboTimLoaiPhong.ValueMember = "MaLoai";
        }

        private Image LoadImageFromFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return null;

            string fullPath = Path.Combine(Application.StartupPath, "Images", fileName);
            if (!File.Exists(fullPath)) return null;

            using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            {
                return Image.FromStream(stream);
            }
        }

        private async Task LoadDataAsync()
        {
            var list = await _context.Phongs
                .Include(p => p.MaLoaiNavigation)
                .ToListAsync();

            var displayList = list.Select(p => new
            {
                p.MaPhong,
                HinhAnh = LoadImageFromFile(p.HinhAnh),
                p.SoPhong,
                p.TangSo,
                LoaiPhong = p.MaLoaiNavigation?.TenLoai,
                GiaMoiDem = p.MaLoaiNavigation?.GiaMoiDem,
                p.TinhTrang,
                TenFileAnh = p.HinhAnh,
                p.MaLoai
            }).ToList();

            dgvPhong.DataSource = displayList;

            dgvPhong.RowTemplate.Height = 60;
            if (dgvPhong.Columns["HinhAnh"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.HeaderText = "Ảnh";
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "File ảnh (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string sourceFilePath = ofd.FileName;
                    string fileName = Path.GetFileName(sourceFilePath);
                    string destFilePath = Path.Combine(Application.StartupPath, "Images", fileName);

                    try
                    {
                        File.Copy(sourceFilePath, destFilePath, true);
                    }
                    catch { }

                    _selectedFileName = fileName;
                    picHinhAnh.Image = LoadImageFromFile(fileName);
                }
            }
        }

        private void dgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPhong.Rows[e.RowIndex].Cells["MaPhong"].Value != null)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];
                _selectedMaPhong = Convert.ToInt32(row.Cells["MaPhong"].Value);

                txtSoPhong.Text = row.Cells["SoPhong"].Value?.ToString();
                numTangSo.Value = Convert.ToDecimal(row.Cells["TangSo"].Value ?? 1);
                cboLoaiPhong.SelectedValue = Convert.ToInt32(row.Cells["MaLoai"].Value);
                cboTinhTrang.SelectedItem = row.Cells["TinhTrang"].Value?.ToString();

                _selectedFileName = row.Cells["TenFileAnh"].Value?.ToString() ?? "";
                picHinhAnh.Image = LoadImageFromFile(_selectedFileName);
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Số phòng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.Focus();
                return;
            }

            // 🟢 Kiểm tra an toàn trước khi lấy dữ liệu Loại phòng
            if (cboLoaiPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phong = new Phong
            {
                SoPhong = txtSoPhong.Text.Trim(),
                TangSo = (int)numTangSo.Value,
                MaLoai = (int)cboLoaiPhong.SelectedValue,
                TinhTrang = cboTinhTrang.SelectedItem?.ToString(),
                HinhAnh = _selectedFileName
            };

            _context.Phongs.Add(phong);
            await _context.SaveChangesAsync();

            MessageBox.Show("Thêm phòng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadDataAsync();
            ResetForm();
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Số phòng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboLoaiPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phong = await _context.Phongs.FindAsync(_selectedMaPhong);
            if (phong != null)
            {
                phong.SoPhong = txtSoPhong.Text.Trim();
                phong.TangSo = (int)numTangSo.Value;
                phong.MaLoai = (int)cboLoaiPhong.SelectedValue;
                phong.TinhTrang = cboTinhTrang.SelectedItem?.ToString();
                phong.HinhAnh = _selectedFileName;

                await _context.SaveChangesAsync();

                MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ResetForm();
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var phong = await _context.Phongs.FindAsync(_selectedMaPhong);
                if (phong != null)
                {
                    _context.Phongs.Remove(phong);
                    await _context.SaveChangesAsync();

                    MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ResetForm();
                }
            }
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            int maLoaiTim = cboTimLoaiPhong.SelectedValue != null ? Convert.ToInt32(cboTimLoaiPhong.SelectedValue) : 0;
            string tinhTrangTim = cboTimTinhTrang.SelectedItem?.ToString() ?? "Tất cả";

            var query = _context.Phongs.Include(p => p.MaLoaiNavigation).AsQueryable();

            if (maLoaiTim > 0)
            {
                query = query.Where(p => p.MaLoai == maLoaiTim);
            }

            if (tinhTrangTim != "Tất cả")
            {
                query = query.Where(p => p.TinhTrang == tinhTrangTim);
            }

            var list = await query.ToListAsync();

            var displayList = list.Select(p => new
            {
                p.MaPhong,
                HinhAnh = LoadImageFromFile(p.HinhAnh),
                p.SoPhong,
                p.TangSo,
                LoaiPhong = p.MaLoaiNavigation?.TenLoai,
                GiaMoiDem = p.MaLoaiNavigation?.GiaMoiDem,
                p.TinhTrang,
                TenFileAnh = p.HinhAnh,
                p.MaLoai
            }).ToList();

            dgvPhong.DataSource = displayList;
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            cboTimLoaiPhong.SelectedIndex = 0;
            cboTimTinhTrang.SelectedIndex = 0;
            await LoadDataAsync();
        }

        private void ResetForm()
        {
            _selectedMaPhong = 0;
            _selectedFileName = "";
            txtSoPhong.Clear();
            numTangSo.Value = 1;
            if (cboLoaiPhong.Items.Count > 0) cboLoaiPhong.SelectedIndex = 0;
            if (cboTinhTrang.Items.Count > 0) cboTinhTrang.SelectedIndex = 0;
            picHinhAnh.Image = null;
        }

        private void txtSoPhong_TextChanged(object sender, EventArgs e) { }
        private void cboTinhTrang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numTangSo_ValueChanged(object sender, EventArgs e) { }
        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e) { }
        private void picHinhAnh_Click(object sender, EventArgs e) { }
        private void cboTimTinhTrang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboTimLoaiPhong_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}