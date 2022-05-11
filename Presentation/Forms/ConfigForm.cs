using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Presentation.Forms
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            Read();
        }

        private void Read()
        {
            txtProfit.Text = ConfigurationManager.AppSettings["profit"];
            txtTax.Text = ConfigurationManager.AppSettings["tax"];
            txtUsd.Text = ConfigurationManager.AppSettings["usd"];
        }

        private void Save()
        {
            string newProfit = txtProfit.Text;
            string newTax = txtTax.Text;
            string newUsd = txtUsd.Text;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement element in xmlDocument.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes[0].Value == "profit")
                        {
                            node.Attributes[1].Value = newProfit;
                        }
                        if (node.Attributes[0].Value == "tax")
                        {
                            node.Attributes[1].Value = newTax;
                        }
                        if (node.Attributes[0].Value == "usd")
                        {
                            node.Attributes[1].Value = newUsd;
                        }
                    }
                }
            }
            xmlDocument.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("appSettings");
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
