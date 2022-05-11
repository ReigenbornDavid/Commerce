using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Category
    {
        private int idCategory;
        private string name;

        public int IdCategory { get => idCategory; set => idCategory = value; }
        public string Name { get => name; set => name = value; }
    }
}
