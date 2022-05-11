
namespace Presentation.Forms
{
    partial class IncreasesForm
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
            this.txtSearchCategory = new System.Windows.Forms.TextBox();
            this.dvgCategories = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearchCategory = new System.Windows.Forms.Button();
            this.txtSearchSupplier = new System.Windows.Forms.TextBox();
            this.dvgSuppliers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearchSupplier = new System.Windows.Forms.Button();
            this.txtSearchBrand = new System.Windows.Forms.TextBox();
            this.dvgBrands = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearchBrand = new System.Windows.Forms.Button();
            this.chkCost = new System.Windows.Forms.CheckBox();
            this.chkPrice = new System.Windows.Forms.CheckBox();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtIdCategory = new System.Windows.Forms.TextBox();
            this.txtIdSupplier = new System.Windows.Forms.TextBox();
            this.txtIdBrand = new System.Windows.Forms.TextBox();
            this.txtNameCategory = new System.Windows.Forms.TextBox();
            this.txtNameSupplier = new System.Windows.Forms.TextBox();
            this.txtNameBrand = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.txtIncrease = new System.Windows.Forms.TextBox();
            this.lblIncrease = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dvgProducts = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCont = new System.Windows.Forms.TextBox();
            this.lblCont = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgSuppliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgBrands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchCategory
            // 
            this.txtSearchCategory.Location = new System.Drawing.Point(12, 39);
            this.txtSearchCategory.Name = "txtSearchCategory";
            this.txtSearchCategory.Size = new System.Drawing.Size(269, 20);
            this.txtSearchCategory.TabIndex = 17;
            this.txtSearchCategory.TextChanged += new System.EventHandler(this.txtSearchCategory_TextChanged);
            // 
            // dvgCategories
            // 
            this.dvgCategories.AllowUserToAddRows = false;
            this.dvgCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dvgCategories.Location = new System.Drawing.Point(12, 66);
            this.dvgCategories.MultiSelect = false;
            this.dvgCategories.Name = "dvgCategories";
            this.dvgCategories.ReadOnly = true;
            this.dvgCategories.RowHeadersVisible = false;
            this.dvgCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgCategories.Size = new System.Drawing.Size(350, 190);
            this.dvgCategories.TabIndex = 16;
            this.dvgCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgCategories_CellClick);
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
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 270;
            // 
            // btnSearchCategory
            // 
            this.btnSearchCategory.Location = new System.Drawing.Point(287, 37);
            this.btnSearchCategory.Name = "btnSearchCategory";
            this.btnSearchCategory.Size = new System.Drawing.Size(75, 23);
            this.btnSearchCategory.TabIndex = 18;
            this.btnSearchCategory.Text = "Buscar";
            this.btnSearchCategory.UseVisualStyleBackColor = true;
            this.btnSearchCategory.Click += new System.EventHandler(this.btnSearchCategory_Click);
            // 
            // txtSearchSupplier
            // 
            this.txtSearchSupplier.Location = new System.Drawing.Point(724, 39);
            this.txtSearchSupplier.Name = "txtSearchSupplier";
            this.txtSearchSupplier.Size = new System.Drawing.Size(269, 20);
            this.txtSearchSupplier.TabIndex = 20;
            this.txtSearchSupplier.TextChanged += new System.EventHandler(this.txtSearchSupplier_TextChanged);
            // 
            // dvgSuppliers
            // 
            this.dvgSuppliers.AllowUserToAddRows = false;
            this.dvgSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgSuppliers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dvgSuppliers.Location = new System.Drawing.Point(724, 66);
            this.dvgSuppliers.MultiSelect = false;
            this.dvgSuppliers.Name = "dvgSuppliers";
            this.dvgSuppliers.ReadOnly = true;
            this.dvgSuppliers.RowHeadersVisible = false;
            this.dvgSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgSuppliers.Size = new System.Drawing.Size(350, 190);
            this.dvgSuppliers.TabIndex = 19;
            this.dvgSuppliers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgSuppliers_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 270;
            // 
            // btnSearchSupplier
            // 
            this.btnSearchSupplier.Location = new System.Drawing.Point(999, 37);
            this.btnSearchSupplier.Name = "btnSearchSupplier";
            this.btnSearchSupplier.Size = new System.Drawing.Size(75, 23);
            this.btnSearchSupplier.TabIndex = 21;
            this.btnSearchSupplier.Text = "Buscar";
            this.btnSearchSupplier.UseVisualStyleBackColor = true;
            this.btnSearchSupplier.Click += new System.EventHandler(this.btnSearchSupplier_Click);
            // 
            // txtSearchBrand
            // 
            this.txtSearchBrand.Location = new System.Drawing.Point(368, 39);
            this.txtSearchBrand.Name = "txtSearchBrand";
            this.txtSearchBrand.Size = new System.Drawing.Size(269, 20);
            this.txtSearchBrand.TabIndex = 23;
            this.txtSearchBrand.TextChanged += new System.EventHandler(this.txtSearchBrand_TextChanged);
            // 
            // dvgBrands
            // 
            this.dvgBrands.AllowUserToAddRows = false;
            this.dvgBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgBrands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dvgBrands.Location = new System.Drawing.Point(368, 65);
            this.dvgBrands.MultiSelect = false;
            this.dvgBrands.Name = "dvgBrands";
            this.dvgBrands.ReadOnly = true;
            this.dvgBrands.RowHeadersVisible = false;
            this.dvgBrands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgBrands.Size = new System.Drawing.Size(350, 190);
            this.dvgBrands.TabIndex = 22;
            this.dvgBrands.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgBrands_CellClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Id";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 270;
            // 
            // btnSearchBrand
            // 
            this.btnSearchBrand.Location = new System.Drawing.Point(643, 37);
            this.btnSearchBrand.Name = "btnSearchBrand";
            this.btnSearchBrand.Size = new System.Drawing.Size(75, 23);
            this.btnSearchBrand.TabIndex = 24;
            this.btnSearchBrand.Text = "Buscar";
            this.btnSearchBrand.UseVisualStyleBackColor = true;
            this.btnSearchBrand.Click += new System.EventHandler(this.btnSearchBrand_Click);
            // 
            // chkCost
            // 
            this.chkCost.AutoSize = true;
            this.chkCost.Location = new System.Drawing.Point(767, 375);
            this.chkCost.Name = "chkCost";
            this.chkCost.Size = new System.Drawing.Size(53, 17);
            this.chkCost.TabIndex = 25;
            this.chkCost.Text = "Costo";
            this.chkCost.UseVisualStyleBackColor = true;
            // 
            // chkPrice
            // 
            this.chkPrice.AutoSize = true;
            this.chkPrice.Location = new System.Drawing.Point(767, 398);
            this.chkPrice.Name = "chkPrice";
            this.chkPrice.Size = new System.Drawing.Size(56, 17);
            this.chkPrice.TabIndex = 25;
            this.chkPrice.Text = "Precio";
            this.chkPrice.UseVisualStyleBackColor = true;
            // 
            // btnIncrease
            // 
            this.btnIncrease.Location = new System.Drawing.Point(734, 445);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(86, 23);
            this.btnIncrease.TabIndex = 26;
            this.btnIncrease.Text = "Aumentar";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(467, 300);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 27;
            this.lblCategory.Text = "Categoria";
            // 
            // txtIdCategory
            // 
            this.txtIdCategory.Location = new System.Drawing.Point(529, 297);
            this.txtIdCategory.Name = "txtIdCategory";
            this.txtIdCategory.Size = new System.Drawing.Size(40, 20);
            this.txtIdCategory.TabIndex = 28;
            // 
            // txtIdSupplier
            // 
            this.txtIdSupplier.Location = new System.Drawing.Point(529, 349);
            this.txtIdSupplier.Name = "txtIdSupplier";
            this.txtIdSupplier.Size = new System.Drawing.Size(40, 20);
            this.txtIdSupplier.TabIndex = 28;
            // 
            // txtIdBrand
            // 
            this.txtIdBrand.Location = new System.Drawing.Point(529, 323);
            this.txtIdBrand.Name = "txtIdBrand";
            this.txtIdBrand.Size = new System.Drawing.Size(40, 20);
            this.txtIdBrand.TabIndex = 28;
            // 
            // txtNameCategory
            // 
            this.txtNameCategory.Location = new System.Drawing.Point(575, 297);
            this.txtNameCategory.Name = "txtNameCategory";
            this.txtNameCategory.Size = new System.Drawing.Size(245, 20);
            this.txtNameCategory.TabIndex = 28;
            // 
            // txtNameSupplier
            // 
            this.txtNameSupplier.Location = new System.Drawing.Point(575, 349);
            this.txtNameSupplier.Name = "txtNameSupplier";
            this.txtNameSupplier.Size = new System.Drawing.Size(245, 20);
            this.txtNameSupplier.TabIndex = 28;
            // 
            // txtNameBrand
            // 
            this.txtNameBrand.Location = new System.Drawing.Point(575, 323);
            this.txtNameBrand.Name = "txtNameBrand";
            this.txtNameBrand.Size = new System.Drawing.Size(245, 20);
            this.txtNameBrand.TabIndex = 28;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(467, 352);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(56, 13);
            this.lblSupplier.TabIndex = 27;
            this.lblSupplier.Text = "Proveedor";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(467, 326);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(37, 13);
            this.lblBrand.TabIndex = 27;
            this.lblBrand.Text = "Marca";
            // 
            // txtIncrease
            // 
            this.txtIncrease.Location = new System.Drawing.Point(643, 419);
            this.txtIncrease.Name = "txtIncrease";
            this.txtIncrease.Size = new System.Drawing.Size(72, 20);
            this.txtIncrease.TabIndex = 28;
            this.txtIncrease.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDecimal_KeyPress);
            // 
            // lblIncrease
            // 
            this.lblIncrease.AutoSize = true;
            this.lblIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncrease.Location = new System.Drawing.Point(721, 420);
            this.lblIncrease.Name = "lblIncrease";
            this.lblIncrease.Size = new System.Drawing.Size(21, 16);
            this.lblIncrease.TabIndex = 27;
            this.lblIncrease.Text = "%";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(643, 445);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 23);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "CATEGORIA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "MARCA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(721, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "PROVEEDOR";
            // 
            // dvgProducts
            // 
            this.dvgProducts.AllowUserToAddRows = false;
            this.dvgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dvgProducts.Location = new System.Drawing.Point(12, 300);
            this.dvgProducts.MultiSelect = false;
            this.dvgProducts.Name = "dvgProducts";
            this.dvgProducts.ReadOnly = true;
            this.dvgProducts.RowHeadersVisible = false;
            this.dvgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgProducts.Size = new System.Drawing.Size(350, 190);
            this.dvgProducts.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.HeaderText = "Id";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 41;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 270;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(287, 271);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCont
            // 
            this.txtCont.Location = new System.Drawing.Point(67, 498);
            this.txtCont.Name = "txtCont";
            this.txtCont.Size = new System.Drawing.Size(72, 20);
            this.txtCont.TabIndex = 28;
            // 
            // lblCont
            // 
            this.lblCont.AutoSize = true;
            this.lblCont.Location = new System.Drawing.Point(12, 501);
            this.lblCont.Name = "lblCont";
            this.lblCont.Size = new System.Drawing.Size(49, 13);
            this.lblCont.TabIndex = 27;
            this.lblCont.Text = "Cantidad";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(287, 496);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 30;
            this.btnRemove.Text = "Eliminar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // IncreasesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 591);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNameBrand);
            this.Controls.Add(this.txtCont);
            this.Controls.Add(this.txtIncrease);
            this.Controls.Add(this.txtNameSupplier);
            this.Controls.Add(this.txtNameCategory);
            this.Controls.Add(this.txtIdBrand);
            this.Controls.Add(this.txtIdSupplier);
            this.Controls.Add(this.txtIdCategory);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblIncrease);
            this.Controls.Add(this.lblCont);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnIncrease);
            this.Controls.Add(this.chkPrice);
            this.Controls.Add(this.chkCost);
            this.Controls.Add(this.txtSearchBrand);
            this.Controls.Add(this.dvgBrands);
            this.Controls.Add(this.btnSearchBrand);
            this.Controls.Add(this.txtSearchSupplier);
            this.Controls.Add(this.dvgSuppliers);
            this.Controls.Add(this.btnSearchSupplier);
            this.Controls.Add(this.txtSearchCategory);
            this.Controls.Add(this.dvgProducts);
            this.Controls.Add(this.dvgCategories);
            this.Controls.Add(this.btnSearchCategory);
            this.Name = "IncreasesForm";
            this.Text = "FormAumentos";
            this.Load += new System.EventHandler(this.FormIncreases_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgSuppliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgBrands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchCategory;
        private System.Windows.Forms.DataGridView dvgCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnSearchCategory;
        private System.Windows.Forms.TextBox txtSearchSupplier;
        private System.Windows.Forms.DataGridView dvgSuppliers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnSearchSupplier;
        private System.Windows.Forms.TextBox txtSearchBrand;
        private System.Windows.Forms.DataGridView dvgBrands;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnSearchBrand;
        private System.Windows.Forms.CheckBox chkCost;
        private System.Windows.Forms.CheckBox chkPrice;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtIdCategory;
        private System.Windows.Forms.TextBox txtIdSupplier;
        private System.Windows.Forms.TextBox txtIdBrand;
        private System.Windows.Forms.TextBox txtNameCategory;
        private System.Windows.Forms.TextBox txtNameSupplier;
        private System.Windows.Forms.TextBox txtNameBrand;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox txtIncrease;
        private System.Windows.Forms.Label lblIncrease;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dvgProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCont;
        private System.Windows.Forms.Label lblCont;
        private System.Windows.Forms.Button btnRemove;
    }
}