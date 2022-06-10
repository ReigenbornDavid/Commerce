using Common.Entities;
using Domain.BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class ProductForm : Form
    {
        private Product _product;
        private readonly ProductBol _productBol = new ProductBol();
        private readonly CategoryBol _categoryBol = new CategoryBol();
        private readonly SupplierBol _supplierBol = new SupplierBol();
        private readonly BrandBol _brandBol = new BrandBol();
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            btnModify.Visible = false;
            AddCategoriesToCombobox();
            AddSuppliersToCombobox();
            AddBrandsToCombobox();
            txtSearch.Focus();
            txtUsd.Text = "NO";
        }

        private void AddBrandsToCombobox()
        {
            foreach (var brand in _brandBol.All())
            {
                txtBrand.Items.Add(brand.Name);
                txtBrandFilter.Items.Add(brand.Name);
            }
        }

        private void AddSuppliersToCombobox()
        {
            foreach (var supplier in _supplierBol.All())
            {
                txtSupplier.Items.Add(supplier.Name);
                txtSupplierFilter.Items.Add(supplier.Name);
            }
        }

        private void AddCategoriesToCombobox()
        {
            foreach (var category in _categoryBol.All())
            {
                txtCategory.Items.Add(category.Name);
                txtCategoryFilter.Items.Add(category.Name);
            }
        }

        private void Remove()
        {
            if (_product != null)
            {
                _productBol.Delete(_product.IdProduct);
                MessageBox.Show("Producto eliminado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Ningun producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtId.Clear();
            txtCode.Clear();
            txtDescription.Clear();
            txtCost.Clear();
            txtPrice.Clear();
            txtCategory.Text = "";
            txtSupplier.Text = "";
            txtBrand.Text = "";
            txtUsd.Text = "NO";
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
        private string ConvertBooleanToString(bool active)
        {
            if (active)
            {
                return "SI";
            }
            else
            {
                return "NO";
            }
        }
        public void FillFields()
        {
            try
            {
                _product = _productBol.GetById(_product.IdProduct);
                txtId.Text = _product.IdProduct.ToString();
                txtCode.Text = _product.Code;
                txtDescription.Text = _product.Description;
                txtCost.Text = _product.Cost.ToString();
                txtPrice.Text = _product.Price.ToString();
                txtCategory.Text = _product.Category.Name;
                txtSupplier.Text = _product.Supplier.Name;
                txtBrand.Text = _product.Brand.Name;
                txtUsd.Text = ConvertBooleanToString(_product.Usd);
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
                _product.IdProduct = Convert.ToInt32(dvgProducts.CurrentRow.Cells[0].Value);
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
                    _product.Quantity = 0;
                }
                else
                {
                    _product.IdProduct = Convert.ToInt32(txtId.Text);
                }
                _product.Code = txtCode.Text;
                _product.Description = txtDescription.Text;
                _product.Cost = Convert.ToDouble(txtCost.Text);
                _product.Price = Convert.ToDouble(txtPrice.Text);
                _product.Category = _categoryBol.GetByName(txtCategory.Text);
                _product.Supplier = _supplierBol.GetByName(txtSupplier.Text);
                _product.Brand = _brandBol.GetByName(txtBrand.Text);
                _product.Usd = ConvertStringToBoolean(txtUsd.Text);
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
        public static string PadNumbers(string input)
        {
            var result = Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
            return result;
        }
        private void Search()
        {
            List<Product> products = _productBol.GetByName(txtSearch.Text, txtCategoryFilter.Text, txtSupplierFilter.Text, txtBrandFilter.Text);
            if (products.Count > 0 && products != null)
            {
                products = products.OrderBy(x => PadNumbers(x.Description)).ToList();
                dvgProducts.Rows.Clear();
                dvgProducts.AutoGenerateColumns = false;
                foreach (var item in products)
                {
                    dvgProducts.Rows.Add(
                        item.IdProduct,
                        item.Description,
                        item.Brand.Name
                        );
                }
                RemoveSelection(dvgProducts);
                ViewAdd();
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
        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if(txtIncrease.Text != "" && btnModify.Visible)
            {
                txtCost.Text = (Convert.ToDecimal(txtCost.Text) * ((Convert.ToDecimal(txtIncrease.Text) / 100) + 1)).ToString();
                txtPrice.Text = (Convert.ToDecimal(txtPrice.Text) * ((Convert.ToDecimal(txtIncrease.Text) / 100) + 1)).ToString();
            }
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
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
        private void textBoxDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.'))
            {
                e.KeyChar = ',';
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',' || e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCost_Leave(object sender, EventArgs e)
        {
            if (txtCost.Text != "")
            {
                double profit = Convert.ToDouble(ConfigurationManager.AppSettings["profit"])/100+1;
                double tax = Convert.ToDouble(ConfigurationManager.AppSettings["tax"])/100+1;
                txtPrice.Text = (Convert.ToDouble(txtCost.Text) * profit * tax).ToString();
            }
        }
    }
}
