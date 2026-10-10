using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public class Product
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public string Category { get; set; }
        }

        List<Product> products = new List<Product>();
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            bs.DataSource = products;
            dgvProducts.DataSource = bs;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product p = new Product()
            {
                ProductId = txtProductId.Text,
                ProductName = txtProductName.Text,
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                Quantity = int.Parse(txtQuantity.Text),
                Category = txtCategory.Text
            };

            products.Add(p);
            bs.ResetBindings(false); // Làm mới DataGridView
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Product p = products[e.RowIndex];
                txtProductId.Text = p.ProductId;
                txtProductName.Text = p.ProductName;
                txtUnitPrice.Text = p.UnitPrice.ToString();
                txtQuantity.Text = p.Quantity.ToString();
                txtCategory.Text = p.Category;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                int index = dgvProducts.CurrentRow.Index;
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?",
                                                      "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    products.RemoveAt(index);
                    bs.ResetBindings(false);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                int index = dgvProducts.CurrentRow.Index;
                Product p = products[index];
                p.ProductId = txtProductId.Text;
                p.ProductName = txtProductName.Text;
                p.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                p.Quantity = int.Parse(txtQuantity.Text);
                p.Category = txtCategory.Text;

                bs.ResetBindings(false);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();
            var result = products.Where(p => p.ProductName.ToLower().Contains(keyword)).ToList();

            bs.DataSource = result;
            dgvProducts.DataSource = bs;
        }
    }
}
