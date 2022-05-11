using Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.BOL;

namespace Presentation.Forms
{
    public partial class SupplierForm : Form
    {
        private Supplier _supplier;
        private readonly SupplierBol _supplierBol = new SupplierBol();
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            txtNeedInvoice.Text = "SI";
        }

        private void Save()
        {
            try
            {
                if (_supplier == null) _supplier = new Supplier();

                _supplier.Name = txtName.Text;
                _supplier.NeedInvoice = ConvertStringToBoolean(txtNeedInvoice.Text);

                _supplierBol.Registrate(_supplier);

                if (_supplierBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_supplierBol.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    MessageBox.Show("Proveedor registrado/actualizado con éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private bool ConvertStringToBoolean(string text)
        {
            if (text == "SI")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private string ConvertBooleanToString(bool needInvoice)
        {
            if (needInvoice)
            {
                return "SI";
            }
            else
            {
                return "NO";
            }
        }
    }
}
