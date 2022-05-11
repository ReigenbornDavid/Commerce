using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Transaction
    {
        private Int64 idTransaction;
        private Int64 idClient;
        private double amount;
        private DateTime date;
        private Client client;

        public long IdTransaction { get => idTransaction; set => idTransaction = value; }
        public long IdClient { get => idClient; set => idClient = value; }
        public double Amount { get => amount; set => amount = value; }
        public DateTime Date { get => date; set => date = value; }
        public Client Client { get => client; set => client = value; }
    }
}
