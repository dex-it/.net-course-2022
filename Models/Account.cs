using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Account : Client
    {
        public string Currency { get; set; }
        public int Amount { get; set; }
    }
}
