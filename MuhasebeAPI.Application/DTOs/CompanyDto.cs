namespace MuhasebeAPI.Application.DTOs
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? TaxNumber { get; set; }
        public List<AccountDto> Accounts { get; set; } = new List<AccountDto>();
    }
}
