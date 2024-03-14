using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Dtos.Category;
using News.Models;

namespace News.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> CreateAsync(Category categoryModel);
        Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto);
        Task<Category?> DeleteAsync(int id);
    }
}