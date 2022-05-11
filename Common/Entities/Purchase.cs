using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Purchase
    {
        private int idPurchase;
        private DateTime date;
        private double total;
        private Employee employee;
        private Supplier supplier;
        private List<DetailPurchase> detailPurchases;

        public int IdPurchase { get => idPurchase; set => idPurchase = value; }
        public DateTime Date { get => date; set => date = value; }
        public double Total { get => total; set => total = value; }
        public Employee Employee { get => employee; set => employee = value; }
        public Supplier Supplier { get => supplier; set => supplier = value; }
        public List<DetailPurchase> DetailPurchases { get => detailPurchases; set => detailPurchases = value; }
    }
}
