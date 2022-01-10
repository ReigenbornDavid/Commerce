using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //-------------------------------------------------------------------------
        private void AbrirFormEnPanel<Forms>() where Forms : Form, new()
        {
            foreach (var form in this.midPanel.Controls.OfType<Form>())
            {
                form.Close();
            }
            Form formulario;
            formulario = midPanel.Controls.OfType<Forms>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new Forms();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                midPanel.Controls.Add(formulario);
                midPanel.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
                if (formulario.WindowState == FormWindowState.Minimized)
                {
                    formulario.WindowState = FormWindowState.Normal;
                }
            }
        }
        //-------------------------------------------------------------------------
        //Buttons in lateral panel
        private void btnProduct_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<Forms.ProductForm>();
        }
        private void btnCategory_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<Forms.CategoryForm>();
        }
        private void btnSales_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<Forms.SalesForm>();
        }
        private void btnClients_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<Forms.ClientForm>();
        }
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<Forms.EmployeeForm>();
        }
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<Forms.PurchaseForm>();
        }
        private void btnExpense_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<Forms.ExpenseForm>();
        }
        private void btnService_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<Forms.ServiceForm>();
        }
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<Forms.SupplierForm>();
        }
        //------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
