using System.Xml.Serialization;
using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.DTOs;

namespace Taxually.TechnicalTest.RegistrationStrategies
{
    public class DEVatRegistrationStrategy : IVatRegistrationStrategy
    {
        private readonly ITaxuallyQueueClient _queueClient;

        public DEVatRegistrationStrategy(ITaxuallyQueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        public async Task RegisterAsync(IVatRegistrationRequest request)
        {
            using (var stringWriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
                serializer.Serialize(stringWriter, request);
                var xml = stringWriter.ToString();
                await _queueClient.EnqueueAsync("vat-registration-xml", xml);
            }
        }
    }
}

