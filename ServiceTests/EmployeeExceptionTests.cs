using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Services;
using Models;
using Services.Exceptions;

namespace ServiceTests
{
    public class EmployeeExceptionTests
    {
        [Fact]
        public void AddEmployeeOrThrow()
        {
            var employeeService = new EmployeeService();
            var ivan = new Employee
            {
                Name = "Ivan",
                BirtDate = new DateTime(2006, 01, 01)
            };
            var kolya = new Employee
            {
                Name = "Kolya",
                BirtDate = new DateTime(2001, 01, 01),
                PasportNum = 324763
            };
            try
            {
                //employeeService.AddEmployee(ivan);
                employeeService.AddEmployee(kolya);
            }
            catch (EmployeeNoPasportData e)
            {
                Assert.Equal("У клиента нет паспортных данных", e.Message);
                Assert.Equal(typeof(EmployeeNoPasportData), e.GetType());
            }
            catch (EmployeeUnder18Exception e)
            {
                Assert.Equal("Клиенту меньше 18", e.Message);
                Assert.Equal(typeof(EmployeeUnder18Exception), e.GetType());
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
        }
    }
}
