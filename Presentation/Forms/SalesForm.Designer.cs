
namespace Presentation.Forms
{
    partial class SalesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dvgProducts = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.dvgCart = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblCart = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.txtPriceCart = new System.Windows.Forms.TextBox();
            this.txtQuantityCart = new System.Windows.Forms.TextBox();
            this.btnSell = new System.Windows.Forms.Button();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblClient = new System.Windows.Forms.Label();
            this.btnBudget = new System.Windows.Forms.Button();
            this.lblNameClient = new System.Windows.Forms.Label();
            this.txtNameClient = new System.Windows.Forms.TextBox();
            this.lblBrandFilter = new System.Windows.Forms.Label();
            this.lblSupplierFilter = new System.Windows.Forms.Label();
            this.lblCategoryFilter = new System.Windows.Forms.Label();
            this.txtBrandFilter = new System.Windows.Forms.ComboBox();
            this.txtSupplierFilter = new System.Windows.Forms.ComboBox();
            this.txtCategoryFilter = new System.Windows.Forms.ComboBox();
            this.chkPayment = new System.Windows.Forms.CheckBox();
            this.lblPayment = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.chkClient = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCart)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(446, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_KeyDown);
            // 
            // dvgProducts
            // 
            this.dvgProducts.AllowUserToAddRows = false;
            this.dvgProducts.AllowUserToDeleteRows = false;
            this.dvgProducts.AllowUserToResizeColumns = false;
            this.dvgProducts.AllowUserToResizeRows = false;
            this.dvgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgProducts.DefaultCellStyle = dataGridViewCellStyle10;
            this.dvgProducts.Location = new System.Drawing.Point(12, 78);
            this.dvgProducts.MultiSelect = false;
            this.dvgProducts.Name = "dvgProducts";
            this.dvgProducts.ReadOnly = true;
            this.dvgProducts.RowHeadersVisible = false;
            this.dvgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgProducts.Size = new System.Drawing.Size(527, 236);
            this.dvgProducts.TabIndex = 0;
            this.dvgProducts.TabStop = false;
            this.dvgProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgProducts_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 41;
            // 
            // Column2
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column2.HeaderText = "Descripcion";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 260;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Marca";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 62;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Precio";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 62;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Cantidad";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 74;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(464, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 22);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Location = new System.Drawing.Point(439, 349);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(100, 22);
            this.btnAddToCart.TabIndex = 3;
            this.btnAddToCart.Text = "Agregar";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // dvgCart
            // 
            this.dvgCart.AllowUserToAddRows = false;
            this.dvgCart.AllowUserToDeleteRows = false;
            this.dvgCart.AllowUserToResizeColumns = false;
            this.dvgCart.AllowUserToResizeRows = false;
            this.dvgCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgCart.DefaultCellStyle = dataGridViewCellStyle12;
            this.dvgCart.Location = new System.Drawing.Point(559, 76);
            this.dvgCart.MultiSelect = false;
            this.dvgCart.Name = "dvgCart";
            this.dvgCart.ReadOnly = true;
            this.dvgCart.RowHeadersVisible = false;
            this.dvgCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgCart.Size = new System.Drawing.Size(444, 236);
            this.dvgCart.TabIndex = 23;
            this.dvgCart.TabStop = false;
            this.dvgCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgCart_CellClick);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Id";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 50;
            // 
            // Column7
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column7.HeaderText = "Descripcion";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 210;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Precio";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 50;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Cantidad";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 50;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Subtotal";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 50;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(866, 323);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 24;
            this.lblTotal.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(903, 320);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 25;
            this.txtTotal.TabStop = false;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(439, 323);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDecimal_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(384, 326);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 24;
            this.lblQuantity.Text = "Cantidad";
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Location = new System.Drawing.Point(556, 54);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(37, 13);
            this.lblCart.TabIndex = 24;
            this.lblCart.Text = "Carrito";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(1009, 103);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(62, 22);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Quitar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(1009, 131);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(62, 22);
            this.btnChange.TabIndex = 4;
            this.btnChange.Text = "Cambiar";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtPriceCart
            // 
            this.txtPriceCart.Location = new System.Drawing.Point(817, 51);
            this.txtPriceCart.Name = "txtPriceCart";
            this.txtPriceCart.Size = new System.Drawing.Size(50, 20);
            this.txtPriceCart.TabIndex = 26;
            this.txtPriceCart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPriceCart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDecimal_KeyPress);
            // 
            // txtQuantityCart
            // 
            this.txtQuantityCart.Location = new System.Drawing.Point(871, 51);
            this.txtQuantityCart.Name = "txtQuantityCart";
            this.txtQuantityCart.Size = new System.Drawing.Size(50, 20);
            this.txtQuantityCart.TabIndex = 26;
            this.txtQuantityCart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuantityCart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDecimal_KeyPress);
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(928, 394);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 23);
            this.btnSell.TabIndex = 6;
            this.btnSell.Text = "Vender";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(9, 326);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(35, 13);
            this.lblEmployee.TabIndex = 28;
            this.lblEmployee.Text = "label1";
            // 
            // txtClient
            // 
            this.txtClient.FormattingEnabled = true;
            this.txtClient.Location = new System.Drawing.Point(620, 351);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(142, 21);
            this.txtClient.TabIndex = 4;
            this.txtClient.TextChanged += new System.EventHandler(this.txtClient_TextChanged);
            this.txtClient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInt_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(869, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Imprimir Comprobante";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(565, 354);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 28;
            this.lblClient.Text = "Cliente";
            // 
            // btnBudget
            // 
            this.btnBudget.Location = new System.Drawing.Point(869, 465);
            this.btnBudget.Name = "btnBudget";
            this.btnBudget.Size = new System.Drawing.Size(134, 23);
            this.btnBudget.TabIndex = 27;
            this.btnBudget.Text = "Imprimir Presupuesto";
            this.btnBudget.UseVisualStyleBackColor = true;
            this.btnBudget.Click += new System.EventHandler(this.btnBudget_Click);
            // 
            // lblNameClient
            // 
            this.lblNameClient.AutoSize = true;
            this.lblNameClient.Location = new System.Drawing.Point(565, 393);
            this.lblNameClient.Name = "lblNameClient";
            this.lblNameClient.Size = new System.Drawing.Size(35, 13);
            this.lblNameClient.TabIndex = 24;
            this.lblNameClient.Text = "Name";
            // 
            // txtNameClient
            // 
            this.txtNameClient.Location = new System.Drawing.Point(620, 390);
            this.txtNameClient.Name = "txtNameClient";
            this.txtNameClient.Size = new System.Drawing.Size(142, 20);
            this.txtNameClient.TabIndex = 3;
            this.txtNameClient.TabStop = false;
            // 
            // lblBrandFilter
            // 
            this.lblBrandFilter.AutoSize = true;
            this.lblBrandFilter.Location = new System.Drawing.Point(345, 34);
            this.lblBrandFilter.Name = "lblBrandFilter";
            this.lblBrandFilter.Size = new System.Drawing.Size(37, 13);
            this.lblBrandFilter.TabIndex = 31;
            this.lblBrandFilter.Text = "Marca";
            // 
            // lblSupplierFilter
            // 
            this.lblSupplierFilter.AutoSize = true;
            this.lblSupplierFilter.Location = new System.Drawing.Point(177, 35);
            this.lblSupplierFilter.Name = "lblSupplierFilter";
            this.lblSupplierFilter.Size = new System.Drawing.Size(56, 13);
            this.lblSupplierFilter.TabIndex = 32;
            this.lblSupplierFilter.Text = "Proveedor";
            // 
            // lblCategoryFilter
            // 
            this.lblCategoryFilter.AutoSize = true;
            this.lblCategoryFilter.Location = new System.Drawing.Point(12, 35);
            this.lblCategoryFilter.Name = "lblCategoryFilter";
            this.lblCategoryFilter.Size = new System.Drawing.Size(52, 13);
            this.lblCategoryFilter.TabIndex = 33;
            this.lblCategoryFilter.Text = "Categoria";
            // 
            // txtBrandFilter
            // 
            this.txtBrandFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBrandFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtBrandFilter.FormattingEnabled = true;
            this.txtBrandFilter.Location = new System.Drawing.Point(348, 50);
            this.txtBrandFilter.Name = "txtBrandFilter";
            this.txtBrandFilter.Size = new System.Drawing.Size(162, 21);
            this.txtBrandFilter.TabIndex = 35;
            this.txtBrandFilter.TabStop = false;
            // 
            // txtSupplierFilter
            // 
            this.txtSupplierFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSupplierFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtSupplierFilter.FormattingEnabled = true;
            this.txtSupplierFilter.Location = new System.Drawing.Point(180, 50);
            this.txtSupplierFilter.Name = "txtSupplierFilter";
            this.txtSupplierFilter.Size = new System.Drawing.Size(162, 21);
            this.txtSupplierFilter.TabIndex = 36;
            this.txtSupplierFilter.TabStop = false;
            // 
            // txtCategoryFilter
            // 
            this.txtCategoryFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCategoryFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtCategoryFilter.FormattingEnabled = true;
            this.txtCategoryFilter.Location = new System.Drawing.Point(12, 50);
            this.txtCategoryFilter.Name = "txtCategoryFilter";
            this.txtCategoryFilter.Size = new System.Drawing.Size(162, 21);
            this.txtCategoryFilter.TabIndex = 34;
            this.txtCategoryFilter.TabStop = false;
            // 
            // chkPayment
            // 
            this.chkPayment.AutoSize = true;
            this.chkPayment.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPayment.Enabled = false;
            this.chkPayment.Location = new System.Drawing.Point(937, 346);
            this.chkPayment.Name = "chkPayment";
            this.chkPayment.Size = new System.Drawing.Size(66, 17);
            this.chkPayment.TabIndex = 37;
            this.chkPayment.Text = "Contado";
            this.chkPayment.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkPayment.UseVisualStyleBackColor = true;
            this.chkPayment.CheckedChanged += new System.EventHandler(this.chkPayment_CheckedChanged);
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Location = new System.Drawing.Point(857, 371);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(44, 13);
            this.lblPayment.TabIndex = 24;
            this.lblPayment.Text = "Entrega";
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(903, 368);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(100, 20);
            this.txtPayment.TabIndex = 5;
            this.txtPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDecimal_KeyPress);
            // 
            // chkClient
            // 
            this.chkClient.AutoSize = true;
            this.chkClient.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkClient.Location = new System.Drawing.Point(568, 319);
            this.chkClient.Name = "chkClient";
            this.chkClient.Size = new System.Drawing.Size(106, 17);
            this.chkClient.TabIndex = 38;
            this.chkClient.Text = "Consumidor Final";
            this.chkClient.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkClient.UseVisualStyleBackColor = true;
            this.chkClient.CheckedChanged += new System.EventHandler(this.chkClient_CheckedChanged);
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 490);
            this.Controls.Add(this.chkClient);
            this.Controls.Add(this.chkPayment);
            this.Controls.Add(this.lblBrandFilter);
            this.Controls.Add(this.lblSupplierFilter);
            this.Controls.Add(this.lblCategoryFilter);
            this.Controls.Add(this.txtBrandFilter);
            this.Controls.Add(this.txtSupplierFilter);
            this.Controls.Add(this.txtCategoryFilter);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.btnBudget);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.txtQuantityCart);
            this.Controls.Add(this.txtPriceCart);
            this.Controls.Add(this.txtNameClient);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblNameClient);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblPayment);
            this.Controls.Add(this.lblCart);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dvgCart);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dvgProducts);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.btnSearch);
            this.Name = "SalesForm";
            this.Text = "SalesForm";
            this.Load += new System.EventHandler(this.SalesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dvgProducts;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.DataGridView dvgCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.TextBox txtPriceCart;
        private System.Windows.Forms.TextBox txtQuantityCart;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox txtClient;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Button btnBudget;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Label lblNameClient;
        private System.Windows.Forms.TextBox txtNameClient;
        private System.Windows.Forms.Label lblBrandFilter;
        private System.Windows.Forms.Label lblSupplierFilter;
        private System.Windows.Forms.Label lblCategoryFilter;
        private System.Windows.Forms.ComboBox txtBrandFilter;
        private System.Windows.Forms.ComboBox txtSupplierFilter;
        private System.Windows.Forms.ComboBox txtCategoryFilter;
        private System.Windows.Forms.CheckBox chkPayment;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.CheckBox chkClient;
    }
}