using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Expense
    {
        private int idExpense;
        private string description;
        private decimal price;
        private DateTime date;

        public int IdExpense { get => idExpense; set => idExpense = value; }
        public string Description { get => description; set => description = value; }
        public decimal Price { get => price; set => price = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
