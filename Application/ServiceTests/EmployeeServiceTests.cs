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
        var employeeStorage = new EmployeeStorage();
        var employeeService = new EmployeeService(employeeStorage);

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
        var employeeStorage = new EmployeeStorage();
        var employeeService = new EmployeeService(employeeStorage);

        // Assert
        // Act
        Assert.Throws<PassportDataEmptyException>(() => employeeService.AddEmployee(employee));
    }
    
    [Fact]
    public void GetEmployeesFromFilterPositiveTest()
    {
        // Arrange
        var employeeStorage = new EmployeeStorage();
        var employeeService = new EmployeeService(employeeStorage);
        var dataGenerators = new TestDataGenerator();
        var employeeList = dataGenerators.GetEmployeeList(1000);
        var employeeFilter = new EmployeeFilter()
        {
        };

        // Act
        foreach (var client in employeeList)
        {
            try { employeeService.AddEmployee(client); }
            catch { }
        }
            
        var maxYoungEmployeeDate = employeeService.GetEmployees(employeeFilter)
            .Max(c => c.BirthdayDate);
        var maxYoungClient = employeeService.GetEmployees(employeeFilter)
            .FirstOrDefault(c => c.BirthdayDate.Equals(maxYoungEmployeeDate));
            
        var maxOldEmployeeDate = employeeService.GetEmployees(employeeFilter)
            .Min(c => c.BirthdayDate);
        var maxOldClient = employeeService.GetEmployees(employeeFilter)
            .FirstOrDefault(c => c.BirthdayDate.Equals(maxOldEmployeeDate));

        var averageAgeEmployees = employeeService.GetEmployees(employeeFilter)
            .Average(c => (DateTime.Now.Year - c.BirthdayDate.Year));
            
        // Assert
        if (averageAgeEmployees > 18) Assert.True(true);
        else Assert.True(false);
    }
}