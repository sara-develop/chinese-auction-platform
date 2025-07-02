using WebAPI_project.Models;
using WebAPI_project.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebAPI_project.DAL;

public class DonorService : IDonorService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DonorService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DonorGetDto>> GetAllAsync()
    {
        var donors = await _context.Donors.Include(d => d.Prizes).ToListAsync();
        return _mapper.Map<List<DonorGetDto>>(donors);
    }

    public async Task<DonorGetDto> GetByIdAsync(int id)
    {
        var donor = await _context.Donors.Include(d => d.Prizes).FirstOrDefaultAsync(d => d.Id == id);
        return donor == null ? null : _mapper.Map<DonorGetDto>(donor);
    }

    public async Task<int> CreateAsync(DonorCreateDto dto)
    {
        var donor = _mapper.Map<Donor>(dto);
        _context.Donors.Add(donor);
        await _context.SaveChangesAsync();
        return donor.Id;
    }

    public async Task<bool> UpdateAsync(int id, DonorUpdateDto dto)
    {
        var donor = await _context.Donors.Include(d => d.Prizes).FirstOrDefaultAsync(d => d.Id == id);
        if (donor == null) return false;

        donor.Name = dto.Name;
        donor.Email = dto.Email;

        // עדכון פרסים קשורים אם צריך
        if (dto.PrizesId != null)
        {
            donor.Prizes = await _context.Prizes.Where(p => dto.PrizesId.Contains(p.Id)).ToListAsync();
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var donor = await _context.Donors.FindAsync(id);
        if (donor == null) return false;

        _context.Donors.Remove(donor);
        await _context.SaveChangesAsync();
        return true;
    }
}
