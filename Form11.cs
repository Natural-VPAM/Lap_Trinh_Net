using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin trạng thái ban đầu
            toolStripStatusLabelUser.Text = "Người dùng: Admin";
            toolStripStatusLabelInfo.Text = "Sẵn sàng";
            toolStripStatusLabelTime.Text = DateTime.Now.ToString("HH:mm:ss");

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, ev) => toolStripStatusLabelTime.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();
        }

        // Kiểm tra Form con đã mở chưa
        private Form CheckExists(Type fType)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == fType)
                    return frm;
            }
            return null;
        }

        // Mở FormStudent
        private void menuStudent_Click(object sender, EventArgs e)
        {
            Form frm = CheckExists(typeof(FormStudent));
            if (frm == null)
            {
                frm = new FormStudent();
                frm.MdiParent = this;
                frm.Show();
            }
            else frm.Activate();
        }

        // Mở FormProduct
        private void menuProduct_Click(object sender, EventArgs e)
        {
            Form frm = CheckExists(typeof(FormProduct));
            if (frm == null)
            {
                frm = new FormProduct();
                frm.MdiParent = this;
                frm.Show();
            }
            else frm.Activate();
        }

        // Menu Hệ thống
        private void menuLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng xuất thành công!");
            toolStripStatusLabelInfo.Text = "Đã đăng xuất";
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Menu Cửa sổ
        private void menuCascade_Click(object sender, EventArgs e) => this.LayoutMdi(MdiLayout.Cascade);
        private void menuTileH_Click(object sender, EventArgs e) => this.LayoutMdi(MdiLayout.TileHorizontal);
        private void menuTileV_Click(object sender, EventArgs e) => this.LayoutMdi(MdiLayout.TileVertical);

        // Hàm cập nhật StatusStrip từ Form con
        public void UpdateStatus(string message)
        {
            toolStripStatusLabelInfo.Text = message;
        }
    }

    public class Student
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string AvatarPath { get; set; }
    }
    public partial class FormStudent : Form
    {
        BindingList<Student> students = new BindingList<Student>();
        BindingSource bindingSource = new BindingSource();

        public FormStudent()
        {
            InitializeComponent();
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = students;
            dataGridView1.DataSource = bindingSource;

            txtId.DataBindings.Add("Text", bindingSource, "StudentId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtName.DataBindings.Add("Text", bindingSource, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge.DataBindings.Add("Text", bindingSource, "Age", true, DataSourceUpdateMode.OnPropertyChanged);
            cboGender.DataBindings.Add("Text", bindingSource, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);
            picAvatar.DataBindings.Add("ImageLocation", bindingSource, "AvatarPath", true, DataSourceUpdateMode.OnPropertyChanged);

            // ContextMenuStrip cho DataGridView
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.Add("Xóa dòng", null, DeleteRow_Click);
            cms.Items.Add("Làm mới dữ liệu", null, RefreshData_Click);
            cms.Items.Add("Xem chi tiết", null, ViewDetail_Click);
            dataGridView1.ContextMenuStrip = cms;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            students.Add(new Student());
            bindingSource.MoveLast();
            NotifyParent("Đã thêm sinh viên mới");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bindingSource.RemoveCurrent();
            NotifyParent("Đã xóa sinh viên");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bindingSource.ResetCurrentItem();
            NotifyParent("Đã cập nhật thông tin sinh viên");
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ((Student)bindingSource.Current).AvatarPath = ofd.FileName;
                picAvatar.ImageLocation = ofd.FileName;
            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    sw.WriteLine("StudentId,FullName,Age,Gender,AvatarPath");
                    foreach (var st in students)
                    {
                        sw.WriteLine($"{st.StudentId},{st.FullName},{st.Age},{st.Gender},{st.AvatarPath}");
                    }
                }
                NotifyParent("Xuất CSV thành công");
            }
        }

        // ContextMenuStrip handlers
        private void DeleteRow_Click(object sender, EventArgs e) => btnDelete_Click(sender, e);
        private void RefreshData_Click(object sender, EventArgs e) => bindingSource.ResetBindings(false);
        private void ViewDetail_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Student st)
                MessageBox.Show($"Mã SV: {st.StudentId}\nHọ tên: {st.FullName}\nTuổi: {st.Age}\nGiới tính: {st.Gender}");
        }

        // Gửi thông báo lên StatusStrip của FormMain
        private void NotifyParent(string message)
        {
            if (this.MdiParent is FormMain parent)
                parent.UpdateStatus(message);
        }
    }

    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            // Ví dụ đơn giản
            label1.Text = "Quản lý sản phẩm";
        }
    }
}
