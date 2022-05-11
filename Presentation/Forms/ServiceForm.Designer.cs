
namespace Presentation.Forms
{
    partial class ServiceForm
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
            this.lblClient = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dvgServices = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.txtStateFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgServices)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(587, 275);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "Cargar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(420, 150);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 39;
            this.lblClient.Text = "Cliente";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(418, 61);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(45, 13);
            this.lblDetails.TabIndex = 39;
            this.lblDetails.Text = "Detalles";
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(487, 58);
            this.txtDetails.MaxLength = 200;
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(175, 83);
            this.txtDetails.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(418, 229);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 13);
            this.lblDate.TabIndex = 39;
            this.lblDate.Text = "Fecha";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(487, 226);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(175, 20);
            this.txtDate.TabIndex = 8;
            this.txtDate.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(506, 275);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(418, 203);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(37, 13);
            this.lblPrice.TabIndex = 39;
            this.lblPrice.Text = "Precio";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(487, 200);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(175, 20);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInt_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(418, 35);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 39;
            this.lblDescription.Text = "Descripcion";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(487, 32);
            this.txtDescription.MaxLength = 30;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(175, 20);
            this.txtDescription.TabIndex = 2;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(418, 255);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(40, 13);
            this.lblState.TabIndex = 39;
            this.lblState.Text = "Estado";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(418, 9);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 39;
            this.lblId.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(487, 6);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(175, 20);
            this.txtId.TabIndex = 2;
            // 
            // txtState
            // 
            this.txtState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtState.FormattingEnabled = true;
            this.txtState.Items.AddRange(new object[] {
            "RECIBIDO",
            "EN PROCESO",
            "TERMINADO",
            "ENTREGADO"});
            this.txtState.Location = new System.Drawing.Point(487, 252);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(175, 21);
            this.txtState.TabIndex = 7;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(299, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dvgServices
            // 
            this.dvgServices.AllowUserToAddRows = false;
            this.dvgServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dvgServices.Location = new System.Drawing.Point(12, 66);
            this.dvgServices.MultiSelect = false;
            this.dvgServices.Name = "dvgServices";
            this.dvgServices.ReadOnly = true;
            this.dvgServices.RowHeadersVisible = false;
            this.dvgServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgServices.Size = new System.Drawing.Size(377, 236);
            this.dvgServices.TabIndex = 0;
            this.dvgServices.TabStop = false;
            this.dvgServices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgServices_CellClick);
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
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(317, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(317, 308);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(72, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.TabStop = false;
            this.btnRemove.Text = "Eliminar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(587, 275);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 8;
            this.btnModify.Text = "Modificar";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(420, 177);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(22, 13);
            this.lblTel.TabIndex = 39;
            this.lblTel.Text = "Tel";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(487, 174);
            this.txtTel.MaxLength = 15;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(175, 20);
            this.txtTel.TabIndex = 5;
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(487, 147);
            this.txtClient.MaxLength = 30;
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(175, 20);
            this.txtClient.TabIndex = 4;
            // 
            // txtStateFilter
            // 
            this.txtStateFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtStateFilter.FormattingEnabled = true;
            this.txtStateFilter.Items.AddRange(new object[] {
            "TODOS",
            "RECIBIDO",
            "EN PROCESO",
            "TERMINADO",
            "ENTREGADO"});
            this.txtStateFilter.Location = new System.Drawing.Point(12, 35);
            this.txtStateFilter.Name = "txtStateFilter";
            this.txtStateFilter.Size = new System.Drawing.Size(175, 21);
            this.txtStateFilter.TabIndex = 9;
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 368);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dvgServices);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.txtStateFilter);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblClient);
            this.Name = "ServiceForm";
            this.Text = "ServiceForm";
            this.Load += new System.EventHandler(this.ServiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox txtState;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dvgServices;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.ComboBox txtStateFilter;
    }
}