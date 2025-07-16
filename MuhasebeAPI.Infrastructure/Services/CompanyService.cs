using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;

namespace MuhasebeAPI.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IAccountRepository _accountRepository;

        public CompanyService(ICompanyRepository companyRepository,IAccountRepository accountRepository)
        {
            _companyRepository = companyRepository;
            _accountRepository = accountRepository;
        }

        public async Task<Company> CreateCompanyAsync(CompanyRegisterDto dto, Guid userId)
        {
            var company = new Company
            {
                Name = dto.Name,
                TaxNumber = dto.TaxNumber,
                TaxOffice = dto.TaxOffice,
                Address = dto.Address,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            await _companyRepository.AddAsync(company);
            await _companyRepository.SaveChangesAsync(); 

            // Fetch AccountCategory IDs from the database after seeding, then use them here.
            // Example:
            // var nakitCategory = await _context.AccountCategories.FirstAsync(x => x.Name == "Nakit (Kasa)");
            // var defaultAccounts = new List<Account>
            // {
            //     new() { Name = "Nakit (Kasa)", AccountCategoryId = nakitCategory.Id, CompanyId = company.Id },
            //     ...
            // };
            var defaultAccounts = new List<Account>
            {
                new() {
                    Name = "Alıcılar",
                    CompanyId = company.Id,
                    AccountCategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222") // Alıcılar kategorisi
                }
            };
            await _accountRepository.AddRangeAsync(defaultAccounts);
            await _accountRepository.SaveChangesAsync();
            var companyWithAccounts = await _companyRepository.GetByIdAsync(company.Id);
            return companyWithAccounts!;
        }





        public async Task<Company?> GetCompanyByIdAsync(Guid id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }

        public async Task<List<Company>> GetCompaniesByUserIdAsync(Guid userId)
        {
            var companies = await _companyRepository.GetCompaniesByUserIdAsync(userId);
            return companies.ToList();
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            var companies = await _companyRepository.GetAllAsync();
            return companies.ToList();
        }

        public async Task<bool> DeleteCompanyAsync(Guid id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null) return false;

            _companyRepository.Delete(company);
            await _companyRepository.SaveChangesAsync();
            return true;
        }

        public async Task<Company> UpdateCompanyAsync(Guid id, CompanyRegisterDto dto)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
                throw new Exception("Company not found");

            company.Name = dto.Name;
            company.TaxNumber = dto.TaxNumber;
            company.TaxOffice = dto.TaxOffice;
            company.Address = dto.Address;

            await _companyRepository.SaveChangesAsync();
            return company;
        }
    }
}
