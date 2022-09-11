using Services.Exceptions;
using Models;

namespace Services;

public class EmployeeService
{
    private EmployeeStorage _employeeStorage;

    public EmployeeService(EmployeeStorage employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }
    
    public void AddEmployee(Employee employee)
    {
        if (employee.BirthdayDate > DateTime.Now.AddYears(-18))
        {
            throw new AgeLimitException("Сотрудник моложе 18 лет");
        }
        
        if (employee.Passport == 0)
        {
            throw new PassportDataEmptyException("У сотрудника нет паспортных данных");
        }

        _employeeStorage.AddEmployee(employee);
    }
    
    public List<Employee> GetEmployees(EmployeeFilter employeeFilter)
    {
        if (employeeFilter.DateEnd == DateTime.MinValue)
        {
            employeeFilter.DateEnd = DateTime.Today;
        }
        
        var selection = _employeeStorage.Employees.
            Where(c => c.BirthdayDate >= employeeFilter.DateStart).
            Where(c => c.BirthdayDate <= employeeFilter.DateEnd);

        if (!string.IsNullOrEmpty(employeeFilter.FirstName))
            selection = selection.Where(c => c.FirstName == employeeFilter.FirstName);
        
        if (!string.IsNullOrEmpty(employeeFilter.LastName))
            selection = selection.Where(c => c.LastName == employeeFilter.LastName);

        if (employeeFilter.Passport != 0)
            selection = selection.Where(c => c.Passport == employeeFilter.Passport);
        
        if (employeeFilter.PhoneNumber != 0)
            selection = selection.Where(c => c.PhoneNumber == employeeFilter.PhoneNumber);

        if (employeeFilter.Salary != 0)
            selection = selection.Where(c => c.Salary == employeeFilter.Salary);

        return selection.ToList();
    }
}