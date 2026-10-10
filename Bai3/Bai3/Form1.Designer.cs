namespace Bai3
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
            txtSoPhong = new TextBox();
            label1 = new Label();
            label2 = new Label();
            numTangSo = new NumericUpDown();
            cboLoaiPhong = new ComboBox();
            cboTinhTrang = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            picHinhAnh = new PictureBox();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnLamMoi = new Button();
            btnChonAnh = new Button();
            cboTimLoaiPhong = new ComboBox();
            cboTimTinhTrang = new ComboBox();
            btnTimKiem = new Button();
            dgvPhong = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)numTangSo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
            SuspendLayout();
            // 
            // txtSoPhong
            // 
            txtSoPhong.Location = new Point(2, 32);
            txtSoPhong.Name = "txtSoPhong";
            txtSoPhong.Size = new Size(96, 27);
            txtSoPhong.TabIndex = 0;
            txtSoPhong.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 1;
            label1.Text = "Số phòng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(123, 9);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 2;
            label2.Text = "Tầng số";
            // 
            // numTangSo
            // 
            numTangSo.Location = new Point(123, 32);
            numTangSo.Name = "numTangSo";
            numTangSo.Size = new Size(61, 27);
            numTangSo.TabIndex = 3;
            numTangSo.ValueChanged += numTangSo_ValueChanged;
            // 
            // cboLoaiPhong
            // 
            cboLoaiPhong.FormattingEnabled = true;
            cboLoaiPhong.Location = new Point(221, 32);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(151, 28);
            cboLoaiPhong.TabIndex = 4;
            cboLoaiPhong.SelectedIndexChanged += cboLoaiPhong_SelectedIndexChanged;
            // 
            // cboTinhTrang
            // 
            cboTinhTrang.FormattingEnabled = true;
            cboTinhTrang.Location = new Point(400, 32);
            cboTinhTrang.Name = "cboTinhTrang";
            cboTinhTrang.Size = new Size(151, 28);
            cboTinhTrang.TabIndex = 5;
            cboTinhTrang.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(221, 9);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 6;
            label3.Text = "Loại phòng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(400, 9);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 7;
            label4.Text = "Tình trạng";
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(575, 12);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(125, 62);
            picHinhAnh.TabIndex = 8;
            picHinhAnh.TabStop = false;
            picHinhAnh.Click += picHinhAnh_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(706, 21);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 9;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(706, 91);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(706, 56);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(706, 126);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 12;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(594, 80);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(94, 29);
            btnChonAnh.TabIndex = 13;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // cboTimLoaiPhong
            // 
            cboTimLoaiPhong.FormattingEnabled = true;
            cboTimLoaiPhong.Location = new Point(2, 92);
            cboTimLoaiPhong.Name = "cboTimLoaiPhong";
            cboTimLoaiPhong.Size = new Size(151, 28);
            cboTimLoaiPhong.TabIndex = 14;
            cboTimLoaiPhong.SelectedIndexChanged += cboTimLoaiPhong_SelectedIndexChanged;
            // 
            // cboTimTinhTrang
            // 
            cboTimTinhTrang.FormattingEnabled = true;
            cboTimTinhTrang.Location = new Point(184, 92);
            cboTimTinhTrang.Name = "cboTimTinhTrang";
            cboTimTinhTrang.Size = new Size(151, 28);
            cboTimTinhTrang.TabIndex = 15;
            cboTimTinhTrang.SelectedIndexChanged += cboTimTinhTrang_SelectedIndexChanged;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(365, 92);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 16;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvPhong
            // 
            dgvPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhong.Location = new Point(-9, 182);
            dgvPhong.Name = "dgvPhong";
            dgvPhong.RowHeadersWidth = 51;
            dgvPhong.Size = new Size(809, 267);
            dgvPhong.TabIndex = 17;
            dgvPhong.CellContentClick += dgvPhong_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvPhong);
            Controls.Add(btnTimKiem);
            Controls.Add(cboTimTinhTrang);
            Controls.Add(cboTimLoaiPhong);
            Controls.Add(btnChonAnh);
            Controls.Add(btnLamMoi);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(picHinhAnh);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cboTinhTrang);
            Controls.Add(cboLoaiPhong);
            Controls.Add(numTangSo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSoPhong);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numTangSo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSoPhong;
        private Label label1;
        private Label label2;
        private NumericUpDown numTangSo;
        private ComboBox cboLoaiPhong;
        private ComboBox cboTinhTrang;
        private Label label3;
        private Label label4;
        private PictureBox picHinhAnh;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLamMoi;
        private Button btnChonAnh;
        private ComboBox cboTimLoaiPhong;
        private ComboBox cboTimTinhTrang;
        private Button btnTimKiem;
        private DataGridView dgvPhong;
    }
}
