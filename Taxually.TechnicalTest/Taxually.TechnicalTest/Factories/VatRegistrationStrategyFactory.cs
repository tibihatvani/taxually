using Taxually.TechnicalTest.RegistrationStrategies;

namespace Taxually.TechnicalTest.Factories
{
    public class VatRegistrationStrategyFactory : IVatRegistrationStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<string, Type> _strategyMappings;

        public VatRegistrationStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _strategyMappings = new Dictionary<string, Type>
            {
                { "GB", typeof(UKVatRegistrationStrategy) },
                { "FR", typeof(FRVatRegistrationStrategy) },
                { "DE", typeof(DEVatRegistrationStrategy) }
            };
        }

        public IVatRegistrationStrategy GetStrategy(string country)
        {
            if (_strategyMappings.TryGetValue(country, out var strategyType))
            {
                var services = _serviceProvider.GetServices<IVatRegistrationStrategy>();
                return services.First(o => o.GetType() == strategyType);
            }

            throw new NotSupportedException("Country not supported");
        }
    }
}

