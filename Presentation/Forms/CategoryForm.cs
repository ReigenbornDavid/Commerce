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
    public partial class CategoryForm : Form
    {
        private Category _category;
        private readonly CategoryBol _categoryBol = new CategoryBol();
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            btnModify.Visible = false;
            txtSearch.Focus();
        }

        private void Save()
        {
            try
            {
                if (_category == null) _category = new Category();

                _category.Name = txtName.Text;

                _categoryBol.Registrate(_category);

                if (_categoryBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_categoryBol.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    MessageBox.Show("Categoria registrada/actualizada con éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Remove()
        {
            if (_category != null)
            {
                _categoryBol.Delete(_category.IdCategory);
                MessageBox.Show("Categoria eliminada con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Ninguna categria seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtId.Clear();
            txtName.Clear();
            ViewAdd();
            RemoveSelection(dvgCategories);
        }

        private void ViewModify()
        {
            btnModify.Visible = true;
            btnSave.Visible = false;
        }
        private void ViewAdd()
        {
            _category = null;
            btnModify.Visible = false;
            btnSave.Visible = true;
        }
        public void FillFields()
        {
            try
            {
                _category = _categoryBol.GetById(_category.IdCategory);
                txtId.Text = _category.IdCategory.ToString();
                txtName.Text = _category.Name;
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
            if (dvgCategories.Rows.Count > 0)
            {
                _category = new Category();
                _category.IdCategory = Convert.ToInt32(dvgCategories.CurrentRow.Cells[0].Value);
                FillFields();
                ViewModify();
            }
        }
        
        private void Search()
        {
            if (txtSearch.Text != "")
            {
                List<Category> categories = _categoryBol.GetAllByName(txtSearch.Text);
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
                    ViewAdd();
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
