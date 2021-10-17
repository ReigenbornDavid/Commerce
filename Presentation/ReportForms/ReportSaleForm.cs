using Common.Entities;
using Domain.BOL;
using Domain.Reports;
using Microsoft.Reporting.WinForms;
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
    public partial class ReportSaleForm : Form
    {
        //Instances
        public int _idSale { get; set; }
        SaleBol _saleBol = new SaleBol();
        public ReportSaleForm()
        {
            InitializeComponent();
        }

        private void ReportSaleForm_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            ShowReport();
        }

        private void ShowReport()
        {
            try
            {
                Sale _sale = _saleBol.GetById(_idSale);
                this.reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DetailSale", GetSaleReport(_sale));
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("date", _sale.date.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("dniClient", _sale.client.idClient.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("dniEmployee", _sale.employee.idEmployee.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("idSale", _sale.idSale.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("total", _sale.total.ToString()));
                this.reportViewer1.RefreshReport();
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
            _sale.detailSales = _saleBol.GetDetailBySale(_sale.idSale);
            foreach (var item in _sale.detailSales)
            {
                _detailSaleReport.description = item.product.description;
                _detailSaleReport.price = item.price;
                _detailSaleReport.quantity = item.quantity;
                _detailSaleReport.total = item.price * item.quantity;
                detailSaleList.Add(_detailSaleReport);
            }
            return detailSaleList;
        }
    }
}
