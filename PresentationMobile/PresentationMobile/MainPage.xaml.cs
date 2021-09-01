using Common.Entities;
using Domain.BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PresentationMobile
{
    public partial class MainPage : ContentPage
    {
        private readonly ProductBol _productBol = new ProductBol();
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            List<Product> products = _productBol.GetProducts() ;
            if (products != null && products.Count > 0)
            {
                lstProducts.ItemsSource = products;
            }
        }
    }
}
