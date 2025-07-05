using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> CreateCompanyAsync(CompanyRegisterDto dto,Guid ownerId);
        Task<Company?> GetCompanyByIdAsync(Guid id);
        Task<List<Company>> GetCompaniesByOwnerIdAsync(Guid ownerId);
        Task<List<Company>> GetAllCompaniesAsync();
        Task<bool> DeleteCompanyAsync(Guid id);
        Task<Company> UpdateCompanyAsync(Guid id, CompanyRegisterDto dto);
    }
}
