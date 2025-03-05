using Moq;
using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.DTOs;
using Taxually.TechnicalTest.RegistrationStrategies;

namespace Taxually.TechnicalTest.Tests.RegistrationStrategies
{
    public class FRVatRegistrationStrategyTests
	{
        [Fact]
        public async Task RegisterAsync_CallsQueueClientEnqueue()
        {
            // Arrange
            var mockQueueClient = new Mock<ITaxuallyQueueClient>();
            var strategy = new FRVatRegistrationStrategy(mockQueueClient.Object);
            var request = new VatRegistrationRequest { CompanyName = "TestCo", CompanyId = "123", Country = "FR" };

            // Act
            await strategy.RegisterAsync(request);

            // Assert
            mockQueueClient.Verify(c => c.EnqueueAsync(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Once);
        }
    }
}

