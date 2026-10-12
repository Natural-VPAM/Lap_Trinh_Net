using System.Windows.Forms;

namespace WindowsFormsApp11
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelUser;
        private ToolStripStatusLabel toolStripStatusLabelInfo;
        private ToolStripStatusLabel toolStripStatusLabelTime;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.toolStrip1 = new ToolStrip();
            this.statusStrip1 = new StatusStrip();
            this.toolStripStatusLabelUser = new ToolStripStatusLabel();
            this.toolStripStatusLabelInfo = new ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new ToolStripStatusLabel();

            // MenuStrip
            ToolStripMenuItem systemMenu = new ToolStripMenuItem("Hệ thống");
            systemMenu.DropDownItems.Add("Đăng xuất", null, menuLogout_Click);
            systemMenu.DropDownItems.Add("Thoát", null, menuExit_Click);

            ToolStripMenuItem categoryMenu = new ToolStripMenuItem("Danh mục");
            categoryMenu.DropDownItems.Add("Quản lý Sinh viên", null, menuStudent_Click);
            categoryMenu.DropDownItems.Add("Quản lý Sản phẩm", null, menuProduct_Click);

            ToolStripMenuItem windowMenu = new ToolStripMenuItem("Cửa sổ");
            windowMenu.DropDownItems.Add("Cascade", null, menuCascade_Click);
            windowMenu.DropDownItems.Add("Tile Horizontal", null, menuTileH_Click);
            windowMenu.DropDownItems.Add("Tile Vertical", null, menuTileV_Click);

            this.menuStrip1.Items.AddRange(new ToolStripItem[] { systemMenu, categoryMenu, windowMenu });

            // ToolStrip
            ToolStripButton btnStudent = new ToolStripButton("Sinh viên", null, menuStudent_Click);
            ToolStripButton btnProduct = new ToolStripButton("Sản phẩm", null, menuProduct_Click);
            this.toolStrip1.Items.AddRange(new ToolStripItem[] { btnStudent, btnProduct });

            // StatusStrip
            this.statusStrip1.Items.AddRange(new ToolStripItem[] {
                toolStripStatusLabelUser,
                toolStripStatusLabelInfo,
                toolStripStatusLabelTime
            });

            // FormMain
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Text = "MDI Parent - Quản lý đa cửa sổ";
            this.WindowState = FormWindowState.Maximized;
            this.Load += FormMain_Load;
        }
    }

    partial class FormStudent
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private TextBox txtId, txtName, txtAge;
        private ComboBox cboGender;
        private PictureBox picAvatar;
        private Button btnAdd, btnDelete, btnUpdate, btnChooseImage, btnExportCSV;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new DataGridView();
            this.txtId = new TextBox();
            this.txtName = new TextBox();
            this.txtAge = new TextBox();
            this.cboGender = new ComboBox();
            this.picAvatar = new PictureBox();
            this.btnAdd = new Button();
            this.btnDelete = new Button();
            this.btnUpdate = new Button();
            this.btnChooseImage = new Button();
            this.btnExportCSV = new Button();

            // DataGridView
            this.dataGridView1.Dock = DockStyle.Bottom;
            this.dataGridView1.Height = 200;

            // TextBox & ComboBox
            this.txtId.SetBounds(20, 20, 200, 25);
            this.txtName.SetBounds(20, 60, 200, 25);
            this.txtAge.SetBounds(20, 100, 200, 25);
            this.cboGender.SetBounds(20, 140, 200, 25);
            this.cboGender.Items.AddRange(new string[] { "Nam", "Nữ" });

            // PictureBox
            this.picAvatar.SetBounds(250, 20, 120, 120);
            this.picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;

            // Buttons
            this.btnAdd.Text = "Thêm";
            this.btnAdd.SetBounds(20, 180, 80, 30);
            this.btnAdd.Click += btnAdd_Click;

            this.btnDelete.Text = "Xóa";
            this.btnDelete.SetBounds(110, 180, 80, 30);
            this.btnDelete.Click += btnDelete_Click;

            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.SetBounds(200, 180, 80, 30);
            this.btnUpdate.Click += btnUpdate_Click;

            this.btnChooseImage.Text = "Chọn ảnh";
            this.btnChooseImage.SetBounds(250, 150, 120, 30);
            this.btnChooseImage.Click += btnChooseImage_Click;

            this.btnExportCSV.Text = "Xuất CSV";
            this.btnExportCSV.SetBounds(20, 220, 120, 30);
            this.btnExportCSV.Click += btnExportCSV_Click;

            // FormStudent
            this.Controls.AddRange(new Control[] {
                txtId, txtName, txtAge, cboGender, picAvatar,
                btnAdd, btnDelete, btnUpdate, btnChooseImage, btnExportCSV,
                dataGridView1
            });
            this.Text = "Quản lý Sinh viên";
            this.Load += FormStudent_Load;
        }
    }

    partial class FormProduct
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.label1.Text = "Quản lý sản phẩm";
            this.label1.AutoSize = true;
            this.label1.SetBounds(20, 20, 200, 30);

            this.Controls.Add(this.label1);
            this.Text = "Quản lý Sản phẩm";
            this.Load += FormProduct_Load;
        }
    }
}