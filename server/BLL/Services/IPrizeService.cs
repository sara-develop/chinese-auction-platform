using WebAPI_project.Models;
using WebAPI_project.DTOs;


namespace WebAPI_project.Services
{
    public interface IPrizeService
    {
        Task<List<PrizeGetDto>> GetAllAsync();
        Task<PrizeGetDto> GetByIdAsync(int id);
        Task<PrizeGetPurchasersDto> GetWithPurchasesAsync(int id);
        Task<int> CreateAsync(PrizeCreateDto dto);
        Task<bool> UpdateAsync(PrizeUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
