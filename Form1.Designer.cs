using System.Windows.Forms;

namespace WindowsFormsApp8
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.GroupBox groupBoxFunctions;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvProducts;

        private void InitializeComponent()
        {
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.groupBoxFunctions = new System.Windows.Forms.GroupBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblProductId = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();

            // groupBoxInfo
            this.groupBoxInfo.Text = "Thông tin sản phẩm";
            this.groupBoxInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInfo.Size = new System.Drawing.Size(400, 200);

            // Labels
            this.lblProductId.Text = "Mã SP:";
            this.lblProductId.Location = new System.Drawing.Point(20, 30);

            this.lblProductName.Text = "Tên SP:";
            this.lblProductName.Location = new System.Drawing.Point(20, 60);

            this.lblUnitPrice.Text = "Đơn giá:";
            this.lblUnitPrice.Location = new System.Drawing.Point(20, 90);

            this.lblQuantity.Text = "Số lượng:";
            this.lblQuantity.Location = new System.Drawing.Point(20, 120);

            this.lblCategory.Text = "Danh mục:";
            this.lblCategory.Location = new System.Drawing.Point(20, 150);

            // TextBoxes
            this.txtProductId.Location = new System.Drawing.Point(100, 30);
            this.txtProductName.Location = new System.Drawing.Point(100, 60);
            this.txtUnitPrice.Location = new System.Drawing.Point(100, 90);
            this.txtQuantity.Location = new System.Drawing.Point(100, 120);
            this.txtCategory.Location = new System.Drawing.Point(100, 150);

            // Add controls to groupBoxInfo
            this.groupBoxInfo.Controls.AddRange(new Control[] {
        lblProductId, txtProductId,
        lblProductName, txtProductName,
        lblUnitPrice, txtUnitPrice,
        lblQuantity, txtQuantity,
        lblCategory, txtCategory
    });

            // groupBoxFunctions
            this.groupBoxFunctions.Text = "Chức năng";
            this.groupBoxFunctions.Location = new System.Drawing.Point(430, 12);
            this.groupBoxFunctions.Size = new System.Drawing.Size(250, 200);

            // Buttons
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Location = new System.Drawing.Point(20, 30);

            this.btnEdit.Text = "Sửa";
            this.btnEdit.Location = new System.Drawing.Point(120, 30);

            this.btnDelete.Text = "Xóa";
            this.btnDelete.Location = new System.Drawing.Point(20, 70);

            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Location = new System.Drawing.Point(20, 110);

            this.txtSearch.Location = new System.Drawing.Point(120, 110);
            this.txtSearch.Width = 100;

            // Add controls to groupBoxFunctions
            this.groupBoxFunctions.Controls.AddRange(new Control[] {
        btnAdd, btnEdit, btnDelete, btnSearch, txtSearch
    });

            // DataGridView
            this.dgvProducts.Location = new System.Drawing.Point(12, 220);
            this.dgvProducts.Size = new System.Drawing.Size(668, 200);
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Form
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(groupBoxInfo);
            this.Controls.Add(groupBoxFunctions);
            this.Controls.Add(dgvProducts);
            this.Text = "Quản lý sản phẩm";
        }
    }
}

