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
    public partial class EmployeeForm : Form
    {
        private Employee _employee;
        private readonly EmployeeBol _employeeBol = new EmployeeBol();
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            ViewAdd();
            txtSearch.Focus();
            txtActive.Text = "Activo";
        }
        private void Remove()
        {
            if (_employee != null)
            {
                _employeeBol.Delete(_employee.IdEmployee);
                MessageBox.Show("Empleado eliminado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Ningun empleado seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Clear()
        {
            txtId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtUser.Clear();
            txtPass.Clear();
            txtEmail.Clear();
            txtPosition.Clear();
            txtActive.Text = "Activo";
            ViewAdd();
            RemoveSelection(dvgEmployees);
        }
        private void ViewModify()
        {
            btnModify.Visible = true;
            btnSave.Visible = false;
        }
        private void ViewAdd()
        {
            _employee = null;
            btnModify.Visible = false;
            btnSave.Visible = true;
        }
        public void FillFields()
        {
            try
            {
                _employee = _employeeBol.GetById(_employee.IdEmployee);
                txtId.Text = _employee.IdEmployee.ToString();
                txtFirstName.Text = _employee.FirstName;
                txtLastName.Text = _employee.LastName;
                txtUser.Text = _employee.User;
                txtPass.Text = _employee.Pass;
                txtEmail.Text = _employee.Email;
                txtPosition.Text = _employee.Position;
                txtActive.Text = ConvertBooleanToString(_employee.Active);
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
            if (dvgEmployees.Rows.Count > 0)
            {
                _employee = new Employee();
                _employee.IdEmployee = Convert.ToInt32(dvgEmployees.CurrentRow.Cells[0].Value);
                FillFields();
                ViewModify();
            }
        }

        private bool ConvertStringToBoolean(string text)
        {
            if (text == "Activo")
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
                return "Activo";
            }
            else
            {
                return "Inactivo";
            }
        }

        private void Save()
        {
            try
            {
                if (_employee == null)
                {
                    _employee = new Employee();
                }
                _employee.IdEmployee = Convert.ToInt32(txtId.Text);
                _employee.FirstName = txtFirstName.Text;
                _employee.LastName = txtLastName.Text;
                _employee.User = txtUser.Text;
                _employee.Pass = txtPass.Text;
                _employee.Email = txtEmail.Text;
                _employee.Position = txtPosition.Text;
                _employee.Active = ConvertStringToBoolean(txtActive.Text);

                _employeeBol.Registrate(_employee);

                if (_employeeBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_employeeBol.stringBuilder.ToString(), "Para continuar:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Empleado registrado/actualizado con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Search();
                    _employee = null;
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
                List<Employee> employees = _employeeBol.GetByName(txtSearch.Text);
                if (employees.Count > 0 && employees != null)
                {
                    dvgEmployees.Rows.Clear();
                    dvgEmployees.AutoGenerateColumns = false;
                    foreach (var item in employees)
                    {
                        dvgEmployees.Rows.Add(
                            item.IdEmployee,
                            item.FirstName,
                            item.LastName
                            );
                    }
                    RemoveSelection(dvgEmployees);
                    ViewAdd();
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
            Search();
            Clear();
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
