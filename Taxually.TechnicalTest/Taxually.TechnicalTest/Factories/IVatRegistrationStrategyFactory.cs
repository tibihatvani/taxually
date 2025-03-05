using Taxually.TechnicalTest.RegistrationStrategies;

namespace Taxually.TechnicalTest.Factories
{
    public interface IVatRegistrationStrategyFactory
	{
        public IVatRegistrationStrategy GetStrategy(string country);
    }
}

