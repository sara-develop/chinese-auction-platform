using WebAPI_project.Models;
using WebAPI_project.DTOs;

namespace WebAPI_project.Services
{
    public interface ITicketService
    {
        Task<List<TicketGetDto>> GetAllAsync();
        Task<TicketGetDto> GetByIdAsync(int id);
        Task<int> CreateAsync(TicketCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
