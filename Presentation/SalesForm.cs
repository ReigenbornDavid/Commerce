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
    public partial class SalesForm : Form
    {
        private Product _product;
        private readonly ProductBol _productBol = new ProductBol();
        private decimal total = 0;
        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            txtTotal.Text = total.ToString();
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

        //Buttons
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (_product != null)
            {
                _product = _productBol.GetById(_product.idProduct);
                if (_product.quantity >= Convert.ToInt32(txtQuantity.Text))
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
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dvgCart.Rows.Count > 0)
            {
                total -= Convert.ToDecimal(dvgCart.CurrentRow.Cells[4].Value);
                dvgCart.CurrentRow.Cells[3].Value = txtQuantity.Text;
                dvgCart.CurrentRow.Cells[4].Value = Convert.ToDecimal(dvgCart.CurrentRow.Cells[2].Value) 
                    * Convert.ToInt32(txtQuantity.Text);
                total += Convert.ToDecimal(dvgCart.CurrentRow.Cells[4].Value);
                UpdateTotal();
                RemoveSelection(dvgCart);
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
            }
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
    }
}
