using Models;
using Xunit;
using Services;

namespace ServiceTests
{
    public class EquivalenceTests
    {
        [Fact]
        public void GetHashCodeNecessityPositivTest()
        {
            //Arrange
            TestDataGenerator testDataGenerator = new TestDataGenerator();
            Dictionary<Client, List<Account>> accounDictionary = testDataGenerator.GetAccounDictionary();
            var firstAccount = accounDictionary.First();

            Client client = new Client
            {
                Name = firstAccount.Key.Name,
                PasportNum = firstAccount.Key.PasportNum,
                BirtDate = firstAccount.Key.BirtDate,
            };

            //Act
            var expectedAccount = accounDictionary[firstAccount.Key];
            var actualAccount = accounDictionary[client];

            //Assert
            Assert.Equal(expectedAccount, actualAccount);
        }


        [Fact]
        public void GetHashCodeNecessityPositivEmployeeTest()
        {
            // Arrange
            TestDataGenerator testDataGenerator = new TestDataGenerator();
            List<Employee> employees = testDataGenerator.GetEmployeesList();
            var firstEmployee = employees.First();

            Employee newEmployee = new Employee
            {
                Name = firstEmployee.Name,
                PasportNum = firstEmployee.PasportNum,
                BirtDate = firstEmployee.BirtDate,
                Salary = firstEmployee.Salary
            };

            //Act
            var actualEmployee = employees.FirstOrDefault(p => p.Equals(newEmployee));
            var isNewEmployeeInList = employees.Contains(newEmployee);

            //Assert
            Assert.Equal(firstEmployee, actualEmployee);
        }
    }
}