using Models;
using Services.Exceptions;

namespace Services
{
    public class EmployeeStorage
    {
        public readonly List<Employee> listEmployees = new List<Employee>();
        public void AddEmployee(Employee employee)
        {

            if (employee.PasportNum == 0)
            {
                throw new NoPasportData("У работника нет паспортных данных");
            }

            if (DateTime.Now.Year - employee.BirtDate.Year < 18)
            {
                throw new Under18Exception("Работник меньше 18 лет");
            }
            listEmployees.Add(employee);
        }
    }
}
