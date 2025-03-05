using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.DTOs;
using Taxually.TechnicalTest.Factories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        private readonly IVatRegistrationStrategyFactory _strategyFactory;

        public VatRegistrationController(IVatRegistrationStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] IVatRegistrationRequest request)
        {
            var strategy = _strategyFactory.GetStrategy(request.Country);
            await strategy.RegisterAsync(request);
            return Ok();
        }
    }
}
