using WebAPI_project.DTOs;

public interface IUserService
{
    Task<List<UserGetDto>> GetAllAsync();
    Task<UserGetDto> GetByIdAsync(int id);
    Task<int> CreateAsync(UserCreateDto dto);
    Task<bool> UpdateAsync(int id, UserUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
