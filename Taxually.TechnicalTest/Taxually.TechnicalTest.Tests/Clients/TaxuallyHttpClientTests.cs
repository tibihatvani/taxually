using Moq;
using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.DTOs;

namespace Taxually.TechnicalTest.Tests.Clients
{
    public class TaxuallyHttpClientTests
	{
        [Fact]
        public async Task PostAsync_SendsHttpRequest()
        {
            // Arrange
            var httpClient = new Mock<ITaxuallyHttpClient>();
            var request = new VatRegistrationRequest { CompanyName = "TestCo", CompanyId = "123", Country = "GB" };

            // Act
            await httpClient.Object.PostAsync("https://api.uktax.gov.uk", request);

            // Assert
            httpClient.Verify(c => c.PostAsync("https://api.uktax.gov.uk", request), Times.Once);
        }
    }
}

