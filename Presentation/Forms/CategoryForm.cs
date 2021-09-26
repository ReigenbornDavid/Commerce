﻿using Common.Entities;
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
                    MessageBox.Show("Categoria registrada/actualizada con éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
