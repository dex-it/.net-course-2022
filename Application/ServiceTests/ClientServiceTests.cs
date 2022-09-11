using Models;
using Services;
using Services.Exceptions;
using Xunit;

namespace ServiceTests
{
    public class ClientsServicesTests
    {
        [Fact]
        public void GetClientAgeLimitExceptionPositiveTest()
        {
            // Arrange
            var client = new Client
            {
                FirstName = "Иван",
                LastName = "Иванов",
                BirthdayDate = new DateTime(2008, 01, 01)
            };
            var clientStorage = new ClientStorage();
            var clientService = new ClientService(clientStorage);

            // Assert
            // Act
            Assert.Throws<AgeLimitException>(() => clientService.AddClient(client));
        }
        
        [Fact]
        public void GetClientPassportDataEmptyExceptionPositiveTest()
        {
            // Arrange
            var client = new Client()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                BirthdayDate = new DateTime(2001, 01, 01)
            };
            var clientStorage = new ClientStorage();
            var clientService = new ClientService(clientStorage);

            // Assert
            // Act
            Assert.Throws<PassportDataEmptyException>(() => clientService.AddClient(client));
        }

        [Fact]
        public void GetClientsFromFilterPositiveTest()
        {
            // Arrange
            var clientStorage = new ClientStorage();
            var clientService = new ClientService(clientStorage);
            var dataGenerators = new TestDataGenerator();
            var clientList = dataGenerators.GetClientList(1000);
            var clientFilter = new ClientFilter
            {
                DateStart = DateTime.Now.AddYears(-60)
            };

            // Act
            foreach (var client in clientList)
            {
                try { clientService.AddClient(client); }
                catch { }
            }
            
            var maxYoungClientDate = clientService.GetClients(clientFilter)
                .Max(c => c.BirthdayDate);
            var maxYoungClient = clientService.GetClients(clientFilter)
                .FirstOrDefault(c => c.BirthdayDate.Equals(maxYoungClientDate));
            
            var maxOldClientDate = clientService.GetClients(clientFilter)
                .Min(c => c.BirthdayDate);
            var maxOldClient = clientService.GetClients(clientFilter)
                .FirstOrDefault(c => c.BirthdayDate.Equals(maxOldClientDate));

            var averageAgeClients = clientService.GetClients(clientFilter)
                    .Average(c => (DateTime.Now.Year - c.BirthdayDate.Year));
            
            // Assert
            if (averageAgeClients > 18) Assert.True(true);
            else Assert.True(false);
        }
    }
}