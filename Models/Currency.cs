using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Currency
    {
        public Currency(string nameCurrency)
        {
            NameCurrency = nameCurrency;
        }

        public string NameCurrency { get; set; }
    }
}
