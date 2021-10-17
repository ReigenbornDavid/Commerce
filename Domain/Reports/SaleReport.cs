using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reports
{
    public class SaleReport
    {
        public int idSale { get; set; }
        public DateTime date { get; set; }
        public decimal total { get; set; }
        public Int64 dniClient { get; set; }
        public int dniEmployee { get; set; }
        
    }
}
