using Services;
using Models;
using Services.Filters;
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
        public void GetClientsFilterTest()
        {
            // Arrange
            var clientFilter = new ClientFilter();
            var clientStorage = new ClientStorage();
            var testDataGenerator = new TestDataGenerator();
            

            for (int i = 0; i < 5; i++)
            {
                clientStorage.AddClient(testDataGenerator.GetFakeDataClient().Generate());
            }
            var clientService = new ClientService(clientStorage);
            var client = clientStorage._dictionaryClient.Keys.First();

           //Act
            var youngClient = clientStorage._dictionaryClient.Min(p => p.Key.BirtDate);
            var oldClient = clientStorage._dictionaryClient.Max(p => p.Key.BirtDate);
            var averageAge = clientStorage._dictionaryClient.Average(p => DateTime.Now.Year - p.Key.BirtDate.Year);

            //Assert
            if (clientStorage._dictionaryClient.Count != 5)
            {
                Assert.True(false);
            }

        }
        //[Fact]
        //public void AddClientLimit18YearsExceptionTest()
        //{
        //    var clientService = new ClientService();
        //    var ivan = new Client
        //    {
        //        Name = "Ivan",
        //        BirtDate = new DateTime(2006, 01, 01),
        //        PasportNum = 324763
        //    };
        //    try
        //    {
        //        clientService.AddClient(ivan);
        //    }
        //    catch (Under18Exception e)
        //    {
        //        Assert.Equal("Клиенту меньше 18", e.Message);
        //        Assert.Equal(typeof(Under18Exception), e.GetType());
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.True(false);
        //    }
        //}
        //[Fact]
        //public void AddClientNoPasportDataExceptionTest()
        //{
        //    var clientService = new ClientService();
        //    var ivan = new Client
        //    {
        //        Name = "Ivan",
        //        BirtDate = new DateTime(2006, 01, 01),
        //        PasportNum = 324763
        //    };
        //    try
        //    {
        //        clientService.AddClient(ivan);
        //    }
        //    catch (NoPasportData e)
        //    {
        //        Assert.Equal("У клиента нет паспортных данных", e.Message);
        //        Assert.Equal(typeof(NoPasportData), e.GetType());
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.True(false);
        //    }
        //}
        //[Fact]
        //public void AddClientExistsException()
        //{
        //    var clientService = new ClientService();
        //    var ivan = new Client
        //    {
        //        Name = "Ivan",
        //        BirtDate = new DateTime(2006, 01, 01),
        //        PasportNum = 324763
        //    };
        //    var ivanI = new Client
        //    {
        //        Name = "Ivan",
        //        BirtDate = new DateTime(2006, 01, 01),
        //        PasportNum = 324763
        //    };
        //    try
        //    {
        //        clientService.AddClient(ivan);
        //        clientService.AddClient(ivanI);

        //    }
        //    catch (ExistsException e)
        //    {
        //        Assert.Equal("Такой клиент существует", e.Message);
        //        Assert.Equal(typeof(ExistsException), e.GetType());
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.True(false);
        //    }
        //}
        //[Fact]
        //public void AddAccountNoExistsClientAndAccountExistsExceptionTest()
        //{
        //    var clientService = new ClientService();
        //    var ivan = new Client
        //    {
        //        Name = "Ivan",
        //        BirtDate = new DateTime(2006, 01, 01),
        //        PasportNum = 324763
        //    };
        //    var ivanEx = new Client
        //    {
        //        Name = "Ivan",
        //        BirtDate = new DateTime(2006, 01, 01),
        //        PasportNum = 324763
        //    };

        //    try
        //    {
        //        clientService.AddClient(ivan);
        //        clientService.AddAccount(ivan);
        //        Assert.Throws<ExistsException>(() => clientService.AddAccount(ivanEx));
        //        Assert.Throws<ExistsException>(() => clientService.AddAccount(ivan));
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.True(false);
        //    }
        //}
    }
}
