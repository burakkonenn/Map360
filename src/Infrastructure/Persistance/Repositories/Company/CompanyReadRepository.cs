
using Application.Abstractions.Repositories;
using Application.Abstractions.Repositories.Company;
using Application.DTOs.Company;
using Application.DTOs.User;
using Application.DTOs.UserTask;
using Domain.Entities.Company;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class CompanyReadRepository :EfReadRepository<CompanyDoc> ,ICompanyReadRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyReadRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public async Task<CompanyDetails> GetCompanyUsers(int id)
        {
            var companUser = await _context.Companies
                                .Where(a => a.Id == id && a.IsDeleted == false)
                                .Include(a => a.Task)
                                .ThenInclude(a => a.User)
                                .Select(a => new CompanyDetails()
                                {
                                    CompanyId = a.Id,
                                    CompanyName = a.Company.Name,
                                    CompanyAddress = a.Company.Address,
                                    CompanyPhone = a.Company.Phone,
                                    CompanyTaxNumber = a.Company.TaxNo,

                                    UserDetails = a.User.Select(a => new TaskWithUserDetails()
                                    {
                                        Id = a.Id,
                                        Firstname = a.User.FirstName,
                                        LastName = a.User.LastName,
                                        Email = a.User.Email,
                                        TaskName = a.TaskDoc.Name,
                                        CompanyName = a.CompanyDoc.Company.Name,
                                        CreatedDate = (DateTime)a.CreatedDate
                                    }).ToList(),

                                    UserTask = a.Task.Where(a => a.IsDeleted == false).Select(a => new UserDetailDto()
                                    {
                                        Id = a.Id,
                                        CreatedDate = (DateTime)a.CreatedDate,
                                        TaskName = a.Name
                                    }).ToList(),

                                }).AsNoTracking().FirstOrDefaultAsync();
            return companUser;
        }
    }
}
