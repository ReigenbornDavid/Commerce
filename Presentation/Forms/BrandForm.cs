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
    public partial class BrandForm : Form
    {
        private Brand _brand;
        private readonly BrandBol _brandBol = new BrandBol();
        public BrandForm()
        {
            InitializeComponent();
        }

        private void BrandForm_Load(object sender, EventArgs e)
        {
            btnModify.Visible = false;
            txtSearch.Focus();
        }

        private void Save()
        {
            try
            {
                if (_brand == null) _brand = new Brand();

                _brand.Name = txtName.Text;

                _brandBol.Registrate(_brand);

                if (_brandBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_brandBol.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    MessageBox.Show("Marca registrada/actualizada con éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Remove()
        {
            if (_brand != null)
            {
                _brandBol.Delete(_brand.IdBrand);
                MessageBox.Show("Marca eliminada con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Ninguna marca seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtId.Clear();
            txtName.Clear();
            ViewAdd();
            RemoveSelection(dvgBrands);
        }

        private void ViewModify()
        {
            btnModify.Visible = true;
            btnSave.Visible = false;
        }
        private void ViewAdd()
        {
            _brand = null;
            btnModify.Visible = false;
            btnSave.Visible = true;
        }
        public void FillFields()
        {
            try
            {
                _brand = _brandBol.GetById(_brand.IdBrand);
                txtId.Text = _brand.IdBrand.ToString();
                txtName.Text = _brand.Name;
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
            if (dvgBrands.Rows.Count > 0)
            {
                _brand = new Brand();
                _brand.IdBrand = Convert.ToInt32(dvgBrands.CurrentRow.Cells[0].Value);
                FillFields();
                ViewModify();
            }
        }

        private void Search()
        {
            if (txtSearch.Text != "")
            {
                List<Brand> brands = _brandBol.GetAllByName(txtSearch.Text);
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
                    ViewAdd();
                }
                else
                {
                    //MessageBox.Show("No existen marcas registradas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        //Events
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dvgCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClick();
        }
    }
}
