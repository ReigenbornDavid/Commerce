
namespace Presentation.Forms
{
    partial class ClientForm
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dvgClients = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgClients)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(269, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dvgClients
            // 
            this.dvgClients.AllowUserToAddRows = false;
            this.dvgClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dvgClients.Location = new System.Drawing.Point(12, 39);
            this.dvgClients.MultiSelect = false;
            this.dvgClients.Name = "dvgClients";
            this.dvgClients.ReadOnly = true;
            this.dvgClients.RowHeadersVisible = false;
            this.dvgClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgClients.Size = new System.Drawing.Size(430, 236);
            this.dvgClients.TabIndex = 13;
            this.dvgClients.TabStop = false;
            this.dvgClients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgClients_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Apellido";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Nombre";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(516, 62);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(162, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(516, 114);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(162, 20);
            this.txtAddress.TabIndex = 5;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(516, 88);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(162, 20);
            this.txtFirstName.TabIndex = 4;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(516, 36);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(162, 20);
            this.txtId.TabIndex = 2;
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInt_KeyPress);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(448, 91);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(44, 13);
            this.lblFirstName.TabIndex = 20;
            this.lblFirstName.Text = "Nombre";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(448, 117);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(52, 13);
            this.lblAddress.TabIndex = 18;
            this.lblAddress.Text = "Direccion";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(448, 65);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(44, 13);
            this.lblLastName.TabIndex = 17;
            this.lblLastName.Text = "Apellido";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(448, 39);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(26, 13);
            this.lblId.TabIndex = 16;
            this.lblId.Text = "DNI";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(287, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(367, 281);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 31;
            this.btnRemove.TabStop = false;
            this.btnRemove.Text = "Eliminar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(516, 192);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 30;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(603, 192);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "Modificar";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(603, 192);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Cargar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(516, 140);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(162, 20);
            this.txtTel.TabIndex = 6;
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(448, 143);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(49, 13);
            this.lblTel.TabIndex = 32;
            this.lblTel.Text = "Telefono";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(448, 169);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(51, 13);
            this.lblBalance.TabIndex = 32;
            this.lblBalance.Text = "Balances";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(516, 166);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(162, 20);
            this.txtBalance.TabIndex = 6;
            this.txtBalance.TabStop = false;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 340);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dvgClients);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnSave);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dvgClients;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox txtBalance;
    }
}