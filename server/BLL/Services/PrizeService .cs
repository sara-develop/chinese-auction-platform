using WebAPI_project.Models;
using WebAPI_project.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebAPI_project.DAL;

namespace WebAPI_project.Services
{
    public class PrizeService : IPrizeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PrizeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PrizeGetDto>> GetAllAsync()
        {
            var prizes = await _context.Prizes
                .Include(p => p.Tickets)
                    .ThenInclude(t => t.User)
                .ToListAsync();

            return _mapper.Map<List<PrizeGetDto>>(prizes);
        }

        public async Task<PrizeGetDto> GetByIdAsync(int id)
        {
            var prize = await _context.Prizes
                .Include(p => p.Tickets)
                    .ThenInclude(t => t.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            return prize == null ? null : _mapper.Map<PrizeGetDto>(prize);
        }

        public async Task<PrizeGetPurchasersDto> GetWithPurchasesAsync(int id)
        {
            var prize = await _context.Prizes
                .Include(p => p.Tickets)
                    .ThenInclude(t => t.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            return prize == null ? null : _mapper.Map<PrizeGetPurchasersDto>(prize);
        }

        public async Task<int> CreateAsync(PrizeCreateDto dto)
        {
            var prize = _mapper.Map<Prize>(dto);
            _context.Prizes.Add(prize);
            await _context.SaveChangesAsync();
            return prize.Id;
        }

        public async Task<bool> UpdateAsync(PrizeUpdateDto dto)
        {
            var prize = await _context.Prizes.FindAsync(dto.Id);
            if (prize == null) return false;

            _mapper.Map(dto, prize);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var prize = await _context.Prizes.FindAsync(id);
            if (prize == null) return false;

            _context.Prizes.Remove(prize);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}