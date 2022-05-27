using Common.Entities;
using Domain.Reports;
using Microsoft.Reporting.WinForms;
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

namespace Presentation.ReportForms
{
    public partial class ReportSaleForm : Form
    {
        //Instances
        public Sale _sale { get; set; }
        public ReportSaleForm()
        {
            InitializeComponent();
        }

        private void ReportSaleForm_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            ShowReport();
        }

        public void ShowReport()
        {
            try
            {
                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DetailSale", GetSaleReport(_sale));
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("date", _sale.Date.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("dniClient", _sale.Client.IdClient.ToString()));
                string type;
                if (_sale.IdSale != 0)
                {
                    type = "Comprobante";
                }
                else
                {
                    type = "Presupuesto";
                }
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("type", type));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("idSale", _sale.IdSale.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("total", _sale.Total.ToString()));
                this.reportViewer1.RefreshReport();
                PageSettings pageSettins = new PageSettings();
                pageSettins.PaperSize = this.reportViewer1.LocalReport.GetDefaultPageSettings().PaperSize;
                pageSettins.Landscape = this.reportViewer1.LocalReport.GetDefaultPageSettings().IsLandscape;
                pageSettins.Margins = this.reportViewer1.LocalReport.GetDefaultPageSettings().Margins;
                //this.reportViewer1.LocalReport.Print(pageSettins);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<DetailSaleReport> GetSaleReport(Sale _sale)
        {
            DetailSaleReport _detailSaleReport = new DetailSaleReport();
            List<DetailSaleReport> detailSaleList = new List<DetailSaleReport>();
            foreach (var item in _sale.DetailSales)
            {
                _detailSaleReport = new DetailSaleReport();
                _detailSaleReport.description = item.Product.Description + " " + item.Product.Brand.Name;
                _detailSaleReport.price = item.Price;
                _detailSaleReport.quantity = item.Quantity;
                _detailSaleReport.total = item.Price * item.Quantity;
                detailSaleList.Add(_detailSaleReport);
            }
            return detailSaleList;
        }
    }
}
