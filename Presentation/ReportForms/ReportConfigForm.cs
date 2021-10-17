using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.ReportForms
{
    public partial class ReportConfigForm : Form
    {
        public ReportConfigForm()
        {
            InitializeComponent();
        }

        private void ReportConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBeginDate.Text != "" && txtEndDate.Text != "")
                {
                    //ReporteForm Reporte = new ReporteForm();
                    //Reporte.FechaInicio = txt_Fecha_Inicio.Value.ToString("yyyy-MM-dd HH:mm");
                    //Reporte.FechaFin = txt_Fecha_fin.Value.ToString("yyyy-MM-dd HH:mm");
                    //Reporte.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
