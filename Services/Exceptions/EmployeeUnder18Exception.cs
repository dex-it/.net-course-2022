using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class EmployeeUnder18Exception: Exception
    {
        public EmployeeUnder18Exception(string? message) : base(message)
        {
        }
    }
}
