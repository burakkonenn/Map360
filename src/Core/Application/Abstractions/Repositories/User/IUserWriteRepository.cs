using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories.User
{
    public interface IUserWriteRepository:IEfWriteRepository<UserDoc>
    {
    }
}
