using Common.Entities;
using Domain.BOL;
using Presentation.ReportForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        private readonly ClientBol _clientBol = new ClientBol();
        private readonly EmployeeBol _employeeBol = new EmployeeBol();
        private readonly CategoryBol _categoryBol = new CategoryBol();
        private readonly SupplierBol _supplierBol = new SupplierBol();
        private readonly BrandBol _brandBol = new BrandBol();
        private double _total = 0;
        private double usdValue = Convert.ToDouble(ConfigurationManager.AppSettings["usd"]);

        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            txtTotal.Text = _total.ToString();
            ViewChange(false);
            lblEmployee.Text = "40500077";
            AddClientsToComboBox();
            AddCategoriesToCombobox();
            AddSuppliersToCombobox();
            AddBrandsToCombobox();
            txtQuantity.Text = "1";
            chkPayment.Checked = true;
            chkClient.Checked = true;
        }

        private void AddBrandsToCombobox()
        {
            foreach (var brand in _brandBol.All())
            {
                txtBrandFilter.Items.Add(brand.Name);
            }
        }

        private void AddSuppliersToCombobox()
        {
            foreach (var supplier in _supplierBol.All())
            {
                txtSupplierFilter.Items.Add(supplier.Name);
            }
        }

        private void AddCategoriesToCombobox()
        {
            foreach (var category in _categoryBol.All())
            {
                txtCategoryFilter.Items.Add(category.Name);
            }
        }

        private void AddClientsToComboBox()
        {
            foreach (var client in _clientBol.GetClients())
            {
                if (client.IdClient != 20111111112)
                {
                    txtClient.Items.Add(client.IdClient);
                }
            }
        }

        private void UpdateTotal()
        {
            txtTotal.Text = _total.ToString();
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
                products.Where(x => x.Usd).Select(x => { x.Cost *= usdValue; x.Price *= usdValue; return x; }).ToList();
                products = products.OrderBy(x => PadNumbers(x.Description)).ToList();
                dvgProducts.Rows.Clear();
                dvgProducts.AutoGenerateColumns = false;
                foreach (var item in products)
                {
                    dvgProducts.Rows.Add(
                        item.IdProduct,
                        item.Description,
                        item.Brand.Name,
                        item.Price,
                        item.Quantity
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
                dvgProducts.Rows.Clear();
            }
        }

        private void Sell()
        {
            try
            {
                _sale = new Sale();
                //_sale.IdSale = _saleBol.GetLastId() + 1;
                _sale.Employee = _employeeBol.GetById(Convert.ToInt32(lblEmployee.Text));
                _sale.Client = _clientBol.GetById(Convert.ToInt64(txtClient.Text));
                _sale.Date = DateTime.Now;
                _sale.Total = Convert.ToDouble(txtTotal.Text);
                _sale.DetailSales = new List<DetailSale>();
                foreach (DataGridViewRow row in dvgCart.Rows)
                {
                    _detailSale = new DetailSale();
                    _detailSale.Product = _productBol.GetById(Convert.ToInt32(row.Cells[0].Value));
                    _detailSale.Price = Convert.ToDouble(row.Cells[2].Value);
                    _detailSale.Quantity = Convert.ToDouble(row.Cells[3].Value);
                    _sale.DetailSales.Add(_detailSale);
                }
                if (!chkPayment.Checked)
                {
                    _sale.Client.Transactions = new List<Transaction>();
                    Transaction transaction = new Transaction();
                    transaction.IdClient = _sale.Client.IdClient;
                    transaction.Date = _sale.Date;
                    transaction.Amount = _sale.Total * -1;
                    _sale.Client.Transactions.Add(transaction);
                    _sale.Client.Balance -= _sale.Total;
                    if (txtPayment.Text != "")
                    {
                        if (Convert.ToDouble(txtPayment.Text) > 0)
                        {
                            transaction = new Transaction();
                            transaction.IdClient = _sale.Client.IdClient;
                            transaction.Date = _sale.Date;
                            transaction.Amount = Convert.ToDouble(txtPayment.Text);
                            _sale.Client.Transactions.Add(transaction);
                            _sale.Client.Balance += transaction.Amount;
                        }
                    }
                }
                _sale.IdSale = _saleBol.Registrate(_sale);
                if (_saleBol.stringBuilder.Length != 0 )
                {
                    //_saleBol.Delete(_sale.IdSale);
                    MessageBox.Show(_saleBol.stringBuilder.ToString(), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //PrintTicket();
                    MessageBox.Show("Venta registrada con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    dvgCart.Rows.Clear();
                    dvgProducts.Rows.Clear();
                    txtSearch.Clear();
                    txtTotal.Clear();
                    _total = 0;
                    _sale = null;
                    ViewChange(false);
                    _detailSale = null;
                }
            }
            catch (Exception ex)
            {
                //_saleBol.Delete(_sale.IdSale);
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
                    _product = _productBol.GetById(_product.IdProduct);
                    if (_product.Usd)
                    {
                        _product.Cost *= usdValue;
                        _product.Price *= usdValue;
                    }
                    if (_product.Quantity >= Convert.ToDouble(txtQuantity.Text))
                    {
                        bool exists = false;
                        if (dvgCart.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in dvgCart.Rows)
                            {
                                if (Convert.ToInt32(row.Cells[0].Value) == _product.IdProduct)
                                {
                                    exists = true;
                                    if ((Convert.ToDouble(row.Cells[3].Value) +
                                        Convert.ToDouble(txtQuantity.Text)) <= _product.Quantity)
                                    {
                                        _total -= Convert.ToDouble(row.Cells[4].Value);
                                        row.Cells[3].Value = Convert.ToDecimal(row.Cells[3].Value) + Convert.ToDecimal(txtQuantity.Text);
                                        row.Cells[4].Value = Convert.ToDecimal(row.Cells[2].Value)
                                            * Convert.ToDecimal(row.Cells[3].Value);
                                        _total += Convert.ToDouble(row.Cells[4].Value);
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
                            double subTotal = _product.Price * Convert.ToDouble(txtQuantity.Text);
                            dvgCart.Rows.Add(
                                _product.IdProduct,
                                _product.Description,
                                _product.Price,
                                txtQuantity.Text,
                                subTotal
                                );
                            _total += subTotal;
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
                _total -= Convert.ToDouble(dvgCart.CurrentRow.Cells[4].Value);
                dvgCart.CurrentRow.Cells[2].Value = txtPriceCart.Text;
                dvgCart.CurrentRow.Cells[3].Value = txtQuantityCart.Text;
                dvgCart.CurrentRow.Cells[4].Value = Convert.ToDecimal(txtPriceCart.Text)
                    * Convert.ToDecimal(txtQuantityCart.Text);
                _total += Convert.ToDouble(dvgCart.CurrentRow.Cells[4].Value);
                UpdateTotal();
                RemoveSelection(dvgCart);
                ViewChange(false);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dvgCart.Rows.Count > 0)
            {
                _total -= Convert.ToDouble(dvgCart.CurrentRow.Cells[4].Value);
                UpdateTotal();
                dvgCart.Rows.RemoveAt(dvgCart.CurrentRow.Index);
                RemoveSelection(dvgCart);
                ViewChange(false);
            }
        }
        private void btnBudget_Click(object sender, EventArgs e)
        {
            
            if (txtClient.Text != "" && dvgCart.Rows.Count > 0)
            {
                try
                {
                    ReportSaleForm formR = new ReportSaleForm();
                    _sale = new Sale();
                    _sale.IdSale = 0;
                    _sale.Employee = _employeeBol.GetById(Convert.ToInt32(lblEmployee.Text));
                    _sale.Client = _clientBol.GetById(Convert.ToInt64(txtClient.Text));
                    _sale.Date = DateTime.Now;
                    _sale.DetailSales = new List<DetailSale>();
                    foreach (DataGridViewRow row in dvgCart.Rows)
                    {
                        _detailSale = new DetailSale();
                        _detailSale.Product = _productBol.GetById(Convert.ToInt32(row.Cells[0].Value));
                        _detailSale.Price = Convert.ToDouble(row.Cells[2].Value);
                        _detailSale.Quantity = Convert.ToInt32(row.Cells[3].Value);
                        _sale.DetailSales.Add(_detailSale);
                    }
                    _sale.Total = _total;
                    formR._sale = _sale;
                    _sale = null;
                    _detailSale = null;
                    formR.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error", ex.Message);
                }
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            
            try
            {
                ReportSaleForm formR = new ReportSaleForm();
                var sale = _saleBol.GetById(_saleBol.GetLastIdSale());
                sale.DetailSales = _saleBol.GetDetailBySale(sale.IdSale);
                formR._sale = sale;
                formR.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }

        }
        private void btnSell_Click(object sender, EventArgs e)
        {
            Sell();
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Search();
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dvgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgProducts.Rows.Count > 0)
            {
                _product = new Product();
                _product.IdProduct = Convert.ToInt32(dvgProducts.CurrentRow.Cells[0].Value);
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
        private void textBoxInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void txtClient_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtClient.Text.Length >= 7)
                {
                    Client client = _clientBol.GetById(Convert.ToInt64(txtClient.Text));
                    if (client != null)
                    {
                        txtNameClient.Text = client.FirstName + " " + client.LastName;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void chkPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPayment.Checked)
            {
                lblPayment.Visible = false;
                txtPayment.Visible = false;
            }
            else
            {
                lblPayment.Visible = true;
                txtPayment.Visible = true;
            }
        }

        private void chkClient_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClient.Checked)
            {
                txtClient.Text = "20111111112";
                txtClient.Enabled = false;
                txtNameClient.Enabled = false;
                chkPayment.Checked = true;
                chkPayment.Enabled = false;
            }
            else
            {
                txtClient.Text = "";
                txtNameClient.Text = "";
                txtClient.Enabled = true;
                txtNameClient.Enabled = true;
                chkPayment.Enabled = true;
            }
        }
    }
}
