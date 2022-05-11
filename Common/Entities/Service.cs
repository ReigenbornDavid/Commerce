using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Service
    {
        private int idService;
        private string description;
        private string details;
        private string client;
        private string tel;
        private decimal price;
        private string state;
        private DateTime date;

        public int IdService { get => idService; set => idService = value; }
        public string Description { get => description; set => description = value; }
        public string Details { get => details; set => details = value; }
        public string Client { get => client; set => client = value; }
        public string Tel { get => tel; set => tel = value; }
        public decimal Price { get => price; set => price = value; }
        public string State { get => state; set => state = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
