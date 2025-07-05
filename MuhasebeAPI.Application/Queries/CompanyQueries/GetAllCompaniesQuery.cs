using MediatR;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Queries.CompanyQueries
{
    public class GetAllCompaniesQuery : IRequest<List<Company>>
    {
    }
} 