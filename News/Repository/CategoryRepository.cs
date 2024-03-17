using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Dtos.Category;
using News.Interfaces;
using News.Models;
using Slugify;

namespace News.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category?> CreateAsync(Category categoryModel)
        {
            SlugHelper slugHelper = new SlugHelper();
            categoryModel.Slug = slugHelper.GenerateSlug(categoryModel.Name);
            await _context.Categories.AddAsync(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var categoryModel = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryModel == null) {
                return null;
            }
            _context.Categories.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Include(c => c.Articles)
                .ThenInclude(a => a.Author)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Include(a => a.Articles)
                .ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto)
        {
            var categoryModel = await _context.Categories.FirstOrDefaultAsync(a => a.Id == id);
            if (categoryModel == null) {
                return null;
            }
            SlugHelper slugHelper = new SlugHelper();
            categoryModel.Name = categoryDto.Name;
            categoryModel.Slug = slugHelper.GenerateSlug(categoryDto.Name);
            await _context.SaveChangesAsync();
            
            return categoryModel;
        }
    }
}