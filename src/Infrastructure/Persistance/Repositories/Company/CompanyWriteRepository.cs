
using Application.Abstractions.Repositories.Company;
using Application.DTOs.Company;
using Domain.Entities.Company;

using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Persistance.Repositories
{
    public class CompanyWriteRepository : EfWriteRepository<CompanyDoc>, ICompanyWriteRepository
    {
        ApplicationDbContext _context;
        public CompanyWriteRepository(ApplicationDbContext appContext) : base(appContext)
        {
            _context= appContext;
        }
    }
}
