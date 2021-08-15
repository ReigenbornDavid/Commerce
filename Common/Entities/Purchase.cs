using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Purchase
    {
        public int idPurchase { get; set; }
        public DateTime date { get; set; }
        public Employee employee { get; set; }
    }
}
