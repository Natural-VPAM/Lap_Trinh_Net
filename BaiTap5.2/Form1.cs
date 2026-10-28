using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp18
{
    public partial class SchoolRegisterForm : Form
    {
        string strConn =
            @"Server=TRUNGHIEU\SQLEXPRESS;
              Database=ql_sinhvien;
              Integrated Security=True";

        public SchoolRegisterForm()
        {
            InitializeComponent();
        }

        private void SchoolRegisterForm_Load(object sender, EventArgs e)
        {
            mtxtPhone.Mask = "(000) 000-0000";
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";

            LoadCourse();
        }

        private void LoadCourse()
        {
            try
            {
                using (SqlConnection conn =
                       new SqlConnection(strConn))
                {
                    string sql =
                        "SELECT DISTINCT Lop FROM SinhVien";

                    SqlDataAdapter da =
                        new SqlDataAdapter(sql, conn);

                    DataTable dt =
                        new DataTable();

                    da.Fill(dt);

                    cboCourse.DataSource = dt;
                    cboCourse.DisplayMember = "Lop";
                    cboCourse.ValueMember = "Lop";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string hoTen = txtFullName.Text.Trim();

            string dienThoai = mtxtPhone.Text;

            string gioiTinh = "";

            if (radMale.Checked)
                gioiTinh = "Nam";
            else if (radFemale.Checked)
                gioiTinh = "Nữ";

            string khoaHoc =
                cboCourse.Text;

            string ngaySinh =
                dtpBirthDate.Value
                .ToString("dd/MM/yyyy");

            string soThich = "";

            if (chkEnglish.Checked)
                soThich += "Tiếng Anh, ";

            if (chkIT.Checked)
                soThich += "Tin học, ";

            if (chkSoftSkill.Checked)
                soThich += "Kỹ năng mềm, ";

            if (soThich.Length > 0)
            {
                soThich = soThich.Substring(
                    0,
                    soThich.Length - 2);
            }

            string thongTin =
                "===== THÔNG TIN ĐĂNG KÝ =====" +
                "\nHọ tên: " + hoTen +
                "\nSố điện thoại: " + dienThoai +
                "\nNgày sinh: " + ngaySinh +
                "\nGiới tính: " + gioiTinh +
                "\nLớp: " + khoaHoc +
                "\nSở thích: " + soThich;

            MessageBox.Show(
                thongTin,
                "Thông tin đăng ký",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
