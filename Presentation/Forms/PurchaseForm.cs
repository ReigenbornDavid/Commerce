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
    public partial class PurchaseForm : Form
    {
        private Product _product;
        private Purchase _purchase;
        private DetailPurchase _detailPurchase;
        private readonly ProductBol _productBol = new ProductBol();
        private readonly PurchaseBol _purchaseBol = new PurchaseBol();
        private readonly EmployeeBol _employeeBol = new EmployeeBol();
        private readonly SupplierBol _supplierBol = new SupplierBol();
        private decimal total = 0;
        public PurchaseForm()
        {
            InitializeComponent();
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            txtTotal.Text = total.ToString();
            ViewChange(false);
            lblEmployee.Text = "40500077";
            lblEmployee.Visible = false;
            AddSuppliersToCombobox();
        }

        private void AddSuppliersToCombobox()
        {
            foreach (var supplier in _supplierBol.All())
            {
                txtSupplier.Items.Add(supplier.name);
            }
        }

        private void UpdateTotal()
        {
            txtTotal.Text = total.ToString();
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
                            item.description,
                            item.cost,
                            item.price,
                            item.quantity
                            );
                    }
                    foreach (DataGridViewRow row in dvgProducts.Rows)
                    {
                        if (Convert.ToDecimal(row.Cells[4].Value) == 0)
                        {
                            row.Cells[4].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            if (Convert.ToDecimal(row.Cells[4].Value) <= 5)
                            {
                                row.Cells[4].Style.BackColor = Color.Orange;
                            }
                            else
                            {
                                row.Cells[4].Style.BackColor = Color.LimeGreen;
                            }
                        }
                    }
                    RemoveSelection(dvgProducts);
                }
                else
                {
                    MessageBox.Show("No existen producto Registrado");
                }
            }
        }
        private void Buy()
        {
            try
            {
                _purchase = new Purchase();
                _purchase.employee = _employeeBol.GetById(Convert.ToInt32(lblEmployee.Text));
                _purchase.date = DateTime.Now;
                _purchase.supplier = _supplierBol.GetByName(txtSupplier.Text);
                _purchase.detailPurchases = new List<DetailPurchase>();
                _purchase.total = Convert.ToDecimal(txtTotal.Text);
                foreach (DataGridViewRow row in dvgCart.Rows)
                {
                    _detailPurchase = new DetailPurchase();
                    _detailPurchase.product = _productBol.GetById(Convert.ToInt32(row.Cells[0].Value));
                    _detailPurchase.price = Convert.ToDecimal(row.Cells[2].Value);
                    _detailPurchase.quantity = Convert.ToDecimal(row.Cells[3].Value);
                    _purchase.detailPurchases.Add(_detailPurchase);
                }
                _purchase.idPurchase = _purchaseBol.Registrate(_purchase);
                if (_purchaseBol.stringBuilder.Length != 0)
                {
                    _purchaseBol.Delete(_purchase.idPurchase);
                    MessageBox.Show(_purchaseBol.stringBuilder.ToString(), "Para continuar:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Compra registrada con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dvgCart.Rows.Clear();
                    dvgProducts.Rows.Clear();
                    txtSearch.Clear();
                    txtTotal.Clear();
                    total = 0;
                    _purchase = null;
                    _detailPurchase = null;
                }
            }
            catch (Exception ex)
            {
                _purchaseBol.Delete(_purchase.idPurchase);
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);     
            }
        }

        //Buttons
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "")
            {
                if (_product != null)
                {
                    _product = _productBol.GetById(_product.idProduct);
                    bool exists = false;
                    if (dvgCart.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dvgCart.Rows)
                        {
                            if (Convert.ToInt32(row.Cells[0].Value) == _product.idProduct)
                            {
                                exists = true;
                                total -= Convert.ToDecimal(row.Cells[4].Value);
                                row.Cells[3].Value = Convert.ToDecimal(row.Cells[3].Value) + Convert.ToDecimal(txtQuantity.Text);
                                row.Cells[4].Value = Convert.ToDecimal(row.Cells[2].Value)
                                    * Convert.ToDecimal(row.Cells[3].Value);
                                total += Convert.ToDecimal(row.Cells[4].Value);
                            }
                        }
                    }
                    if (exists == false)
                    {
                        decimal subTotal = _product.cost * Convert.ToDecimal(txtQuantity.Text);
                        dvgCart.Rows.Add(
                            _product.idProduct,
                            _product.description,
                            _product.cost,
                            txtQuantity.Text,
                            subTotal
                            );
                        total += subTotal;
                    }
                    UpdateTotal();
                    RemoveSelection(dvgProducts);
                    RemoveSelection(dvgCart);
                    _product = null;
                }
                else
                {
                    MessageBox.Show("Error: Ningun producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error: Ingrese la cantidad que desea agregar al carrito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dvgCart.Rows.Count > 0)
            {
                total -= Convert.ToDecimal(dvgCart.CurrentRow.Cells[4].Value);
                dvgCart.CurrentRow.Cells[2].Value = txtPriceCart.Text;
                dvgCart.CurrentRow.Cells[3].Value = txtQuantityCart.Text;
                dvgCart.CurrentRow.Cells[4].Value = Convert.ToDecimal(txtPriceCart.Text)
                    * Convert.ToDecimal(txtQuantityCart.Text);
                total += Convert.ToDecimal(dvgCart.CurrentRow.Cells[4].Value);
                UpdateTotal();
                RemoveSelection(dvgCart);
                ViewChange(false);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dvgCart.Rows.Count > 0)
            {
                total -= Convert.ToDecimal(dvgCart.CurrentRow.Cells[4].Value);
                UpdateTotal();
                dvgCart.Rows.RemoveAt(dvgCart.CurrentRow.Index);
                RemoveSelection(dvgCart);
                ViewChange(false);
            }
        }
        private void btnBuy_Click(object sender, EventArgs e)
        {
            Buy();
        }
        //Events
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dvgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgProducts.Rows.Count > 0)
            {
                _product = new Product();
                _product.idProduct = Convert.ToInt32(dvgProducts.CurrentRow.Cells[0].Value);
            }
        }
        private void textBoxInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void dvgCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgCart.Rows.Count > 0)
            {
                txtPriceCart.Text = dvgCart.CurrentRow.Cells[2].Value.ToString();
                txtQuantityCart.Text = dvgCart.CurrentRow.Cells[3].Value.ToString();
                ViewChange(true);
            }
        }

        private void ViewChange(bool view)
        {
            btnChange.Visible = view;
            btnRemove.Visible = view;
            txtPriceCart.Visible = view;
            txtQuantityCart.Visible = view;
        }
    }
}
