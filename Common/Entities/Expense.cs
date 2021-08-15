using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Expense
    {
        public int idExpense { get; set; }
        public string description { get; set; }
        public Purchase purchase { get; set; }
    }
}
