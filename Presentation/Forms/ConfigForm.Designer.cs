
namespace Presentation.Forms
{
    partial class ConfigForm
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
            this.lblProfit = new System.Windows.Forms.Label();
            this.txtProfit = new System.Windows.Forms.TextBox();
            this.lblTax = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.lblUsd = new System.Windows.Forms.Label();
            this.txtUsd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(113, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = true;
            this.lblProfit.Location = new System.Drawing.Point(39, 37);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(53, 13);
            this.lblProfit.TabIndex = 1;
            this.lblProfit.Text = "Ganancia";
            // 
            // txtProfit
            // 
            this.txtProfit.Location = new System.Drawing.Point(98, 34);
            this.txtProfit.Name = "txtProfit";
            this.txtProfit.Size = new System.Drawing.Size(90, 20);
            this.txtProfit.TabIndex = 2;
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(39, 63);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(50, 13);
            this.lblTax.TabIndex = 1;
            this.lblTax.Text = "Impuesto";
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(98, 60);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(90, 20);
            this.txtTax.TabIndex = 2;
            // 
            // lblUsd
            // 
            this.lblUsd.AutoSize = true;
            this.lblUsd.Location = new System.Drawing.Point(39, 89);
            this.lblUsd.Name = "lblUsd";
            this.lblUsd.Size = new System.Drawing.Size(32, 13);
            this.lblUsd.TabIndex = 1;
            this.lblUsd.Text = "Dolar";
            // 
            // txtUsd
            // 
            this.txtUsd.Location = new System.Drawing.Point(98, 86);
            this.txtUsd.Name = "txtUsd";
            this.txtUsd.Size = new System.Drawing.Size(90, 20);
            this.txtUsd.TabIndex = 2;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 234);
            this.Controls.Add(this.txtUsd);
            this.Controls.Add(this.lblUsd);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.txtProfit);
            this.Controls.Add(this.lblProfit);
            this.Controls.Add(this.btnSave);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.TextBox txtProfit;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label lblUsd;
        private System.Windows.Forms.TextBox txtUsd;
    }
}