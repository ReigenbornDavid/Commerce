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
    public partial class ExpenseForm : Form
    {
        private Expense _expense;
        private readonly ExpenseBol _expenseBol = new ExpenseBol();
        public ExpenseForm()
        {
            InitializeComponent();
        }

        private void ExpenseForm_Load(object sender, EventArgs e)
        {

        }

        private void Save()
        {
            try
            {
                if (_expense == null) _expense = new Expense();
                _expense.Description = txtDescripcion.Text;
                _expense.Price = Convert.ToDecimal(txtPrice.Text);
                _expenseBol.Registrate(_expense);
                if (_expenseBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_expenseBol.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    MessageBox.Show("Gasto registrado/actualizado con éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
