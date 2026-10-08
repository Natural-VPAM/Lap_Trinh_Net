using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picAnhLoi.Image = Image.FromFile(ofd.FileName);
                picAnhLoi.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            string maPhieu = txtMaPhieu.Text;
            string nguoiYeuCau = txtNguoiYeuCau.Text;
            string ngayGhiNhan = dtpNgayGhiNhan.Value.ToShortDateString();

            string mucDo = rbThap.Checked ? "Thấp" :
                           rbTrungBinh.Checked ? "Trung bình" :
                           rbKhanCap.Checked ? "Khẩn cấp" : "Chưa chọn";

            string loaiSuCo = cmbLoaiSuCo.SelectedItem?.ToString() ?? "Chưa chọn";

            string thietBi = "";
            if (chkMayTinhBan.Checked) thietBi += "Máy tính bàn, ";
            if (chkLaptop.Checked) thietBi += "Laptop, ";
            if (chkMayIn.Checked) thietBi += "Máy in, ";
            if (chkDienThoai.Checked) thietBi += "Điện thoại, ";
            if (thietBi.EndsWith(", ")) thietBi = thietBi.Substring(0, thietBi.Length - 2);

            string thongTin = $"Mã phiếu: {maPhieu}\n" +
                              $"Người yêu cầu: {nguoiYeuCau}\n" +
                              $"Ngày ghi nhận: {ngayGhiNhan}\n" +
                              $"Mức độ ưu tiên: {mucDo}\n" +
                              $"Loại sự cố: {loaiSuCo}\n" +
                              $"Thiết bị ảnh hưởng: {thietBi}";

            MessageBox.Show(thongTin, "Tóm tắt yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Clear();
            txtNguoiYeuCau.Clear();
            dtpNgayGhiNhan.Value = DateTime.Now;
            rbThap.Checked = rbTrungBinh.Checked = rbKhanCap.Checked = false;
            cmbLoaiSuCo.SelectedIndex = -1;
            chkMayTinhBan.Checked = chkLaptop.Checked = chkMayIn.Checked = chkDienThoai.Checked = false;
            picAnhLoi.Image = null;
        }
    }
}
