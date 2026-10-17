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

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        public class RepairOrder
        {
            public string OrderId { get; set; }
            public string CustomerName { get; set; }
            public string Phone { get; set; }
            public string DeviceType { get; set; }
            public string ErrorDescription { get; set; }
            public DateTime ReceivedDate { get; set; }
            public decimal EstimatedCost { get; set; }
            public string Status { get; set; }
            public string ImagePath { get; set; }
        }

        BindingList<RepairOrder> orders = new BindingList<RepairOrder>();
        BindingSource source = new BindingSource();

        public Form1()
        {
            InitializeComponent();

            source.DataSource = orders;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = source;

            // Định nghĩa cột
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "OrderId",
                HeaderText = "Mã đơn"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CustomerName",
                HeaderText = "Khách hàng"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Phone",
                HeaderText = "SĐT"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DeviceType",
                HeaderText = "Thiết bị"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ReceivedDate",
                HeaderText = "Ngày tiếp nhận"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "EstimatedCost",
                HeaderText = "Chi phí dự kiến",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Status",
                HeaderText = "Trạng thái"
            });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu bằng ErrorProvider trước
            if (!ValidateForm()) return;

            var order = new RepairOrder
            {
                OrderId = txtOrderId.Text,
                CustomerName = txtCustomerName.Text,
                Phone = txtPhone.Text,
                DeviceType = cboDeviceType.SelectedItem?.ToString(),
                ErrorDescription = txtError.Text,
                ReceivedDate = dtpReceived.Value,
                EstimatedCost = decimal.Parse(txtCost.Text),
                Status = cboStatus.SelectedItem?.ToString(),
                ImagePath = pictureBox1.ImageLocation
            };

            // Kiểm tra mã đơn trùng
            if (orders.Any(o => o.OrderId == order.OrderId))
            {
                MessageBox.Show("Mã đơn đã tồn tại!");
                return;
            }

            orders.Add(order);
            UpdateStatusStrip();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();
            source.DataSource = orders.Where(o =>
                o.OrderId.ToLower().Contains(keyword) ||
                o.CustomerName.ToLower().Contains(keyword) ||
                o.Phone.ToLower().Contains(keyword)).ToList();
        }

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = cboFilterStatus.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(status))
                source.DataSource = orders;
            else
                source.DataSource = orders.Where(o => o.Status == status).ToList();

            UpdateStatusStrip();
        }

        private void UpdateStatusStrip()
        {
            int count = source.Count;
            decimal total = orders.Where(o => o.Status != "Hoàn tất" && o.Status != "Đã hủy")
                                  .Sum(o => o.EstimatedCost);

            toolStripStatusLabel1.Text = $"Số đơn: {count}";
            toolStripStatusLabel2.Text = $"Tổng chi phí dự kiến: {total:N0}";
        }

        private void menuExportCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            sfd.Title = "Xuất danh sách đơn ra CSV";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    // Ghi header
                    sw.WriteLine("Mã đơn,Tên khách hàng,SĐT,Thiết bị,Mô tả lỗi,Ngày tiếp nhận,Chi phí dự kiến,Trạng thái");

                    // Ghi dữ liệu
                    foreach (RepairOrder order in source.List)
                    {
                        sw.WriteLine($"{order.OrderId}," +
                                     $"{order.CustomerName}," +
                                     $"{order.Phone}," +
                                     $"{order.DeviceType}," +
                                     $"{order.ErrorDescription}," +
                                     $"{order.ReceivedDate:yyyy-MM-dd}," +
                                     $"{order.EstimatedCost}," +
                                     $"{order.Status}");
                    }
                }

                MessageBox.Show("Xuất CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateForm()
        {
            bool valid = true;
            errorProvider1.Clear();

            // Mã đơn không để trống
            if (string.IsNullOrWhiteSpace(txtOrderId.Text))
            {
                errorProvider1.SetError(txtOrderId, "Mã đơn bắt buộc");
                valid = false;
            }

            // Tên khách hàng không để trống
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                errorProvider1.SetError(txtCustomerName, "Tên khách hàng bắt buộc");
                valid = false;
            }

            // Số điện thoại không để trống
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "Số điện thoại bắt buộc");
                valid = false;
            }

            // Mô tả lỗi bắt buộc
            if (string.IsNullOrWhiteSpace(txtError.Text))
            {
                errorProvider1.SetError(txtError, "Phải nhập mô tả lỗi");
                valid = false;
            }

            // Chi phí dự kiến phải là số không âm
            if (!decimal.TryParse(txtCost.Text, out decimal cost) || cost < 0)
            {
                errorProvider1.SetError(txtCost, "Chi phí phải là số ≥ 0");
                valid = false;
            }

            return valid;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
