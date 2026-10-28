namespace WindowsFormsApp18
{
    partial class SchoolRegisterForm
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
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.mtxtPhone = new System.Windows.Forms.MaskedTextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.radMale = new System.Windows.Forms.RadioButton();
            this.radFemale = new System.Windows.Forms.RadioButton();
            this.chkEnglish = new System.Windows.Forms.CheckBox();
            this.chkIT = new System.Windows.Forms.CheckBox();
            this.chkSoftSkill = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(134, 25);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(160, 22);
            this.txtFullName.TabIndex = 0;
            // 
            // mtxtPhone
            // 
            this.mtxtPhone.Location = new System.Drawing.Point(542, 25);
            this.mtxtPhone.Name = "mtxtPhone";
            this.mtxtPhone.Size = new System.Drawing.Size(173, 22);
            this.mtxtPhone.TabIndex = 1;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Location = new System.Drawing.Point(288, 136);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(200, 22);
            this.dtpBirthDate.TabIndex = 2;
            // 
            // cboCourse
            // 
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(288, 258);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(158, 24);
            this.cboCourse.TabIndex = 3;
            // 
            // radMale
            // 
            this.radMale.AutoSize = true;
            this.radMale.Location = new System.Drawing.Point(257, 336);
            this.radMale.Name = "radMale";
            this.radMale.Size = new System.Drawing.Size(57, 20);
            this.radMale.TabIndex = 4;
            this.radMale.TabStop = true;
            this.radMale.Text = "Nam";
            this.radMale.UseVisualStyleBackColor = true;
            // 
            // radFemale
            // 
            this.radFemale.AutoSize = true;
            this.radFemale.Location = new System.Drawing.Point(489, 336);
            this.radFemale.Name = "radFemale";
            this.radFemale.Size = new System.Drawing.Size(45, 20);
            this.radFemale.TabIndex = 5;
            this.radFemale.TabStop = true;
            this.radFemale.Text = "Nữ";
            this.radFemale.UseVisualStyleBackColor = true;
            // 
            // chkEnglish
            // 
            this.chkEnglish.AutoSize = true;
            this.chkEnglish.Location = new System.Drawing.Point(232, 417);
            this.chkEnglish.Name = "chkEnglish";
            this.chkEnglish.Size = new System.Drawing.Size(90, 20);
            this.chkEnglish.TabIndex = 6;
            this.chkEnglish.Text = "Tiếng Anh";
            this.chkEnglish.UseVisualStyleBackColor = true;
            // 
            // chkIT
            // 
            this.chkIT.AutoSize = true;
            this.chkIT.Location = new System.Drawing.Point(383, 417);
            this.chkIT.Name = "chkIT";
            this.chkIT.Size = new System.Drawing.Size(146, 20);
            this.chkIT.TabIndex = 7;
            this.chkIT.Text = "Công nghệ thông tin";
            this.chkIT.UseVisualStyleBackColor = true;
            // 
            // chkSoftSkill
            // 
            this.chkSoftSkill.AutoSize = true;
            this.chkSoftSkill.Location = new System.Drawing.Point(580, 417);
            this.chkSoftSkill.Name = "chkSoftSkill";
            this.chkSoftSkill.Size = new System.Drawing.Size(110, 20);
            this.chkSoftSkill.TabIndex = 8;
            this.chkSoftSkill.Text = "Kỹ năng mềm";
            this.chkSoftSkill.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(279, 530);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(187, 23);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Họ và tên: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(421, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Số điện thoại: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ngày sinh: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Khóa học: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Giới tính: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Môn học: ";
            // 
            // SchoolRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 579);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.chkSoftSkill);
            this.Controls.Add(this.chkIT);
            this.Controls.Add(this.chkEnglish);
            this.Controls.Add(this.radFemale);
            this.Controls.Add(this.radMale);
            this.Controls.Add(this.cboCourse);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.mtxtPhone);
            this.Controls.Add(this.txtFullName);
            this.Name = "SchoolRegisterForm";
            this.Text = "Form đăng ký học viên";
            this.Load += new System.EventHandler(this.SchoolRegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.MaskedTextBox mtxtPhone;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.RadioButton radMale;
        private System.Windows.Forms.RadioButton radFemale;
        private System.Windows.Forms.CheckBox chkEnglish;
        private System.Windows.Forms.CheckBox chkIT;
        private System.Windows.Forms.CheckBox chkSoftSkill;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

