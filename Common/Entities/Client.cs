using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Client
    {
        private Int64 idClient;
        private string firstName;
        private string lastName;
        private string address;
        private string tel;
        private double balance;
        private List<Transaction> transactions;

        public long IdClient { get => idClient; set => idClient = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string Tel { get => tel; set => tel = value; }
        public double Balance { get => balance; set => balance = value; }
        public List<Transaction> Transactions { get => transactions; set => transactions = value; }
    }
}
