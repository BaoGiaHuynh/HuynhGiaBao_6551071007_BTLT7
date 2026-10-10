namespace Bai4
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
            txtTenBenhNhan = new TextBox();
            txtSDT = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dtpNgayKham = new DateTimePicker();
            label4 = new Label();
            dtpGioKham = new DateTimePicker();
            label5 = new Label();
            btnThem = new Button();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            label6 = new Label();
            cboBacSi = new ComboBox();
            cboTrangThai = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            btnTimKiem = new Button();
            cboTimBacSi = new ComboBox();
            dgvLichKham = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
            SuspendLayout();
            // 
            // txtTenBenhNhan
            // 
            txtTenBenhNhan.Location = new Point(114, 21);
            txtTenBenhNhan.Name = "txtTenBenhNhan";
            txtTenBenhNhan.Size = new Size(168, 27);
            txtTenBenhNhan.TabIndex = 0;
            txtTenBenhNhan.TextChanged += textBox1_TextChanged;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(114, 64);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(168, 27);
            txtSDT.TabIndex = 1;
            txtSDT.TextChanged += txtSDT_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 21);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.TabIndex = 2;
            label1.Text = "Tên bệnh nhân";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 64);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 3;
            label2.Text = "Số điện thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 117);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 4;
            label3.Text = "Ngày khám";
            // 
            // dtpNgayKham
            // 
            dtpNgayKham.Format = DateTimePickerFormat.Short;
            dtpNgayKham.Location = new Point(114, 112);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new Size(168, 27);
            dtpNgayKham.TabIndex = 5;
            dtpNgayKham.ValueChanged += dtpNgayKham_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(305, 114);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 6;
            label4.Text = "Giờ khám";
            // 
            // dtpGioKham
            // 
            dtpGioKham.CustomFormat = "HH:mm";
            dtpGioKham.Format = DateTimePickerFormat.Custom;
            dtpGioKham.Location = new Point(305, 152);
            dtpGioKham.Name = "dtpGioKham";
            dtpGioKham.ShowUpDown = true;
            dtpGioKham.Size = new Size(85, 27);
            dtpGioKham.TabIndex = 7;
            dtpGioKham.ValueChanged += dtpGioKham_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(453, 114);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 8;
            label5.Text = "Bác sĩ";
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ActiveBorder;
            btnThem.Location = new Point(467, 12);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(72, 29);
            btnThem.TabIndex = 9;
            btnThem.Text = "Thêm ";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = SystemColors.ActiveBorder;
            btnLamMoi.Location = new Point(718, 12);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(77, 29);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = SystemColors.ActiveBorder;
            btnXoa.Location = new Point(645, 12);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(67, 29);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.ActiveBorder;
            btnSua.Location = new Point(554, 12);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 29);
            btnSua.TabIndex = 12;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(628, 117);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 13;
            label6.Text = "Trạng thái";
            // 
            // cboBacSi
            // 
            cboBacSi.FormattingEnabled = true;
            cboBacSi.Location = new Point(415, 152);
            cboBacSi.Name = "cboBacSi";
            cboBacSi.Size = new Size(151, 28);
            cboBacSi.TabIndex = 14;
            cboBacSi.SelectedIndexChanged += cboBacSi_SelectedIndexChanged;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(613, 152);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(127, 28);
            cboTrangThai.TabIndex = 15;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 233);
            label8.Name = "label8";
            label8.Size = new Size(62, 20);
            label8.TabIndex = 17;
            label8.Text = "Từ ngày";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(234, 235);
            label9.Name = "label9";
            label9.Size = new Size(72, 20);
            label9.TabIndex = 18;
            label9.Text = "Đến ngày";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(93, 228);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(117, 27);
            dtpTuNgay.TabIndex = 19;
            dtpTuNgay.ValueChanged += dtpTuNgay_ValueChanged;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(312, 228);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(108, 27);
            dtpDenNgay.TabIndex = 20;
            dtpDenNgay.ValueChanged += dtpDenNgay_ValueChanged;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveBorder;
            btnTimKiem.Location = new Point(610, 229);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(102, 29);
            btnTimKiem.TabIndex = 21;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // cboTimBacSi
            // 
            cboTimBacSi.FormattingEnabled = true;
            cboTimBacSi.Location = new Point(453, 230);
            cboTimBacSi.Name = "cboTimBacSi";
            cboTimBacSi.Size = new Size(151, 28);
            cboTimBacSi.TabIndex = 22;
            cboTimBacSi.SelectedIndexChanged += cboTimBacSi_SelectedIndexChanged;
            // 
            // dgvLichKham
            // 
            dgvLichKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichKham.Location = new Point(12, 273);
            dgvLichKham.Name = "dgvLichKham";
            dgvLichKham.RowHeadersWidth = 51;
            dgvLichKham.Size = new Size(783, 188);
            dgvLichKham.TabIndex = 23;
            dgvLichKham.CellContentClick += dgvLichKham_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvLichKham);
            Controls.Add(cboTimBacSi);
            Controls.Add(btnTimKiem);
            Controls.Add(dtpDenNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(cboTrangThai);
            Controls.Add(cboBacSi);
            Controls.Add(label6);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnThem);
            Controls.Add(label5);
            Controls.Add(dtpGioKham);
            Controls.Add(label4);
            Controls.Add(dtpNgayKham);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSDT);
            Controls.Add(txtTenBenhNhan);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTenBenhNhan;
        private TextBox txtSDT;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpNgayKham;
        private Label label4;
        private DateTimePicker dtpGioKham;
        private Label label5;
        private Button btnThem;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Label label6;
        private ComboBox cboBacSi;
        private ComboBox cboTrangThai;
        private Label label8;
        private Label label9;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnTimKiem;
        private ComboBox cboTimBacSi;
        private DataGridView dgvLichKham;
    }
}
