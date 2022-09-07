using Services;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Services.Exceptions;

namespace ServiceTests
{
    public class ClientServiceTests
    {
        [Fact]
        public void AddClientLimit18YearsExceptionTest()
        {
            var clientService = new ClientService();
            var ivan = new Client
            {
                Name = "Ivan",
                BirtDate = new DateTime(2006, 01, 01),
                PasportNum = 324763
            };
            try
            {
                clientService.AddClient(ivan);
            }
            catch (Under18Exception e)
            {
                Assert.Equal("Клиенту меньше 18", e.Message);
                Assert.Equal(typeof(Under18Exception), e.GetType());
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
        }
        [Fact]
        public void AddClientNoPasportDataExceptionTest()
        {
            var clientService = new ClientService();
            var ivan = new Client
            {
                Name = "Ivan",
                BirtDate = new DateTime(2006, 01, 01),
                PasportNum = 324763
            };
            try
            {
                clientService.AddClient(ivan);
            }
            catch (NoPasportData e)
            {
                Assert.Equal("У клиента нет паспортных данных", e.Message);
                Assert.Equal(typeof(NoPasportData), e.GetType());
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
        }
        [Fact]
        public void AddAccountExistsException()
        {
            var clientService = new ClientService();
            var ivan = new Client
            {
                Name = "Ivan",
                BirtDate = new DateTime(2006, 01, 01),
                PasportNum = 324763
            };
            var accountIvan = new Account
            {
                Currency = new Currency
                {
                    Name = "Euro",
                    Code = 8
                },
                Amount = 45
            };
            try
            {
                clientService.AddAccount(ivan,accountIvan);
            }
            catch (AccountExistsException e)
            {
                Assert.Equal(("Такой клиент уже существует"), e.Message);
                Assert.Equal(typeof(AccountExistsException), e.GetType());
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
        }
    }
}
