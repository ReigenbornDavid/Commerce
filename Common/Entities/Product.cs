using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Product
    {
        private int idProduct;
        private string code;
        private string description;
        private double cost;
        private double price;
        private double quantity;
        private Category category;
        private Supplier supplier;
        private Brand brand;
        private bool usd;

        public int IdProduct { get => idProduct; set => idProduct = value; }
        public string Code { get => code; set => code = value; }
        public string Description { get => description; set => description = value; }
        public double Cost { get => cost; set => cost = value; }
        public double Price { get => price; set => price = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public Category Category { get => category; set => category = value; }
        public Supplier Supplier { get => supplier; set => supplier = value; }
        public Brand Brand { get => brand; set => brand = value; }
        public bool Usd { get => usd; set => usd = value; }
    }
}
