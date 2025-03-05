namespace Taxually.TechnicalTest.DTOs
{
    public class VatRegistrationRequest : IVatRegistrationRequest
    {
        public string CompanyName { get; set; }
        public string CompanyId { get; set; }
        public string Country { get; set; }
    }
}

