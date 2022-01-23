using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class DetailPurchase
    {
        public int idDetailPurchase { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public Product product { get; set; }
        public Purchase purchase { get; set; }
    }
}
