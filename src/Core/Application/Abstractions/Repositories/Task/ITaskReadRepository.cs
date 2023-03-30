using Application.DTOs.UserTask;
using Domain.Entities;
using Domain.Entities.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories
{
    public interface ITaskReadRepository: IEfReadRepository<TaskDoc>
    {
        Task<UserTaskDetailsWithUsers> UserTaskDetails(int id);
    }
}
