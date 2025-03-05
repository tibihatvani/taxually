using Microsoft.Extensions.DependencyInjection;
using Taxually.TechnicalTest.Factories;

namespace Taxually.TechnicalTest.Tests.Factories
{
    public class VatRegistrationStrategyFactoryTests
	{
        [Fact]
        public void GetStrategy_ThrowsExceptionForUnsupportedCountry()
        {
            // Arrange
            var serviceProvider = new ServiceCollection().BuildServiceProvider();
            var factory = new VatRegistrationStrategyFactory(serviceProvider);

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => factory.GetStrategy("IT"));
        }
    }
}

