using Application.Abstractions.Repositories.User;
using Domain.Entities.User;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.User
{
    public class UserWriteRepository : EfWriteRepository<UserDoc>, IUserWriteRepository
    {
        public UserWriteRepository(ApplicationDbContext appContext) : base(appContext)
        {
        }
    }
}
