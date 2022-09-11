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
            var clientService = new ClientService();

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
            var clientService = new ClientService();

            // Assert
            // Act
            Assert.Throws<PassportDataEmptyException>(() => clientService.AddClient(client));
        }
    }
}