using Application.DTOs.Company;
using Application.DTOs.User;
using Domain.Entities.Company;

namespace Application.Abstractions.Repositories.Company
{
    public interface ICompanyReadRepository:IEfReadRepository<CompanyDoc>
    {
        Task<CompanyDetails> GetCompanyUsers(int id);
    }
}
