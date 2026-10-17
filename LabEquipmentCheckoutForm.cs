using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class Form2 : Form
    {
        private BindingList<BorrowSlip> slips;
        private BindingSource bindingSource;

        public Form2()
        {
            InitializeComponent();

            slips = new BindingList<BorrowSlip>();
            bindingSource = new BindingSource { DataSource = slips };

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Cấu hình cột DataGridView
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SlipId", HeaderText = "Mã phiếu" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentId", HeaderText = "Mã SV" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentName", HeaderText = "Họ tên SV" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Equipment", HeaderText = "Thiết bị" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Số lượng" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BorrowDate", HeaderText = "Ngày mượn" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DueDate", HeaderText = "Hạn trả" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReturnDate", HeaderText = "Ngày trả" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Tình trạng" });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var slip = new BorrowSlip
            {
                SlipId = txtSlipId.Text.Trim(),
                StudentId = txtStudentId.Text.Trim(),
                StudentName = txtStudentName.Text.Trim(),
                Equipment = cboEquipment.SelectedItem?.ToString(),
                Quantity = (int)numQuantity.Value,
                BorrowDate = dtpBorrowDate.Value,
                DueDate = dtpDueDate.Value,
                ReturnDate = dtpReturnDate.Checked ? dtpReturnDate.Value : (DateTime?)null,
                Status = cboStatus.SelectedItem?.ToString()
            };

            if (slips.Any(s => s.SlipId == slip.SlipId))
            {
                MessageBox.Show("Mã phiếu đã tồn tại!");
                return;
            }

            slips.Add(slip);
            UpdateStatusStrip();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            if (!ValidateInput()) return;

            var selected = (BorrowSlip)dataGridView1.SelectedRows[0].DataBoundItem;
            selected.StudentId = txtStudentId.Text.Trim();
            selected.StudentName = txtStudentName.Text.Trim();
            selected.Equipment = cboEquipment.SelectedItem?.ToString();
            selected.Quantity = (int)numQuantity.Value;
            selected.BorrowDate = dtpBorrowDate.Value;
            selected.DueDate = dtpDueDate.Value;
            selected.ReturnDate = dtpReturnDate.Checked ? dtpReturnDate.Value : (DateTime?)null;
            selected.Status = cboStatus.SelectedItem?.ToString();

            dataGridView1.Refresh();
            UpdateStatusStrip();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var selected = (BorrowSlip)dataGridView1.SelectedRows[0].DataBoundItem;
            var confirm = MessageBox.Show("Xóa phiếu này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                slips.Remove(selected);
                UpdateStatusStrip();
            }
        }

        private bool ValidateInput()
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtSlipId.Text))
            {
                errorProvider1.SetError(txtSlipId, "Mã phiếu bắt buộc");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                errorProvider1.SetError(txtStudentId, "Mã sinh viên bắt buộc");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtStudentName.Text))
            {
                errorProvider1.SetError(txtStudentName, "Tên sinh viên bắt buộc");
                return false;
            }
            if (cboEquipment.SelectedItem == null)
            {
                errorProvider1.SetError(cboEquipment, "Phải chọn thiết bị");
                return false;
            }
            if (numQuantity.Value <= 0)
            {
                errorProvider1.SetError(numQuantity, "Số lượng phải > 0");
                return false;
            }
            if (dtpDueDate.Value < dtpBorrowDate.Value)
            {
                errorProvider1.SetError(dtpDueDate, "Hạn trả không trước ngày mượn");
                return false;
            }
            if (dtpReturnDate.Checked && dtpReturnDate.Value < dtpBorrowDate.Value)
            {
                errorProvider1.SetError(dtpReturnDate, "Ngày trả không trước ngày mượn");
                return false;
            }

            return true;
        }

        private void UpdateStatusStrip()
        {
            int overdueCount = slips.Count(s => s.Status == "Quá hạn");
            statusStrip1.Text = $"Tổng phiếu: {slips.Count} | Quá hạn: {overdueCount}";
        }
    }

    public class BorrowSlip
    {
        public string SlipId { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Equipment { get; set; }
        public int Quantity { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
    }
}
