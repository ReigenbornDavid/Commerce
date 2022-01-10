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
        public string codeProduct { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public Category category { get; set; }
    }
}
