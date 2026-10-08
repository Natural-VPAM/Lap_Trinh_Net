namespace WindowsFormsApp5
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.txtNguoiYeuCau = new System.Windows.Forms.TextBox();
            this.dtpNgayGhiNhan = new System.Windows.Forms.DateTimePicker();
            this.rbThap = new System.Windows.Forms.RadioButton();
            this.rbTrungBinh = new System.Windows.Forms.RadioButton();
            this.rbKhanCap = new System.Windows.Forms.RadioButton();
            this.cmbLoaiSuCo = new System.Windows.Forms.ComboBox();
            this.chkMayTinhBan = new System.Windows.Forms.CheckBox();
            this.chkLaptop = new System.Windows.Forms.CheckBox();
            this.chkMayIn = new System.Windows.Forms.CheckBox();
            this.chkDienThoai = new System.Windows.Forms.CheckBox();
            this.btnGuiYeuCau = new System.Windows.Forms.Button();
            this.btnNhapLai = new System.Windows.Forms.Button();
            this.picAnhLoi = new System.Windows.Forms.PictureBox();
            this.btnTaiAnh = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhLoi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(175, 63);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(298, 22);
            this.txtMaPhieu.TabIndex = 0;
            // 
            // txtNguoiYeuCau
            // 
            this.txtNguoiYeuCau.Location = new System.Drawing.Point(175, 135);
            this.txtNguoiYeuCau.Name = "txtNguoiYeuCau";
            this.txtNguoiYeuCau.Size = new System.Drawing.Size(298, 22);
            this.txtNguoiYeuCau.TabIndex = 1;
            // 
            // dtpNgayGhiNhan
            // 
            this.dtpNgayGhiNhan.Location = new System.Drawing.Point(175, 206);
            this.dtpNgayGhiNhan.Name = "dtpNgayGhiNhan";
            this.dtpNgayGhiNhan.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayGhiNhan.TabIndex = 2;
            // 
            // rbThap
            // 
            this.rbThap.AutoSize = true;
            this.rbThap.Location = new System.Drawing.Point(175, 263);
            this.rbThap.Name = "rbThap";
            this.rbThap.Size = new System.Drawing.Size(60, 20);
            this.rbThap.TabIndex = 3;
            this.rbThap.TabStop = true;
            this.rbThap.Text = "Thấp";
            this.rbThap.UseVisualStyleBackColor = true;
            // 
            // rbTrungBinh
            // 
            this.rbTrungBinh.AutoSize = true;
            this.rbTrungBinh.Location = new System.Drawing.Point(302, 263);
            this.rbTrungBinh.Name = "rbTrungBinh";
            this.rbTrungBinh.Size = new System.Drawing.Size(91, 20);
            this.rbTrungBinh.TabIndex = 4;
            this.rbTrungBinh.TabStop = true;
            this.rbTrungBinh.Text = "Trung bình";
            this.rbTrungBinh.UseVisualStyleBackColor = true;
            // 
            // rbKhanCap
            // 
            this.rbKhanCap.AutoSize = true;
            this.rbKhanCap.Location = new System.Drawing.Point(440, 263);
            this.rbKhanCap.Name = "rbKhanCap";
            this.rbKhanCap.Size = new System.Drawing.Size(84, 20);
            this.rbKhanCap.TabIndex = 5;
            this.rbKhanCap.TabStop = true;
            this.rbKhanCap.Text = "Khẩn cấp";
            this.rbKhanCap.UseVisualStyleBackColor = true;
            // 
            // cmbLoaiSuCo
            // 
            this.cmbLoaiSuCo.FormattingEnabled = true;
            this.cmbLoaiSuCo.Location = new System.Drawing.Point(175, 327);
            this.cmbLoaiSuCo.Name = "cmbLoaiSuCo";
            this.cmbLoaiSuCo.Size = new System.Drawing.Size(121, 24);
            this.cmbLoaiSuCo.TabIndex = 6;
            // 
            // chkMayTinhBan
            // 
            this.chkMayTinhBan.AutoSize = true;
            this.chkMayTinhBan.Location = new System.Drawing.Point(175, 393);
            this.chkMayTinhBan.Name = "chkMayTinhBan";
            this.chkMayTinhBan.Size = new System.Drawing.Size(104, 20);
            this.chkMayTinhBan.TabIndex = 7;
            this.chkMayTinhBan.Text = "Máy tính bàn";
            this.chkMayTinhBan.UseVisualStyleBackColor = true;
            // 
            // chkLaptop
            // 
            this.chkLaptop.AutoSize = true;
            this.chkLaptop.Location = new System.Drawing.Point(175, 419);
            this.chkLaptop.Name = "chkLaptop";
            this.chkLaptop.Size = new System.Drawing.Size(71, 20);
            this.chkLaptop.TabIndex = 8;
            this.chkLaptop.Text = "Laptop";
            this.chkLaptop.UseVisualStyleBackColor = true;
            // 
            // chkMayIn
            // 
            this.chkMayIn.AutoSize = true;
            this.chkMayIn.Location = new System.Drawing.Point(300, 393);
            this.chkMayIn.Name = "chkMayIn";
            this.chkMayIn.Size = new System.Drawing.Size(68, 20);
            this.chkMayIn.TabIndex = 9;
            this.chkMayIn.Text = "Máy in";
            this.chkMayIn.UseVisualStyleBackColor = true;
            // 
            // chkDienThoai
            // 
            this.chkDienThoai.AutoSize = true;
            this.chkDienThoai.Location = new System.Drawing.Point(300, 419);
            this.chkDienThoai.Name = "chkDienThoai";
            this.chkDienThoai.Size = new System.Drawing.Size(88, 20);
            this.chkDienThoai.TabIndex = 10;
            this.chkDienThoai.Text = "Điện thoại";
            this.chkDienThoai.UseVisualStyleBackColor = true;
            // 
            // btnGuiYeuCau
            // 
            this.btnGuiYeuCau.Location = new System.Drawing.Point(24, 719);
            this.btnGuiYeuCau.Name = "btnGuiYeuCau";
            this.btnGuiYeuCau.Size = new System.Drawing.Size(309, 23);
            this.btnGuiYeuCau.TabIndex = 11;
            this.btnGuiYeuCau.Text = "Gửi yêu cầu";
            this.btnGuiYeuCau.UseVisualStyleBackColor = true;
            // 
            // btnNhapLai
            // 
            this.btnNhapLai.Location = new System.Drawing.Point(481, 719);
            this.btnNhapLai.Name = "btnNhapLai";
            this.btnNhapLai.Size = new System.Drawing.Size(311, 23);
            this.btnNhapLai.TabIndex = 12;
            this.btnNhapLai.Text = "Nhập lại";
            this.btnNhapLai.UseVisualStyleBackColor = true;
            // 
            // picAnhLoi
            // 
            this.picAnhLoi.Location = new System.Drawing.Point(175, 481);
            this.picAnhLoi.Name = "picAnhLoi";
            this.picAnhLoi.Size = new System.Drawing.Size(100, 50);
            this.picAnhLoi.TabIndex = 13;
            this.picAnhLoi.TabStop = false;
            // 
            // btnTaiAnh
            // 
            this.btnTaiAnh.Location = new System.Drawing.Point(175, 566);
            this.btnTaiAnh.Name = "btnTaiAnh";
            this.btnTaiAnh.Size = new System.Drawing.Size(100, 23);
            this.btnTaiAnh.TabIndex = 14;
            this.btnTaiAnh.Text = "Tải ảnh lỗi";
            this.btnTaiAnh.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(24, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 15);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "Mã phiếu: ";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(24, 135);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 15);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "Người yêu cầu: ";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(24, 206);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 15);
            this.textBox3.TabIndex = 17;
            this.textBox3.Text = "Ngày ghi nhận: ";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(24, 263);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 15);
            this.textBox4.TabIndex = 18;
            this.textBox4.Text = "Mức độ ưu tiên: ";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(24, 328);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 15);
            this.textBox5.TabIndex = 19;
            this.textBox5.Text = "Chọn loại sự cố: ";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(12, 398);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(145, 15);
            this.textBox6.TabIndex = 20;
            this.textBox6.Text = "Chọn thiết bị ảnh hưởng: ";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Location = new System.Drawing.Point(24, 498);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 15);
            this.textBox7.TabIndex = 21;
            this.textBox7.Text = "Ảnh chụp lỗi: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 774);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnTaiAnh);
            this.Controls.Add(this.picAnhLoi);
            this.Controls.Add(this.btnNhapLai);
            this.Controls.Add(this.btnGuiYeuCau);
            this.Controls.Add(this.chkDienThoai);
            this.Controls.Add(this.chkMayIn);
            this.Controls.Add(this.chkLaptop);
            this.Controls.Add(this.chkMayTinhBan);
            this.Controls.Add(this.cmbLoaiSuCo);
            this.Controls.Add(this.rbKhanCap);
            this.Controls.Add(this.rbTrungBinh);
            this.Controls.Add(this.rbThap);
            this.Controls.Add(this.dtpNgayGhiNhan);
            this.Controls.Add(this.txtNguoiYeuCau);
            this.Controls.Add(this.txtMaPhieu);
            this.Name = "Form1";
            this.Text = "Form tiếp nhận và phân loại sự cố IT";
            this.Load += new System.EventHandler(this.btnTaiAnh_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picAnhLoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.TextBox txtNguoiYeuCau;
        private System.Windows.Forms.DateTimePicker dtpNgayGhiNhan;
        private System.Windows.Forms.RadioButton rbThap;
        private System.Windows.Forms.RadioButton rbTrungBinh;
        private System.Windows.Forms.RadioButton rbKhanCap;
        private System.Windows.Forms.ComboBox cmbLoaiSuCo;
        private System.Windows.Forms.CheckBox chkMayTinhBan;
        private System.Windows.Forms.CheckBox chkLaptop;
        private System.Windows.Forms.CheckBox chkMayIn;
        private System.Windows.Forms.CheckBox chkDienThoai;
        private System.Windows.Forms.Button btnGuiYeuCau;
        private System.Windows.Forms.Button btnNhapLai;
        private System.Windows.Forms.PictureBox picAnhLoi;
        private System.Windows.Forms.Button btnTaiAnh;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
    }
}

