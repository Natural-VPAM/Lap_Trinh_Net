using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        private BindingList<Appointment> appointments;
        private BindingSource bindingSource;

        public Form1()
        {
            InitializeComponent();

            appointments = new BindingList<Appointment>();
            bindingSource = new BindingSource { DataSource = appointments };

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ví dụ: thêm cột thủ công
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Mã lịch hẹn"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PatientName",
                HeaderText = "Họ tên"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "SĐT"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AppointmentDate",
                HeaderText = "Ngày giờ"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Doctor",
                HeaderText = "Bác sĩ"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Reason",
                HeaderText = "Lý do khám"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Trạng thái"
            });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var appt = new Appointment
            {
                Id = txtId.Text.Trim(),
                PatientName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                AppointmentDate = dtpDate.Value,
                Doctor = cboDoctor.SelectedItem?.ToString(),
                Reason = txtReason.Text.Trim(),
                Status = cboStatus.SelectedItem?.ToString()
            };

            // Kiểm tra mã lịch hẹn duy nhất
            if (appointments.Any(a => a.Id == appt.Id))
            {
                MessageBox.Show("Mã lịch hẹn đã tồn tại!");
                return;
            }

            appointments.Add(appt);
            UpdateStatusStrip();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            if (!ValidateInput()) return;

            var selected = (Appointment)dataGridView1.SelectedRows[0].DataBoundItem;
            selected.PatientName = txtName.Text.Trim();
            selected.Phone = txtPhone.Text.Trim();
            selected.AppointmentDate = dtpDate.Value;
            selected.Doctor = cboDoctor.SelectedItem?.ToString();
            selected.Reason = txtReason.Text.Trim();
            selected.Status = cboStatus.SelectedItem?.ToString();

            dataGridView1.Refresh();
            UpdateStatusStrip();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var selected = (Appointment)dataGridView1.SelectedRows[0].DataBoundItem;
            var confirm = MessageBox.Show("Xóa lịch hẹn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                appointments.Remove(selected);
                UpdateStatusStrip();
            }
        }

        private bool ValidateInput()
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Tên bệnh nhân bắt buộc");
                return false;
            }

            if (!Regex.IsMatch(txtPhone.Text, @"^\d{9,11}$"))
            {
                errorProvider1.SetError(txtPhone, "Số điện thoại không hợp lệ");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                errorProvider1.SetError(txtReason, "Lý do khám bắt buộc");
                return false;
            }

            if (dtpDate.Value < DateTime.Now)
            {
                errorProvider1.SetError(dtpDate, "Ngày hẹn không được trong quá khứ");
                return false;
            }

            return true;
        }

        private void UpdateStatusStrip()
        {
            toolStripStatusLabel1.Text = $"Số lịch hẹn: {appointments.Count}";
        }

        private void exportCsvMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.Title = "Xuất danh sách lịch hẹn";
                sfd.FileName = "Appointments.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                        {
                            // Ghi dòng tiêu đề
                            sw.WriteLine("Mã lịch hẹn,Họ tên,SĐT,Ngày giờ,Bác sĩ,Lý do khám,Trạng thái");

                            // Ghi dữ liệu từng lịch hẹn
                            foreach (var appt in appointments)
                            {
                                sw.WriteLine($"{appt.Id},{appt.PatientName},{appt.Phone}," +
                                             $"{appt.AppointmentDate},{appt.Doctor},{appt.Reason},{appt.Status}");
                            }
                        }

                        MessageBox.Show("Xuất CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất CSV: " + ex.Message);
                    }
                }
            }
        }


    }

    public class Appointment
    {
        public string Id { get; set; }
        public string PatientName { get; set; }
        public string Phone { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Doctor { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
    }
}
