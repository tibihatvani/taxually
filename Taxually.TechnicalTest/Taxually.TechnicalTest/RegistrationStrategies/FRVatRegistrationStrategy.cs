using System.Text;
using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.DTOs;

namespace Taxually.TechnicalTest.RegistrationStrategies
{
    public class FRVatRegistrationStrategy : IVatRegistrationStrategy
    {
        private readonly ITaxuallyQueueClient _queueClient;

        public FRVatRegistrationStrategy(ITaxuallyQueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        public async Task RegisterAsync(IVatRegistrationRequest request)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{request.CompanyName},{request.CompanyId}");
            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            await _queueClient.EnqueueAsync("vat-registration-csv", csv);
        }
    }
}

