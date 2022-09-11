using Models;
using Services.Exceptions;

namespace Services
{
    public class EmployeeStorage
    {
        public readonly List<Employee> _listEmployees = new List<Employee>();
        public void AddEmployee(Employee employee)
        {
            _listEmployees.Add(employee);
        }
    }
}
