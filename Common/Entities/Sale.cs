using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Sale
    {
        private int idSale;
        private DateTime date;
        private double total;
        private Client client;
        private Employee employee;
        private List<DetailSale> detailSales;

        public int IdSale { get => idSale; set => idSale = value; }
        public DateTime Date { get => date; set => date = value; }
        public double Total { get => total; set => total = value; }
        public Client Client { get => client; set => client = value; }
        public Employee Employee { get => employee; set => employee = value; }
        public List<DetailSale> DetailSales { get => detailSales; set => detailSales = value; }
    }
}
