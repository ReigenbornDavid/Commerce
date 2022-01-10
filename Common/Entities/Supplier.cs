using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Supplier
    {
        public int idSupplier { get; set; }
        public string name { get; set; }
        public bool needInvoice { get; set; }
    }
}
