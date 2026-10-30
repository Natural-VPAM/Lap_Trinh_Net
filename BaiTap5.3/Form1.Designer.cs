using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp19
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        private FlowLayoutPanel flpBan;
        private ComboBox cboDanhMuc;
        private ComboBox cboMon;
        private NumericUpDown nudSoLuong;

        private Button btnThemMon;
        private Button btnThanhToan;
        private Button btnDoiBan;

        private DataGridView dgvHoaDon;

        private Label lblTongTien;
        private Label lblDanhMuc;
        private Label lblMon;
        private Label lblSoLuong;

        private GroupBox groupBoxBan;
        private GroupBox groupBoxOrder;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxBan = new GroupBox();
            this.flpBan = new FlowLayoutPanel();

            this.groupBoxOrder = new GroupBox();

            this.lblDanhMuc = new Label();
            this.lblMon = new Label();
            this.lblSoLuong = new Label();

            this.cboDanhMuc = new ComboBox();
            this.cboMon = new ComboBox();

            this.nudSoLuong = new NumericUpDown();

            this.btnThemMon = new Button();
            this.btnDoiBan = new Button();
            this.btnThanhToan = new Button();

            this.dgvHoaDon = new DataGridView();

            this.lblTongTien = new Label();

            this.groupBoxBan.SuspendLayout();
            this.groupBoxOrder.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
            (this.nudSoLuong)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
            (this.dgvHoaDon)).BeginInit();

            this.SuspendLayout();

            // Form

            this.Text = "Cafe POS System";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1200, 700);

            // groupBoxBan

            this.groupBoxBan.Text = "Danh sách bàn";
            this.groupBoxBan.Location = new Point(12, 12);
            this.groupBoxBan.Size = new Size(450, 650);

            // flpBan

            this.flpBan.Dock = DockStyle.Fill;
            this.flpBan.AutoScroll = true;

            this.groupBoxBan.Controls.Add(this.flpBan);

            // groupBoxOrder

            this.groupBoxOrder.Text = "Gọi món";
            this.groupBoxOrder.Location = new Point(480, 12);
            this.groupBoxOrder.Size = new Size(700, 650);

            // Label danh mục

            this.lblDanhMuc.Text = "Danh mục";
            this.lblDanhMuc.Location = new Point(20, 40);

            // Combo danh mục

            this.cboDanhMuc.Location = new Point(120, 35);
            this.cboDanhMuc.Size = new Size(250, 30);

            // Label món

            this.lblMon.Text = "Món ăn";
            this.lblMon.Location = new Point(20, 80);

            // Combo món

            this.cboMon.Location = new Point(120, 75);
            this.cboMon.Size = new Size(250, 30);

            // Label số lượng

            this.lblSoLuong.Text = "Số lượng";
            this.lblSoLuong.Location = new Point(20, 120);

            // Numeric số lượng

            this.nudSoLuong.Location = new Point(120, 115);
            this.nudSoLuong.Minimum = 1;
            this.nudSoLuong.Maximum = 100;
            this.nudSoLuong.Value = 1;

            // Thêm món

            this.btnThemMon.Text = "Thêm món";
            this.btnThemMon.Location = new Point(400, 35);
            this.btnThemMon.Size = new Size(120, 35);

            // Đổi bàn

            this.btnDoiBan.Text = "Đổi bàn";
            this.btnDoiBan.Location = new Point(540, 35);
            this.btnDoiBan.Size = new Size(120, 35);

            // DataGridView

            this.dgvHoaDon.Location = new Point(20, 180);
            this.dgvHoaDon.Size = new Size(650, 350);

            this.dgvHoaDon.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Tổng tiền

            this.lblTongTien.Text = "Tổng tiền : 0 VNĐ";
            this.lblTongTien.Font =
                new Font("Arial", 12, FontStyle.Bold);

            this.lblTongTien.Location =
                new Point(20, 570);

            this.lblTongTien.AutoSize = true;

            // Thanh toán

            this.btnThanhToan.Text = "THANH TOÁN";
            this.btnThanhToan.BackColor = Color.Gold;

            this.btnThanhToan.Location =
                new Point(500, 560);

            this.btnThanhToan.Size =
                new Size(170, 50);

            // Add controls

            this.groupBoxOrder.Controls.Add(this.lblDanhMuc);
            this.groupBoxOrder.Controls.Add(this.cboDanhMuc);

            this.groupBoxOrder.Controls.Add(this.lblMon);
            this.groupBoxOrder.Controls.Add(this.cboMon);

            this.groupBoxOrder.Controls.Add(this.lblSoLuong);
            this.groupBoxOrder.Controls.Add(this.nudSoLuong);

            this.groupBoxOrder.Controls.Add(this.btnThemMon);
            this.groupBoxOrder.Controls.Add(this.btnDoiBan);

            this.groupBoxOrder.Controls.Add(this.dgvHoaDon);

            this.groupBoxOrder.Controls.Add(this.lblTongTien);

            this.groupBoxOrder.Controls.Add(this.btnThanhToan);

            // add form

            this.Controls.Add(this.groupBoxBan);
            this.Controls.Add(this.groupBoxOrder);

            this.groupBoxBan.ResumeLayout(false);
            this.groupBoxOrder.ResumeLayout(false);

            this.groupBoxOrder.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
            (this.nudSoLuong)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
            (this.dgvHoaDon)).EndInit();

            this.ResumeLayout(false);
        }
    }

    partial class FrmQuanLyMon
    {
        private Label lblMaMon;
        private Label lblTenMon;
        private Label lblDanhMuc;
        private Label lblDonGia;

        private TextBox txtMaMon;
        private TextBox txtTenMon;
        private TextBox txtDonGia;

        private ComboBox cboDanhMuc;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private DataGridView dgvMon;

        private void InitializeComponent()
        {
            this.lblMaMon = new Label();
            this.lblTenMon = new Label();
            this.lblDanhMuc = new Label();
            this.lblDonGia = new Label();

            this.txtMaMon = new TextBox();
            this.txtTenMon = new TextBox();
            this.txtDonGia = new TextBox();

            this.cboDanhMuc = new ComboBox();

            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnXoa = new Button();
            this.btnLamMoi = new Button();

            this.dgvMon = new DataGridView();

            this.SuspendLayout();

            this.Text = "Quản lý thực đơn";
            this.StartPosition =
                FormStartPosition.CenterScreen;

            this.Size = new Size(900, 600);

            // Mã món

            lblMaMon.Text = "Mã món";
            lblMaMon.Location = new Point(30, 30);

            txtMaMon.Location =
                new Point(130, 25);

            txtMaMon.ReadOnly = true;

            // Tên món

            lblTenMon.Text = "Tên món";
            lblTenMon.Location = new Point(30, 70);

            txtTenMon.Location =
                new Point(130, 65);

            txtTenMon.Width = 250;

            // Danh mục

            lblDanhMuc.Text = "Danh mục";
            lblDanhMuc.Location =
                new Point(30, 110);

            cboDanhMuc.Location =
                new Point(130, 105);

            cboDanhMuc.Width = 250;

            // Đơn giá

            lblDonGia.Text = "Đơn giá";
            lblDonGia.Location =
                new Point(30, 150);

            txtDonGia.Location =
                new Point(130, 145);

            txtDonGia.Width = 250;

            // Buttons

            btnThem.Text = "Thêm";
            btnThem.Location =
                new Point(450, 25);

            btnSua.Text = "Sửa";
            btnSua.Location =
                new Point(550, 25);

            btnXoa.Text = "Xóa";
            btnXoa.Location =
                new Point(650, 25);

            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location =
                new Point(750, 25);

            // Grid

            dgvMon.Location =
                new Point(30, 220);

            dgvMon.Size =
                new Size(820, 300);

            dgvMon.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Control

            Controls.Add(lblMaMon);
            Controls.Add(txtMaMon);

            Controls.Add(lblTenMon);
            Controls.Add(txtTenMon);

            Controls.Add(lblDanhMuc);
            Controls.Add(cboDanhMuc);

            Controls.Add(lblDonGia);
            Controls.Add(txtDonGia);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(dgvMon);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}

