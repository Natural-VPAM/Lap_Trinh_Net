using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class TreeViewAndListViewForm : Form
    {
        public TreeViewAndListViewForm()
        {
            InitializeComponent();
        }

        private void TreeViewAndListViewForm_Load(object sender, EventArgs e)
        {
            // Gắn ImageList cho TreeView
            tvDepartments.ImageList = imageList1;

            TreeNode root = new TreeNode("Công ty ABC", 0, 0);
            TreeNode pbIT = new TreeNode("Phòng IT", 1, 1);
            pbIT.Nodes.Add(new TreeNode("Nhóm Lập trình", 2, 2));
            pbIT.Nodes.Add(new TreeNode("Nhóm Hỗ trợ", 2, 2));

            TreeNode pbHR = new TreeNode("Phòng Nhân sự", 1, 1);
            pbHR.Nodes.Add(new TreeNode("Nhóm Tuyển dụng", 2, 2));
            pbHR.Nodes.Add(new TreeNode("Nhóm Đào tạo", 2, 2));

            root.Nodes.Add(pbIT);
            root.Nodes.Add(pbHR);

            tvDepartments.Nodes.Add(root);
            tvDepartments.ExpandAll();

            // Thiết lập chế độ mặc định cho ListView
            lsvEmployees.View = View.Details;
            lsvEmployees.Columns.Add("Mã NV", 80);
            lsvEmployees.Columns.Add("Họ Tên", 150);
            lsvEmployees.Columns.Add("Chức vụ", 120);
            lsvEmployees.Columns.Add("Ngày vào làm", 100);

            cboViewMode.Items.AddRange(new string[] { "Details", "SmallIcon", "LargeIcon", "Tile" });
            cboViewMode.SelectedIndex = 0;
        }

        public class Employee
        {
            public string EmployeeId { get; set; }
            public string FullName { get; set; }
            public string Position { get; set; }
            public DateTime HireDate { get; set; }
        }

        Dictionary<string, List<Employee>> employees = new Dictionary<string, List<Employee>>()
{
    { "Nhóm Lập trình", new List<Employee> {
        new Employee{ EmployeeId="E001", FullName="Nguyễn Văn A", Position="Dev", HireDate=new DateTime(2020,5,1)},
        new Employee{ EmployeeId="E002", FullName="Trần Thị B", Position="Tester", HireDate=new DateTime(2021,3,15)}
    }},
    { "Nhóm Hỗ trợ", new List<Employee> {
        new Employee{ EmployeeId="E003", FullName="Phạm Văn C", Position="Support", HireDate=new DateTime(2019,7,10)}
    }},
    { "Nhóm Tuyển dụng", new List<Employee> {
        new Employee{ EmployeeId="E004", FullName="Lê Thị D", Position="Recruiter", HireDate=new DateTime(2022,1,20)}
    }},
    { "Nhóm Đào tạo", new List<Employee> {
        new Employee{ EmployeeId="E005", FullName="Hoàng Văn E", Position="Trainer", HireDate=new DateTime(2018,11,5)}
    }}
};

        private void tvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lsvEmployees.Items.Clear();
            string nodeName = e.Node.Text;

            if (employees.ContainsKey(nodeName))
            {
                foreach (var emp in employees[nodeName])
                {
                    ListViewItem item = new ListViewItem(emp.EmployeeId);
                    item.SubItems.Add(emp.FullName);
                    item.SubItems.Add(emp.Position);
                    item.SubItems.Add(emp.HireDate.ToShortDateString());
                    item.ImageIndex = 0; // icon từ ImageList
                    lsvEmployees.Items.Add(item);
                }
            }
        }

        private void cboViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboViewMode.SelectedItem.ToString())
            {
                case "Details":
                    lsvEmployees.View = View.Details;
                    break;
                case "SmallIcon":
                    lsvEmployees.View = View.SmallIcon;
                    break;
                case "LargeIcon":
                    lsvEmployees.View = View.LargeIcon;
                    break;
                case "Tile":
                    lsvEmployees.View = View.Tile;
                    break;
            }
        }



    }
}
