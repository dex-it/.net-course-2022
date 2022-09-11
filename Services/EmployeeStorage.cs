using Models;
using Services.Exceptions;

namespace Services
{
    public class EmployeeStorage
    {
        public readonly List<Employee> listEmployees = new List<Employee>();
        public void AddEmployee(Employee employee)
        {
            listEmployees.Add(employee);
        }
    }
}
