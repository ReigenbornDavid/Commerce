using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Service
    {
        public int idService { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public DateTime date { get; set; }
        public Client client { get; set; }
        public Employee employee { get; set; }
        public Sale sale { get; set; }
    }
}
