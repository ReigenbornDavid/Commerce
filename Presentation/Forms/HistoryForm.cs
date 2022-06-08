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
    public partial class HistoryForm : Form
    {
        private SaleBol _saleBol = new SaleBol();
        private Sale _sale;
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        private void FillTable()
        {
            var lst = _saleBol.All();
            foreach (var sale in lst)
            {
                foreach (var detail in sale.DetailSales)
                {
                    dvgSales.Rows.Add(
                        sale.IdSale,
                        sale.Date,
                        detail.Product.Description + " "+ detail.Product.Brand.Name,
                        detail.Price,
                        detail.Quantity,
                        detail.Price*detail.Quantity,
                        sale.Total);
                }
            }
        }

        private void dvgSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgSales.Rows.Count > 0)
            {
                _sale = new Sale();
                _sale.IdSale = Convert.ToInt32(dvgSales.CurrentRow.Cells[0].Value);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_sale != null)
            {
                if (MessageBox.Show("¿Esta seguro que desea eliminar esta venta ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        _saleBol.Delete(_sale);
                        if (_saleBol.stringBuilder.Length != 0)
                        {
                            MessageBox.Show(_saleBol.stringBuilder.ToString(), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Venta eliminada con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dvgSales.Rows.Clear();
                            _sale = null;
                            FillTable();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error ninguna venta seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
