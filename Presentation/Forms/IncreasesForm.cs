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
    public partial class IncreasesForm : Form
    {
        private Category _category;
        private readonly CategoryBol _categoryBol = new CategoryBol();
        private Brand _brand;
        private readonly BrandBol _brandBol = new BrandBol();
        private Supplier _supplier;
        private readonly SupplierBol _supplierBol = new SupplierBol();
        private readonly ProductBol _productBol = new ProductBol();
        public IncreasesForm()
        {
            InitializeComponent();
        }

        private void FormIncreases_Load(object sender, EventArgs e)
        {
            chkCost.Checked = true;
            chkPrice.Checked = true;
            txtSearchCategory.Focus();
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
        private void CellClickCategory()
        {
            if (dvgCategories.Rows.Count > 0)
            {
                _category = new Category();
                _category.IdCategory = Convert.ToInt32(dvgCategories.CurrentRow.Cells[0].Value);
                FillFieldsCategory();
            }
        }

        public void FillFieldsCategory()
        {
            try
            {
                _category = _categoryBol.GetById(_category.IdCategory);
                txtIdCategory.Text = _category.IdCategory.ToString();
                txtNameCategory.Text = _category.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchCategory()
        {
            if (txtSearchCategory.Text != "")
            {
                List<Category> categories = _categoryBol.GetAllByName(txtSearchCategory.Text);
                if (categories.Count > 0 && categories != null)
                {
                    dvgCategories.Rows.Clear();
                    dvgCategories.AutoGenerateColumns = false;
                    foreach (var item in categories)
                    {
                        dvgCategories.Rows.Add(
                            item.IdCategory,
                            item.Name
                            );
                    }
                    RemoveSelection(dvgCategories);
                    txtIdCategory.Clear();
                    txtNameCategory.Clear();
                    _category = null;
                }
            }
        }

        //Brand
        private void CellClickBrand()
        {
            if (dvgBrands.Rows.Count > 0)
            {
                _brand = new Brand();
                _brand.IdBrand = Convert.ToInt32(dvgBrands.CurrentRow.Cells[0].Value);
                FillFieldsBrand();
            }
        }

        public void FillFieldsBrand()
        {
            try
            {
                _brand = _brandBol.GetById(_brand.IdBrand);
                txtIdBrand.Text = _brand.IdBrand.ToString();
                txtNameBrand.Text = _brand.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchBrand()
        {
            if (txtSearchBrand.Text != "")
            {
                List<Brand> brands = _brandBol.GetAllByName(txtSearchBrand.Text);
                if (brands.Count > 0 && brands != null)
                {
                    dvgBrands.Rows.Clear();
                    dvgBrands.AutoGenerateColumns = false;
                    foreach (var item in brands)
                    {
                        dvgBrands.Rows.Add(
                            item.IdBrand,
                            item.Name
                            );
                    }
                    RemoveSelection(dvgBrands);
                    txtIdBrand.Clear();
                    txtNameBrand.Clear();
                    _brand = null;
                }
            }
        }

        //Supplier
        private void CellClickSupplier()
        {
            if (dvgSuppliers.Rows.Count > 0)
            {
                _supplier = new Supplier();
                _supplier.IdSupplier = Convert.ToInt32(dvgSuppliers.CurrentRow.Cells[0].Value);
                FillFieldsSupplier();
            }
        }

        public void FillFieldsSupplier()
        {
            try
            {
                _supplier = _supplierBol.GetById(_supplier.IdSupplier);
                txtIdSupplier.Text = _supplier.IdSupplier.ToString();
                txtNameSupplier.Text = _supplier.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchSupplier()
        {
            if (txtSearchSupplier.Text != "")
            {
                List<Supplier> suppliers = _supplierBol.GetAllByName(txtSearchSupplier.Text);

                if (suppliers.Count > 0 && suppliers != null)
                {
                    dvgSuppliers.Rows.Clear();
                    dvgSuppliers.AutoGenerateColumns = false;
                    foreach (var item in suppliers)
                    {
                        dvgSuppliers.Rows.Add(
                            item.IdSupplier,
                            item.Name
                            );
                    }
                    RemoveSelection(dvgSuppliers);
                    txtIdSupplier.Clear();
                    txtNameSupplier.Clear();
                    _supplier = null;
                }
            }
        }

        //Buttons
        private void btnIncrease_Click(object sender, EventArgs e)
        {
            double Increase = ((Convert.ToDouble(txtIncrease.Text) / 100) + 1);
            if (_category != null || _brand != null || _supplier != null && txtIncrease.Text != "")
            {
                foreach (DataGridViewRow row in dvgProducts.Rows)
                {
                    Product product = _productBol.GetById(Convert.ToInt32(row.Cells[0].Value));
                    if (chkCost.Checked)
                    {
                        product.Cost = product.Cost * Increase;
                    }
                    if (chkPrice.Checked)
                    {
                        product.Price = product.Price * Increase;
                    }
                    _productBol.Registrate(product);
                }
                MessageBox.Show("Productos Actualizados correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            else
            {
                MessageBox.Show("Error: Ningun parametro seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtIdBrand.Clear();
            txtIdCategory.Clear();
            txtIdSupplier.Clear();
            txtIncrease.Clear();
            txtNameBrand.Clear();
            txtNameCategory.Clear();
            txtNameSupplier.Clear();
            RemoveSelection(dvgCategories);
            RemoveSelection(dvgBrands);
            RemoveSelection(dvgSuppliers);
            dvgProducts.Rows.Clear();
            txtCont.Clear();
            _category = null;
            _brand = null;
            _supplier = null;
        }
        private void SearchProducts()
        {

            List<Product> products = _productBol.GetProducts(_category, _brand, _supplier);
            if (products.Count > 0 && products != null)
            {
                dvgProducts.Rows.Clear();
                dvgProducts.AutoGenerateColumns = false;
                foreach (var item in products)
                {
                    dvgProducts.Rows.Add(
                        item.IdProduct,
                        item.Description
                        );
                }
                RemoveSelection(dvgProducts);
                txtCont.Text = products.Count.ToString();
            }
            else
            {
                dvgProducts.Rows.Clear();
                txtCont.Text = "0";
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProducts();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSearchSupplier_Click(object sender, EventArgs e)
        {
            SearchSupplier();
        }

        private void btnSearchBrand_Click(object sender, EventArgs e)
        {
            SearchBrand();
        }

        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            SearchCategory();
        }

        private void txtSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            SearchSupplier();
        }

        private void txtSearchBrand_TextChanged(object sender, EventArgs e)
        {
            SearchBrand();
        }

        private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        {
            SearchCategory();
        }

        private void dvgSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClickSupplier();
            SearchProducts();
        }

        private void dvgBrands_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClickBrand();
            SearchProducts();
        }

        private void dvgCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClickCategory();
            SearchProducts();
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
        private void textBoxInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dvgProducts.Rows.Count > 0)
            {
                dvgProducts.Rows.RemoveAt(dvgProducts.CurrentRow.Index);
                RemoveSelection(dvgProducts);
                txtCont.Text = dvgProducts.Rows.Count.ToString();
            }
        }
    }
}
