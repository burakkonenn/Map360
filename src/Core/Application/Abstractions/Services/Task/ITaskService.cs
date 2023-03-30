using Application.DTOs.CompanyTasks;
using Application.DTOs.UserTask;
using Application.Wrappers;
using Domain.Entities;
using Domain.Entities.Task;

namespace Application.Abstractions.Services.CompanyTasks
{
    public interface ITaskService
    {
        Task<ServiceResponse> CreateAsync(TaskCreateDto  taskCreateDto);
        Task<ServiceResponse> UpdateAsync(string name, int id);
        Task<ServiceResponse> Remove(int id);
        Task<ServiceResponse<IQueryable<TaskDoc>>> GetAll();
        Task<ServiceResponse<TaskDoc>> GetByIdAsync(int id);
        Task<ServiceResponse<UserTaskDetailsWithUsers>> UserTasksDetailsUsers(int id);
    }
}
