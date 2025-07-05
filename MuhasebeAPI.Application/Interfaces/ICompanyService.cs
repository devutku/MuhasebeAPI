using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> CreateCompanyAsync(CompanyRegisterDto dto,int ownerId);
        Task<Company?> GetCompanyByIdAsync(int id);
        Task<List<Company>> GetCompaniesByOwnerIdAsync(int ownerId);
        Task<List<Company>> GetAllCompaniesAsync();
        Task<bool> DeleteCompanyAsync(int id);
        Task<Company> UpdateCompanyAsync(int id, CompanyRegisterDto dto);
    }
}
