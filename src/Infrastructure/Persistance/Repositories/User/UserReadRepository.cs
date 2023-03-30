using Application.Abstractions.Repositories.User;
using Application.DTOs.User;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.User
{
    public class UserReadRepository : EfReadRepository<UserDoc>, IUserReadRepository
    {
        private readonly ApplicationDbContext _context;
        public UserReadRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserDoc> GetUserDetails(int id)
        {
            var userDetail = await _context.Users.Where(a => a.Id == id).Include(a => a.CompanyDoc).Include(a => a.TaskDoc).FirstOrDefaultAsync();
            return userDetail;
        }
    }
}
