
namespace Presentation.Forms
{
    partial class ProductForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCategory = new System.Windows.Forms.ComboBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.dvgProducts = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtIncrease = new System.Windows.Forms.TextBox();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.txtBrand = new System.Windows.Forms.ComboBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.txtCategoryFilter = new System.Windows.Forms.ComboBox();
            this.txtSupplierFilter = new System.Windows.Forms.ComboBox();
            this.txtBrandFilter = new System.Windows.Forms.ComboBox();
            this.lblCategoryFilter = new System.Windows.Forms.Label();
            this.lblSupplierFilter = new System.Windows.Forms.Label();
            this.lblBrandFilter = new System.Windows.Forms.Label();
            this.txtUsd = new System.Windows.Forms.ComboBox();
            this.lblUsd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(676, 271);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Cargar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCategory
            // 
            this.txtCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtCategory.FormattingEnabled = true;
            this.txtCategory.Location = new System.Drawing.Point(589, 162);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(162, 21);
            this.txtCategory.TabIndex = 8;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(521, 35);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(589, 32);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(162, 20);
            this.txtId.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(589, 84);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(162, 20);
            this.txtDescription.TabIndex = 5;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(589, 136);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(162, 20);
            this.txtPrice.TabIndex = 7;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDecimal_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(521, 87);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Descripcion";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(521, 139);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(37, 13);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "Precio";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(521, 165);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Categoria";
            // 
            // dvgProducts
            // 
            this.dvgProducts.AllowUserToAddRows = false;
            this.dvgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dvgProducts.Location = new System.Drawing.Point(12, 73);
            this.dvgProducts.MultiSelect = false;
            this.dvgProducts.Name = "dvgProducts";
            this.dvgProducts.ReadOnly = true;
            this.dvgProducts.RowHeadersVisible = false;
            this.dvgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgProducts.Size = new System.Drawing.Size(498, 236);
            this.dvgProducts.TabIndex = 0;
            this.dvgProducts.TabStop = false;
            this.dvgProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgProducts_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripcion";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 270;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Marca";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 62;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(435, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(417, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(676, 271);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 12;
            this.btnModify.Text = "Modificar";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(595, 271);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(435, 315);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.TabStop = false;
            this.btnRemove.Text = "Eliminar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(589, 110);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(162, 20);
            this.txtCost.TabIndex = 6;
            this.txtCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDecimal_KeyPress);
            this.txtCost.Leave += new System.EventHandler(this.txtCost_Leave);
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(521, 113);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(34, 13);
            this.lblCosto.TabIndex = 2;
            this.lblCosto.Text = "Costo";
            // 
            // txtSupplier
            // 
            this.txtSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtSupplier.FormattingEnabled = true;
            this.txtSupplier.Location = new System.Drawing.Point(589, 190);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(162, 21);
            this.txtSupplier.TabIndex = 9;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(521, 193);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(56, 13);
            this.lblSupplier.TabIndex = 2;
            this.lblSupplier.Text = "Proveedor";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(521, 61);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(40, 13);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Codigo";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(589, 58);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(162, 20);
            this.txtCode.TabIndex = 4;
            // 
            // txtIncrease
            // 
            this.txtIncrease.Location = new System.Drawing.Point(765, 110);
            this.txtIncrease.Name = "txtIncrease";
            this.txtIncrease.Size = new System.Drawing.Size(58, 20);
            this.txtIncrease.TabIndex = 13;
            this.txtIncrease.TabStop = false;
            this.txtIncrease.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDecimal_KeyPress);
            // 
            // btnIncrease
            // 
            this.btnIncrease.Location = new System.Drawing.Point(829, 108);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(75, 23);
            this.btnIncrease.TabIndex = 14;
            this.btnIncrease.TabStop = false;
            this.btnIncrease.Text = "Subir";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // txtBrand
            // 
            this.txtBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtBrand.FormattingEnabled = true;
            this.txtBrand.Location = new System.Drawing.Point(589, 217);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(162, 21);
            this.txtBrand.TabIndex = 10;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(521, 220);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(37, 13);
            this.lblBrand.TabIndex = 2;
            this.lblBrand.Text = "Marca";
            // 
            // txtCategoryFilter
            // 
            this.txtCategoryFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCategoryFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtCategoryFilter.FormattingEnabled = true;
            this.txtCategoryFilter.Location = new System.Drawing.Point(12, 46);
            this.txtCategoryFilter.Name = "txtCategoryFilter";
            this.txtCategoryFilter.Size = new System.Drawing.Size(162, 21);
            this.txtCategoryFilter.TabIndex = 0;
            this.txtCategoryFilter.TabStop = false;
            // 
            // txtSupplierFilter
            // 
            this.txtSupplierFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSupplierFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtSupplierFilter.FormattingEnabled = true;
            this.txtSupplierFilter.Location = new System.Drawing.Point(180, 46);
            this.txtSupplierFilter.Name = "txtSupplierFilter";
            this.txtSupplierFilter.Size = new System.Drawing.Size(162, 21);
            this.txtSupplierFilter.TabIndex = 0;
            this.txtSupplierFilter.TabStop = false;
            // 
            // txtBrandFilter
            // 
            this.txtBrandFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBrandFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtBrandFilter.FormattingEnabled = true;
            this.txtBrandFilter.Location = new System.Drawing.Point(348, 46);
            this.txtBrandFilter.Name = "txtBrandFilter";
            this.txtBrandFilter.Size = new System.Drawing.Size(162, 21);
            this.txtBrandFilter.TabIndex = 0;
            this.txtBrandFilter.TabStop = false;
            // 
            // lblCategoryFilter
            // 
            this.lblCategoryFilter.AutoSize = true;
            this.lblCategoryFilter.Location = new System.Drawing.Point(12, 31);
            this.lblCategoryFilter.Name = "lblCategoryFilter";
            this.lblCategoryFilter.Size = new System.Drawing.Size(52, 13);
            this.lblCategoryFilter.TabIndex = 2;
            this.lblCategoryFilter.Text = "Categoria";
            // 
            // lblSupplierFilter
            // 
            this.lblSupplierFilter.AutoSize = true;
            this.lblSupplierFilter.Location = new System.Drawing.Point(177, 31);
            this.lblSupplierFilter.Name = "lblSupplierFilter";
            this.lblSupplierFilter.Size = new System.Drawing.Size(56, 13);
            this.lblSupplierFilter.TabIndex = 2;
            this.lblSupplierFilter.Text = "Proveedor";
            // 
            // lblBrandFilter
            // 
            this.lblBrandFilter.AutoSize = true;
            this.lblBrandFilter.Location = new System.Drawing.Point(345, 30);
            this.lblBrandFilter.Name = "lblBrandFilter";
            this.lblBrandFilter.Size = new System.Drawing.Size(37, 13);
            this.lblBrandFilter.TabIndex = 2;
            this.lblBrandFilter.Text = "Marca";
            // 
            // txtUsd
            // 
            this.txtUsd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtUsd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtUsd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtUsd.FormattingEnabled = true;
            this.txtUsd.Items.AddRange(new object[] {
            "NO",
            "SI"});
            this.txtUsd.Location = new System.Drawing.Point(589, 244);
            this.txtUsd.Name = "txtUsd";
            this.txtUsd.Size = new System.Drawing.Size(162, 21);
            this.txtUsd.TabIndex = 11;
            // 
            // lblUsd
            // 
            this.lblUsd.AutoSize = true;
            this.lblUsd.Location = new System.Drawing.Point(521, 247);
            this.lblUsd.Name = "lblUsd";
            this.lblUsd.Size = new System.Drawing.Size(21, 9);
            this.lblUsd.TabIndex = 2;
            this.lblUsd.Text = "Dolar";
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 654);
            this.Controls.Add(this.btnIncrease);
            this.Controls.Add(this.txtIncrease);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dvgProducts);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblBrandFilter);
            this.Controls.Add(this.lblUsd);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblSupplierFilter);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblCategoryFilter);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtBrandFilter);
            this.Controls.Add(this.txtUsd);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.txtSupplierFilter);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtCategoryFilter);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnSave);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox txtCategory;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.DataGridView dvgProducts;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.ComboBox txtSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtIncrease;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.ComboBox txtBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ComboBox txtCategoryFilter;
        private System.Windows.Forms.ComboBox txtSupplierFilter;
        private System.Windows.Forms.ComboBox txtBrandFilter;
        private System.Windows.Forms.Label lblCategoryFilter;
        private System.Windows.Forms.Label lblSupplierFilter;
        private System.Windows.Forms.Label lblBrandFilter;
        private System.Windows.Forms.ComboBox txtUsd;
        private System.Windows.Forms.Label lblUsd;
    }
}