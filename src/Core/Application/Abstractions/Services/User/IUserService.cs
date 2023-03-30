using Application.DTOs;
using Application.DTOs.Company;
using Application.DTOs.User;
using Application.Wrappers;


namespace Application.Abstractions.Services.User
{
    public interface IUserService
    {
        Task<ServiceResponse<List<DropdownDto>>> Companies();
        Task<ServiceResponse<List<DropdownDto>>> Tasks();
        Task<ServiceResponse<List<UserListDto>>> GetAll();
        Task<ServiceResponse> CreateAsync(UserCreateDto model);
        Task<ServiceResponse> UpdateAsync(UserUpdateDto model);
        Task<ServiceResponse> Remove(int id);
        Task<ServiceResponse<UserUpdateDto>> GetByIdAsync(int id);
        Task<ServiceResponse<UserDetailDto>> GetByIdUserDetailsAsync(int id);
    }
}
