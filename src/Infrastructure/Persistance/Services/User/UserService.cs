using Application.Abstractions.Repositories;
using Application.Abstractions.Repositories.Company;
using Application.Abstractions.Repositories.User;
using Application.Abstractions.Services.User;
using Application.DTOs;
using Application.DTOs.Company;
using Application.DTOs.User;
using Application.Wrappers;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Persistance.Repositories;

namespace Persistance.Services
{
    public class UserService : IUserService
    {

        readonly IUserReadRepository _userReadRepository;
        readonly IUserWriteRepository _userWriteRepository;
        readonly ICompanyReadRepository _companyReadRepository;
        readonly ITaskReadRepository _taskReadRepository;
        public UserService(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, ICompanyReadRepository companyReadRepository, ITaskReadRepository taskReadRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _companyReadRepository = companyReadRepository;
            _taskReadRepository = taskReadRepository;
        }
        public async Task<ServiceResponse> CreateAsync(UserCreateDto model)
        {
            var response = new ServiceResponse();
            var user = new UserDoc();
            user.User = new User();
            user.User.FirstName = model.FirstName;
            user.User.LastName = model.LastName;
            user.User.Email = model.Email;
            user.CompanyId = model.CompanyId;
            user.TaskId = model.TaskId;
            user.IsDeleted = false;
            user.CreatedDate = DateTime.UtcNow;
            await _userWriteRepository.AddAsync(user);
            response.IsSuccess = true;
            response.Message = "Kullanıcı başarılı bir şekilde eklendi";
            return response;
        }
        public async Task<ServiceResponse<List<UserListDto>>> GetAll()
        {
            var response = new ServiceResponse<List<UserListDto>>();
            var query = _userReadRepository.GetAll().Where(x => x.IsDeleted == false);
            response.Data = await query.Select(x => new UserListDto()
            {
                Email = x.User.Email,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                CompanyName = x.CompanyDoc.Company.Name,
                TaskName = x.TaskDoc.Name,
                CreatedDate = (DateTime)x.CreatedDate,
                Id = x.Id
            }).ToListAsync();
            return response;
        }
        public async Task<ServiceResponse<UserUpdateDto>> GetByIdAsync(int id)
        {
            var response = new ServiceResponse<UserUpdateDto>();
            var user = await _userReadRepository.GetByIdAsync(id);
            if (user == null)
            {
                response.Message = "Kayıtlı kullanıcı bulunmamaktadır.";
                response.IsSuccess = false;
                return response;
            }
            var updateDto = new UserUpdateDto();
            updateDto.Id = user.Id;
            updateDto.FirstName = user.User.FirstName;
            updateDto.LastName = user.User.LastName;
            updateDto.Email = user.User.Email;
            updateDto.CompanyId = user.CompanyId;
            updateDto.TaskId = user.TaskId;
            response.IsSuccess = true;
            response.Data = updateDto;
            return response;
        }
        public async Task<ServiceResponse<UserDetailDto>> GetByIdUserDetailsAsync(int id)
        {
            var response = new ServiceResponse<UserDetailDto>();
            var user = await _userReadRepository.GetUserDetails(id);
            if (user == null)
            {
                response.Message = "Kayıtlı kullanıcı bulunmamaktadır.";
                response.IsSuccess = false;
                return response;
            }

            var detailDto = new UserDetailDto();

            detailDto.Id = user.Id;
            detailDto.FirstName = user.User.FirstName;
            detailDto.LastName = user.User.LastName;
            detailDto.Email = user.User.Email;
            detailDto.CompanyName = user.CompanyDoc.Company.Name;
            detailDto.TaskName = user.TaskDoc.Name;
            response.Data = detailDto;
            return response;
        }
        public async Task<ServiceResponse> Remove(int id)
        {
            ServiceResponse response = new ServiceResponse();
            var user = await _userReadRepository.GetByIdAsync(id);

            if (user == null)
            {
                response.IsSuccess = false;
                response.Message = "Silinecek kayıt bulunamadı";
                return response;
            }

            user.IsDeleted = true;
            await _userWriteRepository.RemoveAsync(user);
            response.IsSuccess = true;
            return response;
        }
        public async Task<ServiceResponse> UpdateAsync(UserUpdateDto model)
        {
            var response = new ServiceResponse();
            var user = await _userReadRepository.GetByIdAsync(model.Id);
            if (user == null)
            {
                response.IsSuccess = false;
                response.Message = "güncellenecek kayıt bulunamadı";
                return response;
            }
            user.User.FirstName = model.FirstName;
            user.User.LastName = model.LastName;
            user.User.Email = model.Email;
            user.CompanyId = model.CompanyId;
            user.TaskId = model.TaskId;
            user.UpdatedDate = DateTime.UtcNow;
            await _userWriteRepository.UpdateAsync(user);
            response.Message = "Güncelleme başarılı";
            response.IsSuccess = true;
            return response;
        }


        public async Task<ServiceResponse<List<DropdownDto>>> Companies()
        {
            ServiceResponse<List<DropdownDto>> serviceResponse = new ServiceResponse<List<DropdownDto>>();
            var data = await _companyReadRepository.GetAll().Where(a => a.IsDeleted == false).Select(x => new DropdownDto()
            {
                Text = x.Company.Name,
                Value = x.Id

            }).ToListAsync();

            serviceResponse.Data = data;
            return serviceResponse;
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<DropdownDto>>> Tasks()
        {
            ServiceResponse<List<DropdownDto>> serviceResponse = new ServiceResponse<List<DropdownDto>>();
            var data = await _taskReadRepository.GetAll().Where(a => a.IsDeleted == false).Select(x => new DropdownDto()
            {
                Text = x.Name,
                Value = x.Id

            }).ToListAsync();

            serviceResponse.Data = data;
            return serviceResponse;
        }
    }
}
