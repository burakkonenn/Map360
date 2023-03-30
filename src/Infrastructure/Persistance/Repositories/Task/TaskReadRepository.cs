using Application.Abstractions.Repositories;
using Application.DTOs.CompanyTasks;
using Application.DTOs.UserTask;
using Domain.Entities;
using Domain.Entities.Task;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;


namespace Persistance.Repositories
{
    public class TaskReadRepository : EfReadRepository<TaskDoc>, ITaskReadRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskReadRepository(ApplicationDbContext appContext) : base(appContext)
        {
            _context = appContext;
        }

        public async Task<UserTaskDetailsWithUsers> UserTaskDetails(int id)
        {
            var userTaskDetails = await _context.Tasks.Where(a => a.Id == id).Include(a => a.User).Select(a => new UserTaskDetailsWithUsers()
            {
                TaskName = a.Name,
                Users = a.User.Select(a => new TaskWithUserDetails()
                {
                    Id = a.Id,
                    Firstname = a.User.FirstName,
                    LastName = a.User.LastName,
                    Email = a.User.Email,
                    TaskName = a.TaskDoc.Name,
                    CompanyName = a.CompanyDoc.Company.Name,
                    CreatedDate = (DateTime)a.CreatedDate

                }).ToList()

            }).FirstOrDefaultAsync();

            return userTaskDetails;
        }
    }
}
