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
    public partial class CategoryForm : Form
    {
        //Creamos las instancias de la clase Eproducto y ProductoBol
        private Category _category;
        private readonly CategoryBol _categoryBol = new CategoryBol();
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }

        private void Save()
        {
            try
            {
                if (_category == null) _category = new Category();

                _category.name = txtName.Text;

                _categoryBol.Registrate(_category);

                if (_categoryBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_categoryBol.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    MessageBox.Show("Producto registrado/actualizado con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
