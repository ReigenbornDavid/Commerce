using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class DetailSale
    {
        private int idDetailSale;
        private double price;
        private double quantity;
        private Product product;
        private Sale sale;

        public int IdDetailSale { get => idDetailSale; set => idDetailSale = value; }
        public double Price { get => price; set => price = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public Product Product { get => product; set => product = value; }
        public Sale Sale { get => sale; set => sale = value; }
    }
}
