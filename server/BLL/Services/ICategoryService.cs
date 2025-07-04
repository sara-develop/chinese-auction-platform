﻿using WebAPI_project.DTOs;


namespace WebAPI_project.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryGetDto>> GetAllAsync();
        Task<CategoryWithPrizesDto> GetByIdWithPrizesAsync(int id);
        Task<int> CreateAsync(CategoryCreateDto dto);
        Task<bool> UpdateAsync(int id, CategoryUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
