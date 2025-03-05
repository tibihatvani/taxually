using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.DTOs;

namespace Taxually.TechnicalTest.RegistrationStrategies
{
    public class UKVatRegistrationStrategy : IVatRegistrationStrategy
    {
        private readonly ITaxuallyHttpClient _httpClient;

        public UKVatRegistrationStrategy(ITaxuallyHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task RegisterAsync(IVatRegistrationRequest request)
        {
            await _httpClient.PostAsync("https://api.uktax.gov.uk", request);
        }
    }
}

