using Models;
using Services.Exceptions;
using Services.Filters;
using Services.Storage;

namespace Services
{
    public class EmployeeService
    {
        private IEmployeeStorage _iEmployeeStorage { get; set; }

        public EmployeeService(IEmployeeStorage iEmployeeStorage)
        {
            _iEmployeeStorage = iEmployeeStorage;
        }

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
            _iEmployeeStorage.Add(employee);
        }
        public List<Employee> GetEmployees(EmployeeFilters employeeFilter)
        {
            var selection = _iEmployeeStorage.Data.Select(p => p);

            if (employeeFilter.Name != null)
                selection = selection.
                    Where(p => p.Name == employeeFilter.Name);

            if (employeeFilter.PasportNum != 0)
                selection = selection.
                   Where(p => p.PasportNum == employeeFilter.PasportNum);

            if (employeeFilter.StartDate != new DateTime())
                selection = selection.
                   Where(p => p.BirtDate == employeeFilter.StartDate);

            if (employeeFilter.EndDate != new DateTime())
                selection = selection.
                   Where(p => p.BirtDate == employeeFilter.EndDate);

            if (employeeFilter.Salary != 0)
                selection = selection.
                   Where(p => p.PasportNum == employeeFilter.PasportNum);

            return selection.ToList();
        }
    }
}
