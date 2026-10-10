namespace Bai2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtHoTen = new TextBox();
            txtSDT = new TextBox();
            txtEmail = new TextBox();
            grpGioiTinh = new GroupBox();
            rdoNam = new RadioButton();
            rdoNu = new RadioButton();
            dtpNgaySinh = new DateTimePicker();
            cboHangThanhVien = new ComboBox();
            chkTrangThai = new CheckBox();
            btnThem = new Button();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            txtTimHoTen = new TextBox();
            cboTimHangThanhVien = new ComboBox();
            label6 = new Label();
            btnTimKiem = new Button();
            dgvHoiVien = new DataGridView();
            grpGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "Họ tên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 142);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 1;
            label2.Text = "Ngày sinh";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 104);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 64);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 3;
            label4.Text = "Số điện thoại";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 171);
            label5.Name = "label5";
            label5.Size = new Size(117, 20);
            label5.TabIndex = 4;
            label5.Text = "Hạng thành viên";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(133, 24);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(171, 27);
            txtHoTen.TabIndex = 5;
            txtHoTen.TextChanged += txtHoTen_TextChanged;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(133, 61);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(171, 27);
            txtSDT.TabIndex = 6;
            txtSDT.TextChanged += txtSDT_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(135, 100);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(171, 27);
            txtEmail.TabIndex = 8;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // grpGioiTinh
            // 
            grpGioiTinh.Controls.Add(rdoNu);
            grpGioiTinh.Controls.Add(rdoNam);
            grpGioiTinh.Location = new Point(345, 31);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new Size(196, 96);
            grpGioiTinh.TabIndex = 9;
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";
            grpGioiTinh.Enter += grpGioiTinh_Enter;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Checked = true;
            rdoNam.Location = new Point(3, 23);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(62, 24);
            rdoNam.TabIndex = 0;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            rdoNam.CheckedChanged += rdoNam_CheckedChanged;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(102, 23);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(50, 24);
            rdoNu.TabIndex = 1;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            rdoNu.CheckedChanged += rdoNu_CheckedChanged;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(133, 135);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(171, 27);
            dtpNgaySinh.TabIndex = 10;
            dtpNgaySinh.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // cboHangThanhVien
            // 
            cboHangThanhVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHangThanhVien.FormattingEnabled = true;
            cboHangThanhVien.Items.AddRange(new object[] { "Basic", "VIP", "Premium" });
            cboHangThanhVien.Location = new Point(133, 171);
            cboHangThanhVien.Name = "cboHangThanhVien";
            cboHangThanhVien.Size = new Size(171, 28);
            cboHangThanhVien.TabIndex = 11;
            cboHangThanhVien.SelectedIndexChanged += cboHangThanhVien_SelectedIndexChanged;
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.CheckState = CheckState.Checked;
            chkTrangThai.Location = new Point(12, 220);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new Size(140, 24);
            chkTrangThai.TabIndex = 12;
            chkTrangThai.Text = "Đang hoạt động";
            chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(649, 31);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(649, 189);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 14;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(649, 133);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(649, 83);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // txtTimHoTen
            // 
            txtTimHoTen.Location = new Point(5, 250);
            txtTimHoTen.Name = "txtTimHoTen";
            txtTimHoTen.Size = new Size(171, 27);
            txtTimHoTen.TabIndex = 17;
            txtTimHoTen.TextChanged += txtTimHoTen_TextChanged;
            // 
            // cboTimHangThanhVien
            // 
            cboTimHangThanhVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimHangThanhVien.FormattingEnabled = true;
            cboTimHangThanhVien.Items.AddRange(new object[] { "Tất cả", "Basic", "VIP", "Premium" });
            cboTimHangThanhVien.Location = new Point(312, 249);
            cboTimHangThanhVien.Name = "cboTimHangThanhVien";
            cboTimHangThanhVien.Size = new Size(171, 28);
            cboTimHangThanhVien.TabIndex = 18;
            cboTimHangThanhVien.SelectedIndexChanged += cboTimHangThanhVien_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(189, 257);
            label6.Name = "label6";
            label6.Size = new Size(117, 20);
            label6.TabIndex = 19;
            label6.Text = "Hạng thành viên";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(649, 248);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 20;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvHoiVien
            // 
            dgvHoiVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoiVien.Location = new Point(12, 300);
            dgvHoiVien.Name = "dgvHoiVien";
            dgvHoiVien.RowHeadersWidth = 51;
            dgvHoiVien.Size = new Size(776, 188);
            dgvHoiVien.TabIndex = 21;
            dgvHoiVien.CellContentClick += dgvHoiVien_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvHoiVien);
            Controls.Add(btnTimKiem);
            Controls.Add(label6);
            Controls.Add(cboTimHangThanhVien);
            Controls.Add(txtTimHoTen);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnThem);
            Controls.Add(chkTrangThai);
            Controls.Add(cboHangThanhVien);
            Controls.Add(dtpNgaySinh);
            Controls.Add(grpGioiTinh);
            Controls.Add(txtEmail);
            Controls.Add(txtSDT);
            Controls.Add(txtHoTen);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtHoTen;
        private TextBox txtSDT;
        private TextBox txtEmail;
        private GroupBox grpGioiTinh;
        private RadioButton rdoNam;
        private RadioButton rdoNu;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cboHangThanhVien;
        private CheckBox chkTrangThai;
        private Button btnThem;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private TextBox txtTimHoTen;
        private ComboBox cboTimHangThanhVien;
        private Label label6;
        private Button btnTimKiem;
        private DataGridView dgvHoiVien;
    }
}
