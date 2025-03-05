using Taxually.TechnicalTest.DTOs;

namespace Taxually.TechnicalTest.RegistrationStrategies
{
    public interface IVatRegistrationStrategy
    {
        Task RegisterAsync(IVatRegistrationRequest request);
    }
}

