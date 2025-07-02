using WebAPI_project.Models;
using WebAPI_project.DTOs;

namespace WebAPI_project.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string email, string password);
        Task<List<UserGetDto>> GetAllAsync();
        Task<UserGetDto> GetByIdAsync(int id);
        Task<int> CreateAsync(UserCreateDto dto);
        Task<bool> UpdateAsync(int id, UserUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
