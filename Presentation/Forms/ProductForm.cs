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
            btnModify.Visible = false;
            foreach (var category in _categoryBol.All())
            {
                txtCategory.Items.Add(category.name);
            }
            txtSearch.Focus();
        }

        private void Remove()
        {
            if (_product != null)
            {
                _productBol.Delete(_product.idProduct);
            }
            else
            {
                MessageBox.Show("Error: Ningun producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtId.Clear();
            txtDescription.Clear();
            txtCost.Clear();
            txtPrice.Clear();
            txtCategory.Text = "";
            ViewAdd();
            RemoveSelection(dvgProducts);
        }

        private void ViewModify()
        {
            btnModify.Visible = true;
            btnSave.Visible = false;
        }
        private void ViewAdd()
        {
            _product = null;
            btnModify.Visible = false;
            btnSave.Visible = true;
        }
        public void FillFields()
        {
            try
            {
                _product = _productBol.GetById(_product.idProduct);
                txtId.Text = _product.idProduct.ToString();
                txtDescription.Text = _product.description;
                txtCost.Text = _product.price.ToString();
                txtPrice.Text = _productBol.CalculatePrice(_product.price).ToString();
                txtCategory.Text = _product.category.name;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RemoveSelection(DataGridView table)
        {
            int Index;
            if (table.Rows.Count > 0)
            {
                Index = table.CurrentRow.Index;
                table.Rows[Index].Selected = false;
            }
        }
        private void CellClick()
        {
            if (dvgProducts.Rows.Count > 0)
            {
                _product = new Product();
                _product.idProduct = Convert.ToInt32(dvgProducts.CurrentRow.Cells[0].Value);
                FillFields();
                ViewModify();
            }
        }
        private void Save()
        {
            try
            {
                if (_product == null)
                {
                    _product = new Product();
                }
                else
                {
                    _product.idProduct = Convert.ToInt32(txtId.Text);
                }
                _product.description = txtDescription.Text;
                _product.price = Convert.ToDecimal(txtCost.Text);
                _product.quantity = 0;
                _product.category = _categoryBol.GetByName(txtCategory.Text);

                _productBol.Registrate(_product);

                if (_productBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_productBol.stringBuilder.ToString(), "Para continuar:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Producto registrado/actualizado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Search();
                    _product = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Search()
        {
            if (txtSearch.Text != "")
            {
                List<Product> products = _productBol.GetByName(txtSearch.Text);
                if (products.Count > 0 && products != null)
                {
                    dvgProducts.Rows.Clear();
                    dvgProducts.AutoGenerateColumns = false;
                    foreach (var item in products)
                    {
                        dvgProducts.Rows.Add(
                            item.idProduct,
                            item.description
                            );
                    }
                    RemoveSelection(dvgProducts);
                    ViewAdd();
                }
                else
                {
                    MessageBox.Show("No existen producto Registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Buttons
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            Clear();
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            Save();
            Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }
        //Events
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dvgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClick();
        }
        private void textBoxInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void textBoxDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
