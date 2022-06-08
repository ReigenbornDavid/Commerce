
namespace Presentation.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnExpense = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnIncreases = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnBrand = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.userPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnService = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.topPpanel = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.midPanel = new System.Windows.Forms.Panel();
            this.btnHistory = new System.Windows.Forms.Button();
            this.leftPanel.SuspendLayout();
            this.userPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.topPpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.DarkGray;
            this.leftPanel.Controls.Add(this.btnHistory);
            this.leftPanel.Controls.Add(this.btnConfig);
            this.leftPanel.Controls.Add(this.btnExpense);
            this.leftPanel.Controls.Add(this.btnEmployee);
            this.leftPanel.Controls.Add(this.btnClients);
            this.leftPanel.Controls.Add(this.btnIncreases);
            this.leftPanel.Controls.Add(this.btnSupplier);
            this.leftPanel.Controls.Add(this.btnBrand);
            this.leftPanel.Controls.Add(this.btnCategory);
            this.leftPanel.Controls.Add(this.btnSales);
            this.leftPanel.Controls.Add(this.userPanel);
            this.leftPanel.Controls.Add(this.btnProduct);
            this.leftPanel.Controls.Add(this.btnService);
            this.leftPanel.Controls.Add(this.btnPurchase);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(178, 680);
            this.leftPanel.TabIndex = 0;
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.LightGray;
            this.btnConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfig.Location = new System.Drawing.Point(12, 584);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(100, 38);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.Text = "Configuracion";
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnExpense
            // 
            this.btnExpense.BackColor = System.Drawing.Color.LightGray;
            this.btnExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpense.Location = new System.Drawing.Point(12, 540);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.Size = new System.Drawing.Size(100, 38);
            this.btnExpense.TabIndex = 1;
            this.btnExpense.Text = "Gastos";
            this.btnExpense.UseVisualStyleBackColor = false;
            this.btnExpense.Click += new System.EventHandler(this.btnExpense_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.LightGray;
            this.btnEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.Location = new System.Drawing.Point(12, 496);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(100, 38);
            this.btnEmployee.TabIndex = 1;
            this.btnEmployee.Text = "Empleados";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.LightGray;
            this.btnClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClients.Location = new System.Drawing.Point(12, 144);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(100, 38);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Clientes";
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnIncreases
            // 
            this.btnIncreases.BackColor = System.Drawing.Color.LightGray;
            this.btnIncreases.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncreases.Location = new System.Drawing.Point(12, 452);
            this.btnIncreases.Name = "btnIncreases";
            this.btnIncreases.Size = new System.Drawing.Size(100, 38);
            this.btnIncreases.TabIndex = 1;
            this.btnIncreases.Text = "Aumentos";
            this.btnIncreases.UseVisualStyleBackColor = false;
            this.btnIncreases.Click += new System.EventHandler(this.btnIncreases_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.Color.LightGray;
            this.btnSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.Location = new System.Drawing.Point(12, 408);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(100, 38);
            this.btnSupplier.TabIndex = 1;
            this.btnSupplier.Text = "Proveedores";
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnBrand
            // 
            this.btnBrand.BackColor = System.Drawing.Color.LightGray;
            this.btnBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrand.Location = new System.Drawing.Point(12, 364);
            this.btnBrand.Name = "btnBrand";
            this.btnBrand.Size = new System.Drawing.Size(100, 38);
            this.btnBrand.TabIndex = 1;
            this.btnBrand.Text = "Marcas";
            this.btnBrand.UseVisualStyleBackColor = false;
            this.btnBrand.Click += new System.EventHandler(this.btnBrand_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.BackColor = System.Drawing.Color.LightGray;
            this.btnCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.Location = new System.Drawing.Point(12, 320);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(100, 38);
            this.btnCategory.TabIndex = 1;
            this.btnCategory.Text = "Categorias";
            this.btnCategory.UseVisualStyleBackColor = false;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.Color.LightGray;
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.Location = new System.Drawing.Point(12, 100);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(100, 38);
            this.btnSales.TabIndex = 1;
            this.btnSales.Text = "Ventas";
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // userPanel
            // 
            this.userPanel.BackColor = System.Drawing.Color.DimGray;
            this.userPanel.Controls.Add(this.label1);
            this.userPanel.Controls.Add(this.pictureBox1);
            this.userPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userPanel.Location = new System.Drawing.Point(0, 0);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(178, 94);
            this.userPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(88, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "DR";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.LightGray;
            this.btnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.Location = new System.Drawing.Point(12, 276);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(100, 38);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "Productos";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnService
            // 
            this.btnService.BackColor = System.Drawing.Color.LightGray;
            this.btnService.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnService.Location = new System.Drawing.Point(12, 232);
            this.btnService.Name = "btnService";
            this.btnService.Size = new System.Drawing.Size(100, 38);
            this.btnService.TabIndex = 1;
            this.btnService.Text = "Servicios";
            this.btnService.UseVisualStyleBackColor = false;
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackColor = System.Drawing.Color.LightGray;
            this.btnPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.Location = new System.Drawing.Point(12, 188);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(100, 38);
            this.btnPurchase.TabIndex = 1;
            this.btnPurchase.Text = "Compras";
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // topPpanel
            // 
            this.topPpanel.BackColor = System.Drawing.Color.Gainsboro;
            this.topPpanel.Controls.Add(this.btnMinimize);
            this.topPpanel.Controls.Add(this.btnClose);
            this.topPpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPpanel.Location = new System.Drawing.Point(178, 0);
            this.topPpanel.Name = "topPpanel";
            this.topPpanel.Size = new System.Drawing.Size(717, 50);
            this.topPpanel.TabIndex = 1;
            this.topPpanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnMinimize.Location = new System.Drawing.Point(619, 11);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(40, 33);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.Text = "--";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(665, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 33);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // midPanel
            // 
            this.midPanel.BackColor = System.Drawing.SystemColors.Control;
            this.midPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.midPanel.Location = new System.Drawing.Point(178, 50);
            this.midPanel.Name = "midPanel";
            this.midPanel.Size = new System.Drawing.Size(717, 630);
            this.midPanel.TabIndex = 2;
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.LightGray;
            this.btnHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.Location = new System.Drawing.Point(12, 628);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(138, 38);
            this.btnHistory.TabIndex = 1;
            this.btnHistory.Text = "Historial de Ventas";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 680);
            this.Controls.Add(this.midPanel);
            this.Controls.Add(this.topPpanel);
            this.Controls.Add(this.leftPanel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.leftPanel.ResumeLayout(false);
            this.userPanel.ResumeLayout(false);
            this.userPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.topPpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel topPpanel;
        private System.Windows.Forms.Panel midPanel;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnExpense;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnService;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnBrand;
        private System.Windows.Forms.Button btnIncreases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnHistory;
    }
}