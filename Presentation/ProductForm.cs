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

        private void Save()
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

        private void Search(string description)
        {
            List<Product> products = _productBol.GetProducts();
            //List<Product> products = _productBol.GetByName(description);

            if (products.Count > 0 && products != null)
            {
                dvgProducts.Rows.Clear();   
                dvgProducts.AutoGenerateColumns = false;
                foreach (var item in products)
                {
                    dvgProducts.Rows.Add(
                        item.idProduct,
                        item.description,
                        item.price,
                        item.price*1,3,
                        item.quantity
                        );
                }
            }
            else
            {
                MessageBox.Show("No existen producto Registrado");
            } 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }
    }
}
