using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Employee
    {

        public Employee() { Name = string.Empty; Id = 0; }
        public string Name { get; set; }
        public int Id { get; set; }
        public float Rate { get; set; }


        public override string ToString() => Name ?? string.Empty;

    }
}
