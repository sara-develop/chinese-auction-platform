using WebAPI_project.Models;
using WebAPI_project.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebAPI_project.DAL;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CategoryService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CategoryGetDto>> GetAllAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return _mapper.Map<List<CategoryGetDto>>(categories);
    }

    public async Task<CategoryWithPrizesDto> GetByIdWithPrizesAsync(int id)
    {
        var category = await _context.Categories
            .Include(c => c.Prizes)
                .ThenInclude(p => p.Tickets)
                    .ThenInclude(t => t.User)
            .FirstOrDefaultAsync(c => c.Id == id);

        return category == null ? null : _mapper.Map<CategoryWithPrizesDto>(category);
    }

    public async Task<int> CreateAsync(CategoryCreateDto dto)
    {
        var category = _mapper.Map<Category>(dto);
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category.Id;
    }

    public async Task<bool> UpdateAsync(int id, CategoryUpdateDto dto)
    {
        var category = await _context.Categories
            .Include(c => c.Prizes)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null) return false;

        category.Name = dto.Name;

        if (dto.PrizesId != null)
        {
            category.Prizes = await _context.Prizes
                .Where(p => dto.PrizesId.Contains(p.Id))
                .ToListAsync();
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return false;

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}
