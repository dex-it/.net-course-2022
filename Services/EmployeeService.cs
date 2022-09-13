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
            List<Employee> filterList = new List<Employee>();

            if (employeeFilter.Name != null)
                filterList = _iEmployeeStorage.Data.
                    Where(p => p.Name == employeeFilter.Name).ToList();

            if (employeeFilter.PasportNum != 0)
                filterList = _iEmployeeStorage.Data.
                    Where(p => p.PasportNum == employeeFilter.PasportNum).ToList();

            if (employeeFilter.StartDate != new DateTime())
                filterList = _iEmployeeStorage.Data.
                    Where(p => p.BirtDate == employeeFilter.StartDate).ToList();

            if (employeeFilter.EndDate != new DateTime())
                filterList = _iEmployeeStorage.Data.
                    Where(p => p.BirtDate == employeeFilter.EndDate).ToList();

            if (employeeFilter.Salary != 0)
                filterList = _iEmployeeStorage.Data.
                    Where(p => p.PasportNum == employeeFilter.PasportNum).ToList();

            return filterList;
        }
    }
}
