using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Bai1.Models;

namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Thêm dòng dưới đây để tự kết nối sự kiện chọn dòng
            dgvTheLoai.SelectionChanged += dgvTheLoai_SelectionChanged;
        }

        // Sự kiện Form Load
        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // Hàm tải dữ liệu từ CSDL
        private async Task LoadDataAsync()
        {
            try
            {
                using var context = new TriThucBooksDbContext();

                var list = await context.TheLoaiSaches
                    .AsNoTracking()
                    .Select(tl => new
                    {
                        MaTl = tl.MaTl,
                        TenTheLoai = tl.TenTheLoai,
                        MoTa = tl.MoTa,
                        SoLuongSach = tl.SoLuongSach ?? 0,
                        NgayTao = tl.NgayTao.HasValue ? tl.NgayTao.Value.ToString("yyyy/MM/dd HH:mm:ss") : ""
                    })
                    .ToListAsync();

                dgvTheLoai.DataSource = list;

                // Đổi tên các cột hiển thị
                if (dgvTheLoai.Columns["MaTl"] != null) dgvTheLoai.Columns["MaTl"].HeaderText = "Mã TL";
                if (dgvTheLoai.Columns["TenTheLoai"] != null) dgvTheLoai.Columns["TenTheLoai"].HeaderText = "Tên thể loại";
                if (dgvTheLoai.Columns["MoTa"] != null) dgvTheLoai.Columns["MoTa"].HeaderText = "Mô tả";
                if (dgvTheLoai.Columns["SoLuongSach"] != null) dgvTheLoai.Columns["SoLuongSach"].HeaderText = "Số lượng sách";
                if (dgvTheLoai.Columns["NgayTao"] != null) dgvTheLoai.Columns["NgayTao"].HeaderText = "Ngày tạo";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đổ dữ liệu dòng chọn lên ô nhập
        private void dgvTheLoai_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTheLoai.CurrentRow != null && dgvTheLoai.CurrentRow.Index >= 0)
            {
                var row = dgvTheLoai.CurrentRow;
                txtMaTL.Text = row.Cells["MaTl"].Value?.ToString();
                txtTenTL.Text = row.Cells["TenTheLoai"].Value?.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();
                lblNgayTaoValue.Text = row.Cells["NgayTao"].Value?.ToString();
            }
        }

        private void ClearInput()
        {
            txtMaTL.Clear();
            txtTenTL.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();
            lblNgayTaoValue.Text = string.Empty;
            dgvTheLoai.ClearSelection();
        }

        // Nút Làm mới
        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            await LoadDataAsync();
        }

        // Nút Thêm mới
        private async void btnThem_Click(object sender, EventArgs e)
        {
            string tenTL = txtTenTL.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            if (string.IsNullOrEmpty(tenTL))
            {
                MessageBox.Show("Vui lòng nhập Tên thể loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTL.Focus();
                return;
            }

            using var context = new TriThucBooksDbContext();

            // Validate: Trùng tên
            bool isExist = await context.TheLoaiSaches
                .AnyAsync(x => x.TenTheLoai.ToLower() == tenTL.ToLower());

            if (isExist)
            {
                MessageBox.Show("Tên thể loại này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newItem = new TheLoaiSach
                {
                    TenTheLoai = tenTL,
                    MoTa = moTa,
                    SoLuongSach = 0,
                    NgayTao = DateTime.Now
                };

                context.TheLoaiSaches.Add(newItem);
                await context.SaveChangesAsync();

                MessageBox.Show("Thêm mới thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Sửa
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show("Vui lòng chọn một thể loại trong danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenTL = txtTenTL.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            if (string.IsNullOrEmpty(tenTL))
            {
                MessageBox.Show("Vui lòng nhập Tên thể loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTL.Focus();
                return;
            }

            using var context = new TriThucBooksDbContext();

            bool isExist = await context.TheLoaiSaches
                .AnyAsync(x => x.MaTl != maTL && x.TenTheLoai.ToLower() == tenTL.ToLower());

            if (isExist)
            {
                MessageBox.Show("Tên thể loại đã trùng với thể loại khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = await context.TheLoaiSaches.FindAsync(maTL);
            if (item == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu cần cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                item.TenTheLoai = tenTL;
                item.MoTa = moTa;

                await context.SaveChangesAsync();

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show("Vui lòng chọn thể loại cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa thể loại có Mã {maTL} không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using var context = new TriThucBooksDbContext();
                    var item = await context.TheLoaiSaches.FindAsync(maTL);
                    if (item != null)
                    {
                        context.TheLoaiSaches.Remove(item);
                        await context.SaveChangesAsync();

                        MessageBox.Show("Xóa thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInput();
                        await LoadDataAsync();
                    }
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show("Không thể xóa thể loại này vì đang được các danh mục sách khác tham chiếu!",
                        "Lỗi ràng buộc CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút Tìm kiếm
        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            using var context = new TriThucBooksDbContext();
            var query = context.TheLoaiSaches.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.TenTheLoai.ToLower().Contains(keyword));
            }

            var result = await query
                .Select(tl => new
                {
                    MaTl = tl.MaTl,
                    TenTheLoai = tl.TenTheLoai,
                    MoTa = tl.MoTa,
                    SoLuongSach = tl.SoLuongSach ?? 0,
                    NgayTao = tl.NgayTao.HasValue ? tl.NgayTao.Value.ToString("yyyy/MM/dd HH:mm:ss") : ""
                })
                .ToListAsync();

            dgvTheLoai.DataSource = result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txtMaTL_TextChanged(object sender, EventArgs e) { }
        private void txtTenTL_TextChanged(object sender, EventArgs e) { }
        private void txtTimKiem_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void lblNgayTaoValue_Click(object sender, EventArgs e) { }
    }
}