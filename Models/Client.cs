using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client : Person
    {
        public Client(string name, DateTime data, int numPasport) : base(name, data, numPasport)
        {
        }
    }
}
