using Xunit;
using Services;
using Models;
using Services.Exceptions;
using Services.Filters;

namespace ServiceTests
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void GetEmployeesFilterTest()
        {
            // Arrange
            var employeeFilters = new EmployeeFilters();
            var employeeStorage = new EmployeeStorage();
            var testDataGenerator = new TestDataGenerator();


            for (int i = 0; i < 5; i++)
            {
                employeeStorage.AddEmployee(testDataGenerator.GetFakeDataEmployee().Generate());
            }
            var employeeService = new EmployeeService(employeeStorage);

            //Act
            var youngClient = employeeStorage._listEmployees.Min(p => p.BirtDate);
            var oldClient = employeeStorage._listEmployees.Max(p => p.BirtDate);
            var averageAge = employeeStorage._listEmployees.Average(p => DateTime.Now.Year - p.BirtDate.Year);

            //Assert
            if (averageAge > 18)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }

        //[Fact]
        //public void AddEmployeeLimit18YearsExceptionTest()
        //{
        //    var employeeService = new EmployeeService();
        //    var ivan = new Employee
        //    {
        //        Name = "Ivan",
        //        BirtDate = new DateTime(2006, 01, 01),
        //        PasportNum = 324763
        //    };
        //    try
        //    {
        //        employeeService.AddEmployee(ivan);
        //    }
        //    catch (Under18Exception e)
        //    {
        //        Assert.Equal("Работнику меньше 18", e.Message);
        //        Assert.Equal(typeof(Under18Exception), e.GetType());
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.True(false);
        //    }
        //}
        //[Fact]
        //public void AddEmployeeNoPasportDataExceptionTest()
        //{
        //    var employeeService = new EmployeeService();
        //    var ivan = new Employee
        //    {
        //        Name = "Ivan",
        //        BirtDate = new DateTime(2000, 01, 01)
        //    };
        //    try
        //    {
        //        employeeService.AddEmployee(ivan);
        //    }
        //    catch (NoPasportData e)
        //    {
        //        Assert.Equal("У работника нет паспортных данных", e.Message);
        //        Assert.Equal(typeof(NoPasportData), e.GetType());
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.True(false);
        //    }
        //}
    }
}
