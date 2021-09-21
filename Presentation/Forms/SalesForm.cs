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
    public partial class SalesForm : Form
    {
        private Product _product;
        private Sale _sale;
        private DetailSale _detailSale;
        private readonly ProductBol _productBol = new ProductBol();
        private readonly SaleBol _saleBol = new SaleBol();
        private readonly DetailSaleBol _detailSaleBol = new DetailSaleBol();
        private readonly ClientBol _clientBol = new ClientBol();
        private readonly EmployeeBol _employeeBol = new EmployeeBol();
        private decimal total = 0;
        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            txtTotal.Text = total.ToString();
            ViewChange(false);
            lblEmployee.Text = "40500077";
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
                        decimal salePrice = _productBol.CalculatePrice(item.price); 
                        dvgProducts.Rows.Add(
                            item.idProduct,
                            item.description,
                            item.price,
                            salePrice,
                            item.quantity
                            );
                    }
                    foreach (DataGridViewRow row in dvgProducts.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[4].Value) == 0)
                        {
                            row.Cells[4].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            if (Convert.ToInt32(row.Cells[4].Value) <= 5)
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
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_saleBol.GetLastId().ToString());
        }
        private void Sell()
        {
            try
            {
                _sale = new Sale();
                _sale.employee = _employeeBol.GetById(Convert.ToInt32(lblEmployee.Text));
                _sale.client = _clientBol.GetById(Convert.ToInt64(txtClient.Text));
                _sale.date = DateTime.Now;
                _sale.detailSales = new List<DetailSale>();
                foreach (DataGridViewRow row in dvgCart.Rows)
                {
                    _detailSale = new DetailSale();
                    _detailSale.product = _productBol.GetById(Convert.ToInt32(row.Cells[0].Value));
                    _detailSale.price = Convert.ToDecimal(row.Cells[2].Value);
                    _detailSale.quantity = Convert.ToInt32(row.Cells[3].Value);
                    _sale.detailSales.Add(_detailSale);
                }
                _saleBol.Registrate(_sale);
                if (_saleBol.stringBuilder.Length != 0 )
                {
                    MessageBox.Show(_saleBol.stringBuilder.ToString(), "Para continuar:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Venta registrada con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dvgCart.Rows.Clear();
                    dvgProducts.Rows.Clear();
                    txtSearch.Clear();
                    _sale = null;
                    _detailSale = null;
                }
            }
            catch (Exception ex)
            {
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
                    if (_product.quantity >= Convert.ToInt32(txtQuantity.Text))
                    {
                        bool exists = false;
                        if (dvgCart.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in dvgCart.Rows)
                            {
                                if (Convert.ToInt32(row.Cells[0].Value) == _product.idProduct)
                                {
                                    exists = true;
                                    if ((Convert.ToInt32(row.Cells[3].Value) +
                                        Convert.ToInt32(txtQuantity.Text)) <= _product.quantity)
                                    {
                                        total -= Convert.ToDecimal(row.Cells[4].Value);
                                        row.Cells[3].Value = Convert.ToInt32(row.Cells[3].Value) + Convert.ToInt32(txtQuantity.Text);
                                        row.Cells[4].Value = Convert.ToDecimal(row.Cells[2].Value)
                                            * Convert.ToInt32(row.Cells[3].Value);
                                        total += Convert.ToDecimal(row.Cells[4].Value);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error: La cantidad que intenta agregar no esta disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        if (exists == false)
                        {
                            decimal subTotal = _productBol.CalculatePrice(_product.price) * Convert.ToInt32(txtQuantity.Text);
                            dvgCart.Rows.Add(
                                _product.idProduct,
                                _product.description,
                                _productBol.CalculatePrice(_product.price),
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
                        MessageBox.Show("Error: La cantidad que intenta agregar no esta disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                    * Convert.ToInt32(txtQuantityCart.Text);
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
        private void btnSell_Click(object sender, EventArgs e)
        {
            Sell();
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
                (e.KeyChar != '.'))
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
