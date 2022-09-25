using Models;
using ModelsDb;
using Services.Exceptions;
using Services.Filters;
using Services.Storage;

namespace Services
{
    public class EmployeeService
    {
        DbBank _dbContext;

        public EmployeeService()
        {
            _dbContext = new DbBank();
        }
        public EmployeeDb GetEmployee(Guid employeeId)
        {
            var employee = _dbContext.employees.FirstOrDefault(c => c.Id == employeeId);

            if (employee == null)
            {
                throw new ExistsException("Этого работника не сущетсвует");
            }
            return _dbContext.employees.FirstOrDefault(c => c.Id == employeeId); ;
        }
        public void AddEmployee(EmployeeDb employee)
        {
            if (employee.PasportNum == 0)
            {
                throw new NoPasportData("У работника нет паспортных данных");
            }

            if (DateTime.Now.Year - employee.BirtDate.Year < 18)
            {
                throw new Under18Exception("Работник меньше 18 лет");
            }
            _dbContext.employees.Add(employee);
        }
        public List<EmployeeDb> GetEmployees(EmployeeFilters employeeFilter)
        {
            var selection = _dbContext.employees.Select(p => p);

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
        public void UpdateEmployee(EmployeeDb employee)
        {
            var oldEmployee = _dbContext.employees.FirstOrDefault(c => c.Id == employee.Id);

            if (!_dbContext.employees.Contains(oldEmployee))
            {
                throw new ExistsException("Этого сотрудника не существует");
            }

            oldEmployee.Id = employee.Id;
            oldEmployee.Name = employee.Name;
            oldEmployee.PasportNum = employee.PasportNum;
            oldEmployee.BirtDate = employee.BirtDate;
            oldEmployee.Salary = employee.Salary;

        }
        public void DeleteEmployee(Guid employeeId)
        {
            var employee = _dbContext.employees.FirstOrDefault(c => c.Id == employeeId);

            if (employee == null)
                throw new ExistsException("Этого клиента не сущетсвует");
            else
                _dbContext.employees.Remove(employee);

        }
    }
}