
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.txtClient = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCart)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(324, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgProducts.DefaultCellStyle = dataGridViewCellStyle6;
            this.dvgProducts.Location = new System.Drawing.Point(12, 39);
            this.dvgProducts.MultiSelect = false;
            this.dvgProducts.Name = "dvgProducts";
            this.dvgProducts.ReadOnly = true;
            this.dvgProducts.RowHeadersVisible = false;
            this.dvgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgProducts.Size = new System.Drawing.Size(405, 236);
            this.dvgProducts.TabIndex = 0;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column2.HeaderText = "Descripcion";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 140;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Costo";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 59;
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
            this.btnSearch.Location = new System.Drawing.Point(342, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 22);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Location = new System.Drawing.Point(317, 309);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(100, 22);
            this.btnAddToCart.TabIndex = 4;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgCart.DefaultCellStyle = dataGridViewCellStyle8;
            this.dvgCart.Location = new System.Drawing.Point(467, 39);
            this.dvgCart.MultiSelect = false;
            this.dvgCart.Name = "dvgCart";
            this.dvgCart.ReadOnly = true;
            this.dvgCart.RowHeadersVisible = false;
            this.dvgCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgCart.Size = new System.Drawing.Size(370, 236);
            this.dvgCart.TabIndex = 23;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column7.HeaderText = "Descripcion";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 140;
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
            this.lblTotal.Location = new System.Drawing.Point(700, 286);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 24;
            this.lblTotal.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(737, 283);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 25;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(317, 283);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 3;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInt_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(262, 286);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 24;
            this.lblQuantity.Text = "Cantidad";
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Location = new System.Drawing.Point(464, 15);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(37, 13);
            this.lblCart.TabIndex = 24;
            this.lblCart.Text = "Carrito";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(843, 39);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(62, 22);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Quitar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(843, 67);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(62, 22);
            this.btnChange.TabIndex = 4;
            this.btnChange.Text = "Cambiar";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtPriceCart
            // 
            this.txtPriceCart.Location = new System.Drawing.Point(658, 15);
            this.txtPriceCart.Name = "txtPriceCart";
            this.txtPriceCart.Size = new System.Drawing.Size(50, 20);
            this.txtPriceCart.TabIndex = 26;
            this.txtPriceCart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtQuantityCart
            // 
            this.txtQuantityCart.Location = new System.Drawing.Point(709, 15);
            this.txtQuantityCart.Name = "txtQuantityCart";
            this.txtQuantityCart.Size = new System.Drawing.Size(50, 20);
            this.txtQuantityCart.TabIndex = 26;
            this.txtQuantityCart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(762, 309);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 23);
            this.btnSell.TabIndex = 27;
            this.btnSell.Text = "Confirmar";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(13, 326);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(35, 13);
            this.lblEmployee.TabIndex = 28;
            this.lblEmployee.Text = "label1";
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(467, 286);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(100, 20);
            this.txtClient.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(592, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 367);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.txtQuantityCart);
            this.Controls.Add(this.txtPriceCart);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblQuantity);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.DataGridView dvgCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
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
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Button button1;
    }
}