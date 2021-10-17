using Common.Entities;
using Domain.BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class ServiceForm : Form
    {
        private readonly SaleBol _saleBol = new SaleBol();
        private readonly ServiceBol _serviceBol = new ServiceBol();
        private Service _service = new Service();
        private readonly ClientBol _clientBol = new ClientBol();
        private readonly EmployeeBol _employeeBol = new EmployeeBol();
        public ServiceForm()
        {
            InitializeComponent();
        }

        private void ServiceForm_Load(object sender, EventArgs e)
        {
            lblEmployee.Text = "40500077";
        }

        private void Sell()
        {
            try
            {
                _service = new Service();
                _service.description = txtDescription.Text;
                _service.price = Convert.ToDecimal(txtPrice.Text);
                _service.date = DateTime.Now;
                _service.employee = _employeeBol.GetById(Convert.ToInt32(lblEmployee.Text));
                _service.client = _clientBol.GetById(Convert.ToInt64(txtClient.Text));
                _service.sale = new Sale();
                if (txtIdSale.Text != "")
                {
                    _service.sale.idSale = Convert.ToInt32(txtIdSale.Text);
                }
                _serviceBol.Registrate(_service);
                if (_saleBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_saleBol.stringBuilder.ToString(), "Para continuar:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Servicio registrado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    _service = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtDescription.Clear();
            txtClient.Clear();
            txtPrice.Clear();
            txtIdSale.Clear();
        }

        //Buttons
        private void btnSell_Click(object sender, EventArgs e)
        {
            Sell();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void btnLastSale_Click(object sender, EventArgs e)
        {
            txtIdSale.Text = _saleBol.GetLastId().ToString();
        }
        //Events
        private void textBoxInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
