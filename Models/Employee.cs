using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee: Person
    {
        public Employee( string name, DateTime data, int numPasport) : base(name, data, numPasport)
        {
        }
        public string Contract { get; set; }
    }
}
