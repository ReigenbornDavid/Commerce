using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class DetailPurchase
    {
        private int idDetailPurchase;
        private double price;
        private double quantity;
        private Product product;
        private Purchase purchase;

        public int IdDetailPurchase { get => idDetailPurchase; set => idDetailPurchase = value; }
        public double Price { get => price; set => price = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public Product Product { get => product; set => product = value; }
        public Purchase Purchase { get => purchase; set => purchase = value; }
    }
}
