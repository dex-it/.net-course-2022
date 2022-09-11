using Models;
using Services.Exceptions;

namespace Services
{
    public class EmployeeService
    {
        private EmployeeStorage _employeeStorage { get; set; }
        public EmployeeService(EmployeeStorage employeeStorage)
        {
            this._employeeStorage = employeeStorage;
        }
        public void AddEmployee(Employee employee)
        { 
            _employeeStorage.AddEmployee(employee);
        }
    }
}
