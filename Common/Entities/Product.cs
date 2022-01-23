using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Product
    {
        public int idProduct { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public decimal cost { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public Category category { get; set; }
        public Supplier supplier { get; set; }
    }
}
