using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class ErrorProviderForm : Form
    {
        public ErrorProviderForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            epCheck.Clear(); // Xóa lỗi cũ
            bool isValid = true;

            // 1. Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                epCheck.SetError(txtUser, "Tên đăng nhập không được để trống");
                isValid = false;
            }

            // 2. Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                epCheck.SetError(txtPass, "Mật khẩu không được để trống");
                isValid = false;
            }

            // 3. Kiểm tra xác nhận mật khẩu
            if (txtPass.Text != txtConfirm.Text)
            {
                epCheck.SetError(txtConfirm, "Mật khẩu nhập lại không khớp");
                isValid = false;
            }

            // 4. Kiểm tra tuổi ≥ 18
            int age = DateTime.Now.Year - dtBirth.Value.Year;
            if (dtBirth.Value.Date > DateTime.Now.AddYears(-age)) age--; // điều chỉnh nếu chưa tới sinh nhật
            if (age < 18)
            {
                epCheck.SetError(dtBirth, "Bạn phải đủ 18 tuổi");
                isValid = false;
            }

            // 5. Kiểm tra điều khoản dịch vụ
            if (!chkAgree.Checked)
            {
                epCheck.SetError(chkAgree, "Bạn phải đồng ý điều khoản dịch vụ");
                isValid = false;
            }

            // Nếu hợp lệ
            if (isValid)
            {
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPass.Clear();
            txtConfirm.Clear();
            dtBirth.Value = DateTime.Now;
            rbMale.Checked = false;
            rbFemale.Checked = false;
            chkAgree.Checked = false;
            epCheck.Clear();
        }
    }
}
