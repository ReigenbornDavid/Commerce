using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Sale
    {
        public int idSale { get; set; }
        public DateTime date { get; set; }
        public decimal total { get; set; }
        public Client client { get; set; }
        public Employee employee { get; set; }
        public List<DetailSale> detailSales { get; set; }
    }
}
