using Application.Abstractions.Repositories;
using Domain.Entities.Task;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class TaskWriteRepository : EfWriteRepository<TaskDoc>, ITaskWriteRepository
    {
        public TaskWriteRepository(ApplicationDbContext appContext) : base(appContext)
        {
        }
    }
}
