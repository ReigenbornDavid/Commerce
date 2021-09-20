using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Employee
    {
        public int idEmployee { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public string email { get; set; }
        public string position { get; set; }
        public bool active { get; set; }
    }
}
