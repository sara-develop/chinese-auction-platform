using WebAPI_project.DTOs;

namespace WebAPI_project.Services
{
    public interface IDonorService
    {
        Task<List<DonorGetDto>> GetAllAsync();
        Task<DonorGetDto> GetByIdAsync(int id);
        Task<int> CreateAsync(DonorCreateDto dto);
        Task<bool> UpdateAsync(int id, DonorUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
