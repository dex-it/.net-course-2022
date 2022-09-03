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
        var clientCollection = dataGenerators.GetClientCollection(10);
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
    public void GetEmployeeHashCodeNecessityPositiveTest()
    {
        // Arrange
        var dataGenerators = new TestDataGenerator();
        var employeeCollection = dataGenerators.GetEmployeeCollection(10);
        var firstEmployee = employeeCollection.First();

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
        Assert.Equal(employeeCollection.First(), newEmployee);
    }
}