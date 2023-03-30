using Application.Abstractions.Repositories;
using Application.Abstractions.Services.CompanyTasks;
using Application.DTOs.CompanyTasks;
using Application.DTOs.UserTask;
using Application.Wrappers;
using Domain.Entities;
using Domain.Entities.Task;
using Microsoft.EntityFrameworkCore;


namespace Persistance.Services
{
    public class TaskService : ITaskService
    {

        private readonly ITaskReadRepository _taskReadRepository;
        private readonly ITaskWriteRepository _taskWriteRepository;
        public TaskService(ITaskReadRepository taskReadRepository, ITaskWriteRepository taskWriteRepository)
        {
            _taskReadRepository = taskReadRepository;
            _taskWriteRepository =taskWriteRepository;
        }

        public async Task<ServiceResponse> CreateAsync(TaskCreateDto taskCreateDto)
        {
            var response = new ServiceResponse<TaskDoc>();
            var taskDoc = new TaskDoc();
            taskDoc.Name = taskCreateDto.Name;
            taskDoc.CreatedDate =DateTime.UtcNow;
            await _taskWriteRepository.AddAsync(taskDoc);
            response.IsSuccess = true;
            response.Message = "Bilgiler başarılı bir şekilde eklendi";
            response.Data = taskDoc;
            return response;
        }

        public async Task<ServiceResponse<IQueryable<TaskDoc>>> GetAll()
        {
            var response = new ServiceResponse<IQueryable<TaskDoc>>();
            response.Data =  _taskReadRepository.GetAll().Where(a => a.IsDeleted == false);
            return response;
        }

        public async Task<ServiceResponse<TaskDoc>> GetByIdAsync(int id)
        {
            var response = new ServiceResponse<TaskDoc>();
            var task = await _taskReadRepository.GetByIdAsync(id);
            if (task == null)
            {
                response.Message = "Kayıt Bulunamadı";
                response.IsSuccess = false;
                return response;
            }
            response.Data = task;
            return response;

        }

        public async Task<ServiceResponse> Remove(int id)
        {
            ServiceResponse response = new ServiceResponse();
            var userTask = await _taskReadRepository.GetByIdAsync(id);
            if (userTask == null)
            {
                response.IsSuccess = false;
                response.Message = "Silinecek kayıt bulunamadı";
                return response;
            }

            await _taskWriteRepository.RemoveAsync(userTask);
            response.IsSuccess = true;
            return response;
        }

        public async Task<List<TaskDoc>> SelectAllTaskList()
        {
            var tasks = await _taskReadRepository.GetAll().Select(a => new TaskDoc()
            {
                Id = a.Id,
                Name = a.Name,
            }).ToListAsync();

            return tasks;
        }

        public async Task<ServiceResponse> UpdateAsync(string name, int id)
        {
            var response = new ServiceResponse<TaskDoc>();
            var task = await _taskReadRepository.GetByIdAsync(id);
            if (task == null)
            {
                response.IsSuccess = false;
                response.Message = "güncellenecek kayıt bulunamadı";
                return response;
            }
            task.Name = name;
            await _taskWriteRepository.UpdateAsync(task);
            response.Message = "Güncelleme başarılı";
            response.IsSuccess = true;
            response.Data = task;
            return response;
        }

        public async Task<ServiceResponse<UserTaskDetailsWithUsers>> UserTasksDetailsUsers(int id)
        {
            var response = new ServiceResponse<UserTaskDetailsWithUsers>();

            var userTaskWithUsers = await _taskReadRepository.UserTaskDetails(id);

            if (userTaskWithUsers == null)
            {
                response.IsSuccess = false;
                response.Message = "güncellenecek kayıt bulunamadı";

                return response;
            }

            response.Data = userTaskWithUsers;
            return response;
        }
    }
}
