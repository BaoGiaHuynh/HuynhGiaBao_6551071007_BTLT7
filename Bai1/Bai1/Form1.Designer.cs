namespace Bai1
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
            txtMaTL = new TextBox();
            txtTenTL = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtMoTa = new TextBox();
            label3 = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvTheLoai = new DataGridView();
            lblNgayTaoValue = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
            SuspendLayout();
            // 
            // txtMaTL
            // 
            txtMaTL.Location = new Point(121, 12);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.ReadOnly = true;
            txtMaTL.Size = new Size(125, 27);
            txtMaTL.TabIndex = 0;
            txtMaTL.TextChanged += txtMaTL_TextChanged;
            // 
            // txtTenTL
            // 
            txtTenTL.Location = new Point(121, 64);
            txtTenTL.Name = "txtTenTL";
            txtTenTL.Size = new Size(125, 27);
            txtTenTL.TabIndex = 1;
            txtTenTL.TextChanged += txtTenTL_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 19);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 2;
            label1.Text = "Mã thể loại";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 67);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 3;
            label2.Text = "Tên thể loại";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(121, 112);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(203, 94);
            txtMoTa.TabIndex = 4;
            txtMoTa.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 112);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 5;
            label3.Text = "Mô tả";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(44, 230);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(181, 27);
            txtTimKiem.TabIndex = 6;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(247, 230);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 7;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(414, 25);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(71, 29);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(502, 25);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(70, 29);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(587, 25);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(704, 25);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 11;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvTheLoai
            // 
            dgvTheLoai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoai.Location = new Point(-5, 275);
            dgvTheLoai.Name = "dgvTheLoai";
            dgvTheLoai.RowHeadersWidth = 51;
            dgvTheLoai.Size = new Size(803, 188);
            dgvTheLoai.TabIndex = 12;
            // 
            // lblNgayTaoValue
            // 
            lblNgayTaoValue.AutoSize = true;
            lblNgayTaoValue.Location = new Point(435, 71);
            lblNgayTaoValue.Name = "lblNgayTaoValue";
            lblNgayTaoValue.Size = new Size(69, 20);
            lblNgayTaoValue.TabIndex = 14;
            lblNgayTaoValue.Text = "--/--/----";
            lblNgayTaoValue.Click += lblNgayTaoValue_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(359, 71);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 13;
            label4.Text = "Ngày tạo";
            label4.Click += label4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNgayTaoValue);
            Controls.Add(label4);
            Controls.Add(dgvTheLoai);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(label3);
            Controls.Add(txtMoTa);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTenTL);
            Controls.Add(txtMaTL);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMaTL;
        private TextBox txtTenTL;
        private Label label1;
        private Label label2;
        private TextBox txtMoTa;
        private Label label3;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvTheLoai;
        private Label lblNgayTaoValue;
        private Label label4;
    }
}
