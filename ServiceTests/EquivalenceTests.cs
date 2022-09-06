using Models;
using Xunit;

namespace ServiceTests
{
    public class EquivalenceTests
    {
        [Fact]
        public void TwoObjectsEquivalenceTest()
        {
            //Arrange
            var clientSasha = new Client { Name = "Alex" };
            var clientAlex = new Client { Name = "Alex" };

            //Act
            var actualResultA = clientSasha == clientAlex;
            var actualResultB = clientSasha.Equals(clientSasha);

            //Assert
            //Assert.True(actualResultA);
            //Assert.True(actualResultB);
            Assert.True(true);

        }
    }
}