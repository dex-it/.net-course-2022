using Models;
using Services;
using Xunit;

namespace ServiceTests;

public class BankServiceTests
{
    [Fact]
    public void AddBonusPositiveTest()
    {
        // Arrange
        var bankService = new BankService();
        var client = new Client
        {
            FirstName = "Иван",
            LastName = "Иванов",
        };
        var defaultClientBonus = client.Bonus;
        
        // Assert
        client = bankService.AddBonus(client);
        
        // Act
        if (defaultClientBonus < client.Bonus) { Assert.True(true); }
        else { Assert.True(false); }
    }
    
    [Fact]
    public void AddToBlackListAndCheckBlackListPositiveTest()
    {
        // Arrange
        var bankService = new BankService();
        var employee = new Employee
        {
            FirstName = "Иван",
            LastName = "Иванов",
        };
        
        // Assert
        bankService.AddToBlackList(employee);
        
        // Act
        Assert.True(bankService.IsPersonInBlackList(employee));
    }
}