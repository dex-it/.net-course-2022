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
    public class ClientExceptionTests
    {
        [Fact]
        public void AddClientOrThrow() 
        { 
            var clientService = new ClientService();
            var ivan = new Client
            {
                Name = "Ivan",
                BirtDate = new DateTime (2006,01,01) 
            };
            var kolya = new Client
            {
                Name = "Kolya",
                BirtDate = new DateTime(2001, 01, 01),
                PasportNum = 324763
            };
            try
            {
                clientService.AddClient(ivan);
                clientService.AddClient(kolya);
            }
            catch (ClientNoPasportData e)
            {
                Assert.Equal("У клиента нет паспортных данных", e.Message);
                Assert.Equal(typeof(ClientNoPasportData), e.GetType());
            }
            catch (ClientUnder18Exception e)
            {
                Assert.Equal("Клиенту меньше 18", e.Message);
                Assert.Equal(typeof(ClientNoPasportData), e.GetType());
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
        }
    }
}
