using Models;
using Services;
using Services.Exceptions;
using Xunit;

namespace ServiceTests;

public class EmployeeServiceTests
{
    [Fact]
    public void GetEmployeeAgeLimitExceptionPositiveTest()
    {
        // Arrange
        var employee = new Employee
        {
            FirstName = "Иван",
            LastName = "Иванов",
            BirthdayDate = new DateTime(2008, 01, 01)
        };
        var employeeService = new EmployeeService();

        // Assert
        // Act
        Assert.Throws<AgeLimitException>(() => employeeService.AddEmployee(employee));
    }
        
    [Fact]
    public void GetEmployeePassportDataEmptyExceptionPositiveTest()
    {
        // Arrange
        var employee = new Employee
        {
            FirstName = "Иван",
            LastName = "Иванов",
            BirthdayDate = new DateTime(2001, 01, 01)
        };
        var employeeService = new EmployeeService();

        // Assert
        // Act
        Assert.Throws<PassportDataEmptyException>(() => employeeService.AddEmployee(employee));
    }
}