using Models;
using Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService
    {
        public void AddEmployee(Employee employee)
        {
            if (employee.PasportNum == 0)
            {
                throw new EmployeeNoPasportData("У работника нет паспортных данных");
            }

            if (DateTime.Now.Year - employee.BirtDate.Year < 18)
            {
                throw new EmployeeUnder18Exception("Работник меньше 18 лет");
            }
        }
    }
}
