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

namespace Presentation
{
    public partial class ProductForm : Form
    {
        //Creamos las instancias de la clase Eproducto y ProductoBol
        private Product _product;
        private readonly ProductBol _productBol = new ProductBol();
        private readonly CategoryBol _categoryBol = new CategoryBol();
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            foreach (var category in _categoryBol.All())
            {
                txtCategory.Items.Add(category.name);
            }
        }

        private void Guardar()
        {
            try
            {
                if (_product == null) _product = new Product();

                _product.description = txtDescription.Text;
                _product.price = Convert.ToDecimal(txtPrice.Text);
                _product.quantity = Convert.ToInt32(txtQuantity.Text);
                _product.category = _categoryBol.GetByName(txtCategory.Text);

                _productBol.Registrate(_product);

                if (_productBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_productBol.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    MessageBox.Show("Producto registrado/actualizado con éxito");

                    //TraerTodos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
