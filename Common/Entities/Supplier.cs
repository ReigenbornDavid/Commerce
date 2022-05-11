using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Supplier
    {
        private int idSupplier;
        private string name;
        private bool needInvoice;

        public int IdSupplier { get => idSupplier; set => idSupplier = value; }
        public string Name { get => name; set => name = value; }
        public bool NeedInvoice { get => needInvoice; set => needInvoice = value; }
    }
}
