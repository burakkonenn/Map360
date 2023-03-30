using Application.DTOs.Company;
using Application.DTOs.User;
using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services.Company
{
    public interface ICompanyService
    {

        Task<ServiceResponse> CreateAsync(CompanyCreateDto model);
        Task<ServiceResponse> UpdateAsync(CompanyUpdateDto model);
        Task<ServiceResponse> Remove(int id);
        Task<ServiceResponse<List<CompanyListDto>>> GetAll();
        Task<ServiceResponse<CompanyUpdateDto>> GetByIdAsync(int id);
        Task<ServiceResponse<CompanyDetails>> GetCompanyUsers(int id);
    }
}
