namespace Taxually.TechnicalTest.DTOs
{
    public interface IVatRegistrationRequest
	{
        string CompanyName { get; set; }
        string CompanyId { get; set; }
        string Country { get; set; }
    }
}

