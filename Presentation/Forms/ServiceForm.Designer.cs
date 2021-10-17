
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
            this.txtClient = new System.Windows.Forms.TextBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.btnSell = new System.Windows.Forms.Button();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblIdSale = new System.Windows.Forms.Label();
            this.txtIdSale = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnLastSale = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(81, 12);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(175, 20);
            this.txtClient.TabIndex = 46;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(298, 15);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(35, 13);
            this.lblEmployee.TabIndex = 45;
            this.lblEmployee.Text = "label1";
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(181, 116);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 23);
            this.btnSell.TabIndex = 44;
            this.btnSell.Text = "Confirmar";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(12, 15);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 39;
            this.lblClient.Text = "Cliente";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 41);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 39;
            this.lblDescription.Text = "Descripcion";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(81, 38);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(175, 20);
            this.txtDescription.TabIndex = 46;
            // 
            // lblIdSale
            // 
            this.lblIdSale.AutoSize = true;
            this.lblIdSale.Location = new System.Drawing.Point(12, 93);
            this.lblIdSale.Name = "lblIdSale";
            this.lblIdSale.Size = new System.Drawing.Size(47, 13);
            this.lblIdSale.TabIndex = 39;
            this.lblIdSale.Text = "Id Venta";
            // 
            // txtIdSale
            // 
            this.txtIdSale.Location = new System.Drawing.Point(81, 90);
            this.txtIdSale.Name = "txtIdSale";
            this.txtIdSale.Size = new System.Drawing.Size(175, 20);
            this.txtIdSale.TabIndex = 46;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(100, 116);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 44;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(12, 67);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(37, 13);
            this.lblPrice.TabIndex = 39;
            this.lblPrice.Text = "Precio";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(81, 64);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(175, 20);
            this.txtPrice.TabIndex = 46;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInt_KeyPress);
            // 
            // btnLastSale
            // 
            this.btnLastSale.Location = new System.Drawing.Point(262, 88);
            this.btnLastSale.Name = "btnLastSale";
            this.btnLastSale.Size = new System.Drawing.Size(75, 23);
            this.btnLastSale.TabIndex = 44;
            this.btnLastSale.Text = "Ultima Venta";
            this.btnLastSale.UseVisualStyleBackColor = true;
            this.btnLastSale.Click += new System.EventHandler(this.btnLastSale_Click);
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 368);
            this.Controls.Add(this.txtIdSale);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblIdSale);
            this.Controls.Add(this.btnLastSale);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblClient);
            this.Name = "ServiceForm";
            this.Text = "ServiceForm";
            this.Load += new System.EventHandler(this.ServiceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblIdSale;
        private System.Windows.Forms.TextBox txtIdSale;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnLastSale;
    }
}