using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Employee
    {
        private int idEmployee;
        private string firstName;
        private string lastName;
        private string user;
        private string pass;
        private string email;
        private string position;
        private bool active;

        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Email { get => email; set => email = value; }
        public string Position { get => position; set => position = value; }
        public bool Active { get => active; set => active = value; }
    }
}
