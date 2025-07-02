using WebAPI_project.Models;
using WebAPI_project.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebAPI_project.DAL;

namespace WebAPI_project.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TicketService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TicketGetDto>> GetAllAsync()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Prize)
                .Include(t => t.User)
                .ToListAsync();

            return _mapper.Map<List<TicketGetDto>>(tickets);
        }

        public async Task<TicketGetDto> GetByIdAsync(int id)
        {
            var ticket = await _context.Tickets
                .Include(t => t.Prize)
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);

            return ticket == null ? null : _mapper.Map<TicketGetDto>(ticket);
        }

        public async Task<int> CreateAsync(TicketCreateDto dto)
        {
            var ticket = _mapper.Map<Ticket>(dto);
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return false;

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
