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
    public partial class ClientForm : Form
    {
        private Client _client;
        private readonly ClientBol _clientBol = new ClientBol();
        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            ViewAdd();
            txtSearch.Focus();
        }
        private void Remove()
        {
            if (_client != null)
            {
                _clientBol.Delete(_client.idClient);
            }
            else
            {
                MessageBox.Show("Error: Ningun cliente seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Clear()
        {
            txtId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            ViewAdd();
            RemoveSelection(dvgClients);
        }
        private void ViewModify()
        {
            btnModify.Visible = true;
            btnSave.Visible = false;
        }
        private void ViewAdd()
        {
            _client = null;
            btnModify.Visible = false;
            btnSave.Visible = true;
        }
        public void FillFields()
        {
            try
            {
                _client = _clientBol.GetById(_client.idClient);
                txtId.Text = _client.idClient.ToString();
                txtFirstName.Text = _client.firstName;
                txtLastName.Text = _client.lastName;
                txtAddress.Text = _client.address;
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
            if (dvgClients.Rows.Count > 0)
            {
                _client = new Client();
                _client.idClient = Convert.ToInt32(dvgClients.CurrentRow.Cells[0].Value);
                FillFields();
                ViewModify();
            }
        }
        private void Save()
        {
            try
            {
                if (_client == null)
                {
                    _client = new Client();
                }
                _client.idClient = Convert.ToInt32(txtId.Text);
                _client.firstName = txtFirstName.Text;
                _client.lastName = txtLastName.Text;
                _client.address = txtAddress.Text;

                _clientBol.Registrate(_client);

                if (_clientBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_clientBol.stringBuilder.ToString(), "Para continuar:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cliente registrado/actualizado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Search();
                    _client = null;
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
                List<Client> clients = _clientBol.GetByName(txtSearch.Text);
                if (clients.Count > 0 && clients != null)
                {
                    dvgClients.Rows.Clear();
                    dvgClients.AutoGenerateColumns = false;
                    foreach (var item in clients)
                    {
                        dvgClients.Rows.Add(
                            item.idClient,
                            item.firstName,
                            item.lastName
                            );
                    }
                    RemoveSelection(dvgClients);
                    ViewAdd();
                }
                else
                {
                    MessageBox.Show("No existen clientes registrados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Buttons
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Save();
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void textBoxInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dvgClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClick();
        }
    }
}
