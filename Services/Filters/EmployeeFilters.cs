using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Filters
{
    public class EmployeeFilters
    {
        public string Name { get; set; }
        public DateTime BirtDate { get; set; }
        public int PasportNum { get; set; }
        public string Contract { get; set; }
        public int Salary { get; set; }
    }
}
