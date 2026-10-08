using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            double donGia, giamGia;
            int soLuong;

            // Kiểm tra dữ liệu nhập
            if (!double.TryParse(txtDonGia.Text, out donGia) ||
                !int.TryParse(txtSoLuong.Text, out soLuong) ||
                !double.TryParse(txtGiamGia.Text, out giamGia))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Công thức tính tổng tiền
            double tongTien = (donGia * soLuong) * (100 - giamGia) / 100;

            // Hiển thị kết quả
            lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VND";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();
            lblTongTien.Text = "";
            txtDonGia.Focus();
        }
    }
}
