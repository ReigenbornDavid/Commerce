using Common.Entities;
using Domain.BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class ServiceForm : Form
    {
        private readonly ServiceBol _serviceBol = new ServiceBol();
        private Service _service = new Service();
        private readonly ClientBol _clientBol = new ClientBol();
        private readonly EmployeeBol _employeeBol = new EmployeeBol();
        public ServiceForm()
        {
            InitializeComponent();
        }

        private void ServiceForm_Load(object sender, EventArgs e)
        {
            txtState.Text = "RECIBIDO";
            txtStateFilter.Text = "TERMINADO";
            ViewAdd();
            txtSearch.Focus();
        }

        private void Add()
        {
            try
            {
                bool print = false;
                if (_service == null)
                {
                    _service = new Service();
                    _service.Price = 0;
                    print = true;
                }
                else
                {
                    _service.IdService = Convert.ToInt32(txtId.Text);
                    _service.Price = Convert.ToDecimal(txtPrice.Text);
                }
                _service.Description = txtDescription.Text;
                _service.Details = txtDetails.Text;
                _service.Date = DateTime.Now;
                _service.State = txtState.Text;
                _service.Tel = txtTel.Text;
                _service.Client = txtClient.Text;
                _service.IdService = _serviceBol.Registrate(_service);
                if (_serviceBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_serviceBol.stringBuilder.ToString(), "Para continuar:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //PrintTicket(print, 0);
                    MessageBox.Show("Servicio registrado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //PrintTicket(print, 1);
                    Clear();
                    _service = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
        private void PrintTicket(bool print, int type)
        {
            if (print)
            {
                PrintDocument pd = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                pd.PrinterSettings = ps;
                Margins margins = new Margins(0, 0, 0, 0);
                pd.DefaultPageSettings.Margins = margins;
                if (type == 0)
                {
                    pd.PrintPage += PrintClient;
                }
                else
                {
                    pd.PrintPage += PrintEmployee;
                }
                pd.Print();
            }
        }


        private void PrintClient(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 9);
            int ancho = 300;
            int y = 0;
            e.Graphics.DrawImage(Image.FromFile("Images/Icon.png"), 0, 0, 70, 70);
            e.Graphics.DrawString("ELECTRONORTE", font, Brushes.Black, new RectangleF(80, y + 10, ancho, 20));
            e.Graphics.DrawString("Codigo: "+_service.idService.ToString(), font, Brushes.Black, new RectangleF(80, y + 30, ancho, 20));
            y += 60;
            string linea = _service.date.ToString();
            e.Graphics.DrawString(linea, font, Brushes.Black, new RectangleF(0, y+=20, ancho, 20));
            linea = _service.description;
            e.Graphics.DrawString(linea, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));

            linea = _service.state;
            e.Graphics.DrawString(linea, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
        }
        private void PrintEmployee(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 9);
            int ancho = 300;
            int y = 0;
            e.Graphics.DrawImage(Image.FromFile("Images/Icon.png"), 0, 0, 70, 70);
            e.Graphics.DrawString("ELECTRONORTE", font, Brushes.Black, new RectangleF(80, y + 10, ancho, 20));
            e.Graphics.DrawString("Codigo: " + _service.idService.ToString(), font, Brushes.Black, new RectangleF(80, y + 30, ancho, 20));
            y += 60;
            string linea = _service.date.ToString();
            e.Graphics.DrawString(linea, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            linea = _service.client;
            e.Graphics.DrawString(linea, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            linea = _service.tel;
            e.Graphics.DrawString(linea, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
        }

        */

        private void Clear()
        {
            _service = null;
            ViewAdd();
            txtId.Clear();
            txtDetails.Clear();
            txtDescription.Clear();
            txtState.Text = "RECIBIDO";
            txtClient.Clear();
            txtPrice.Text = "0";
            txtDate.Clear();
            txtTel.Clear();
        }
        private void Remove()
        {
            if (_service != null)
            {
                _serviceBol.Delete(_service.IdService);
            }
            else
            {
                MessageBox.Show("Error: Ningun servicio seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ViewModify()
        {
            btnModify.Visible = true;
            btnSave.Visible = false;
        }
        private void ViewAdd()
        {
            _service = null;
            txtPrice.Text = "0";
            btnModify.Visible = false;
            btnSave.Visible = true;
        }
        public void FillFields()
        {
            try
            {
                _service = _serviceBol.GetById(_service.IdService);
                txtId.Text = _service.IdService.ToString();
                txtDescription.Text = _service.Description;
                txtDetails.Text = _service.Details;
                txtPrice.Text = _service.Price.ToString();
                txtDate.Text = _service.Date.ToString();
                txtState.Text = _service.State;
                txtClient.Text = _service.Client;
                txtTel.Text = _service.Tel;
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
            if (dvgServices.Rows.Count > 0)
            {
                _service = new Service();
                _service.IdService = Convert.ToInt32(dvgServices.CurrentRow.Cells[0].Value);
                FillFields();
                ViewModify();
            }
        }
        private void Search()
        {
            if (txtSearch.Text != "")
            {
                List<Service> services = _serviceBol.GetByName(txtSearch.Text, txtStateFilter.Text);
                if (services.Count > 0 && services != null)
                {
                    dvgServices.Rows.Clear();
                    dvgServices.AutoGenerateColumns = false;
                    foreach (var item in services)
                    {
                        dvgServices.Rows.Add(
                            item.IdService,
                            item.Description
                            );
                    }
                    RemoveSelection(dvgServices);
                    ViewAdd();
                }
            }
        }
        //Buttons
        private void btnSave_Click(object sender, EventArgs e)
        {
            Add();
            Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            Add();
            Clear();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        //Events
        private void textBoxInt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dvgServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClick();
        }

        
    }
}
