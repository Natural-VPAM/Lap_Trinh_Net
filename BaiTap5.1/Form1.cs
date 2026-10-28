using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    public partial class LoginForm : Form
    {
        string strConn =
            @"Server=Trunghieu\SQLEXPRESS;
              Database=LoginDB;
              Integrated Security=True";


        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;

            // Enter = Login
            this.AcceptButton = btnLogin;

            // Esc = Exit
            this.CancelButton = btnExit;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private bool ValidateInput()
        {
            bool check = true;

            errorProvider1.Clear();

            if (txtUsername.Text.Trim() == "")
            {
                errorProvider1.SetError(txtUsername,
                    "Tên đăng nhập không được để trống");
                check = false;
            }

            if (txtPassword.Text.Trim() == "")
            {
                errorProvider1.SetError(txtPassword,
                    "Mật khẩu không được để trống");
                check = false;
            }

            return check;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            string strConn =
                @"Server=DESKTOP-ABC;
          Database=LoginDB;
          Integrated Security=True";

            SqlConnection conn =
                new SqlConnection(strConn);

            string sql =
                "SELECT COUNT(*) FROM TaiKhoan " +
                "WHERE Username=@user AND Password=@pass";

            SqlCommand cmd =
                new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@user",
                txtUsername.Text.Trim());

            cmd.Parameters.AddWithValue("@pass",
                txtPassword.Text.Trim());

            conn.Open();

            int count = (int)cmd.ExecuteScalar();

            conn.Close();

            if (count > 0)
            {
                MessageBox.Show(
                    "Đăng nhập thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "Sai tên đăng nhập hoặc mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
        "Bạn có muốn thoát không?",
        "Xác nhận",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
