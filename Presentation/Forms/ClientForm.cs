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
                _clientBol.Delete(_client.IdClient);
                MessageBox.Show("Cliente eliminado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtTel.Clear();
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
                _client = _clientBol.GetById(_client.IdClient);
                txtId.Text = _client.IdClient.ToString();
                txtFirstName.Text = _client.FirstName;
                txtLastName.Text = _client.LastName;
                txtAddress.Text = _client.Address;
                txtTel.Text = _client.Tel;
                txtBalance.Text = _client.Balance.ToString();
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
                _client.IdClient = Convert.ToInt64(dvgClients.CurrentRow.Cells[0].Value);
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
                _client.IdClient = Convert.ToInt64(txtId.Text);
                _client.FirstName = txtFirstName.Text;
                _client.LastName = txtLastName.Text;
                _client.Address = txtAddress.Text;
                _client.Tel = txtTel.Text;
                _client.Balance = 0;

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
            List<Client> clients = _clientBol.GetByName(txtSearch.Text);
            if (clients.Count > 0 && clients != null)
            {
                dvgClients.Rows.Clear();
                dvgClients.AutoGenerateColumns = false;
                foreach (var item in clients)
                {
                    dvgClients.Rows.Add(
                        item.IdClient,
                        item.LastName,
                        item.FirstName
                        );
                }
                RemoveSelection(dvgClients);
                ViewAdd();
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
