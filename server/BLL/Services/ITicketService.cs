using WebAPI_project.DTOs;

public interface ITicketService
{
    Task<List<TicketGetDto>> GetAllAsync();
    Task<TicketGetDto> GetByIdAsync(int id);
    Task<int> CreateAsync(TicketCreateDto dto);
    Task<bool> DeleteAsync(int id);
}
