using Models;
using Services;
using Xunit;

namespace ServiceTests;

public class EquivalenceTests
{
    [Fact]
    public void GetHashCodeNecessityPositiveTest()
    {
        // Arrange
        var dataGenerators = new TestDataGenerator();
        var clientCollection = dataGenerators.GetClientList(10);
        var clientAccountDictionary = dataGenerators.GetClientAccountDictionary(clientCollection);
        var firstClient = clientCollection.First();
        
        // Act
        var newClient = new Client
        {
            FirstName = firstClient.FirstName,
            LastName = firstClient.LastName,
            BirthdayDate = firstClient.BirthdayDate,
            PhoneNumber = firstClient.PhoneNumber
        };
        var firstClientAccount = clientAccountDictionary[newClient];

        // Assert
        Assert.True(true);
    }
    
    [Fact]
    public void GetEmployeeEqualsNecessityPositiveTest()
    {
        // Arrange
        var dataGenerators = new TestDataGenerator();
        var employeeList = dataGenerators.GetEmployeeList(10);
        var firstEmployee = employeeList.First();

        // Act
        var newEmployee = new Employee()
        {
            Salary = firstEmployee.Salary,
            Contract = firstEmployee.Contract,
            FirstName = firstEmployee.FirstName,
            LastName = firstEmployee.LastName,
            BirthdayDate = firstEmployee.BirthdayDate,
            PhoneNumber = firstEmployee.PhoneNumber
        };

        // Assert
        Assert.Equal(employeeList.First(), newEmployee);
    }
}