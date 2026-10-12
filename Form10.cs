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

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Student
        {
            public string StudentId { get; set; }
            public string FullName { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public string AvatarPath { get; set; }
        }
        BindingList<Student> students = new BindingList<Student>();
        BindingSource bindingSource = new BindingSource();

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = students;
            dataGridView1.DataSource = bindingSource;

            // Liên kết dữ liệu 2 chiều
            txtStudentId.DataBindings.Add("Text", bindingSource, "StudentId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("Text", bindingSource, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge.DataBindings.Add("Text", bindingSource, "Age", true, DataSourceUpdateMode.OnPropertyChanged);
            cboGender.DataBindings.Add("Text", bindingSource, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);
            picAvatar.DataBindings.Add("ImageLocation", bindingSource, "AvatarPath", true, DataSourceUpdateMode.OnPropertyChanged);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            students.Add(new Student());
            bindingSource.MoveLast();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bindingSource.RemoveCurrent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bindingSource.ResetCurrentItem();
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
                MessageBox.Show("Xuất CSV thành công!");
            }
        }
    }
}
