using Services.Exceptions;
using Models;

namespace Services;

public class EmployeeService
{
    private readonly List<Employee> _employees;

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

        _employees.Add(employee);
    }
}