using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class ListBoxAndComboBoxForm : Form
    {
        Dictionary<string, List<(string, int)>> services = new Dictionary<string, List<(string, int)>>()
        {
            { "Khám bệnh", new List<(string, int)> { ("Khám tổng quát", 100000), ("Khám chuyên khoa", 150000) } },
            { "Xét nghiệm", new List<(string, int)> { ("Xét nghiệm máu", 200000), ("Xét nghiệm nước tiểu", 120000) } },
            { "Chụp X-Quang", new List<(string, int)> { ("X-Quang ngực", 250000), ("X-Quang xương", 300000) } },
            { "Vắc-xin", new List<(string, int)> { ("Vắc-xin cúm", 400000), ("Vắc-xin viêm gan B", 500000) } }
        };

        public ListBoxAndComboBoxForm()
        {
            InitializeComponent();
        }

        private void ListBoxAndComboBoxForm_Load(object sender, EventArgs e)
        {
            // Load loại dịch vụ vào ComboBox
            cboCategory.Items.AddRange(new string[] { "Khám bệnh", "Xét nghiệm", "Chụp X-Quang", "Vắc-xin" });
            cboCategory.SelectedIndex = 0;
        }
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAvailableServices.Items.Clear();
            string category = cboCategory.SelectedItem.ToString();
            foreach (var item in services[category])
            {
                lstAvailableServices.Items.Add($"{item.Item1} - {item.Item2} VND");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstAvailableServices.SelectedItem != null)
            {
                lstSelectedServices.Items.Add(lstAvailableServices.SelectedItem);
                CalculateTotal();
            }
        }

        private void lstAvailableServices_DoubleClick(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelectedServices.SelectedItem != null)
            {
                lstSelectedServices.Items.Remove(lstSelectedServices.SelectedItem);
                CalculateTotal();
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            lstSelectedServices.Items.Clear();
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            int total = 0;
            foreach (string item in lstSelectedServices.Items)
            {
                string[] parts = item.Split('-');
                int price = int.Parse(parts[1].Replace("VND", "").Trim());
                total += price;
            }

            txtTotal.Text = total.ToString();

            int discountPercent = 0;
            if (!string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                int.TryParse(txtDiscount.Text, out discountPercent);
            }

            int final = total - (total * discountPercent / 100);
            txtFinal.Text = final.ToString();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }
    }
}
