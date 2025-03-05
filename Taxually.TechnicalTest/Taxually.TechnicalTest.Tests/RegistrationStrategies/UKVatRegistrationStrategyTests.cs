using Moq;
using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.DTOs;
using Taxually.TechnicalTest.RegistrationStrategies;

namespace Taxually.TechnicalTest.Tests.RegistrationStrategies
{
    public class UKVatRegistrationStrategyTests
	{
        [Fact]
        public async Task RegisterAsync_CallsHttpClientPost()
        {
            // Arrange
            var mockHttpClient = new Mock<ITaxuallyHttpClient>();
            var strategy = new UKVatRegistrationStrategy(mockHttpClient.Object);
            var request = new VatRegistrationRequest { CompanyName = "TestCo", CompanyId = "123", Country = "GB" };

            // Act
            await strategy.RegisterAsync(request);

            // Assert
            mockHttpClient.Verify(c => c.PostAsync<IVatRegistrationRequest>(It.IsAny<string>(), It.IsAny<VatRegistrationRequest>()), Times.Once);
        }
    }
}

