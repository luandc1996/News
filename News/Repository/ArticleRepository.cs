using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Dtos.Article;
using News.Interfaces;
using News.Models;

namespace News.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _context;
        public ArticleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Article?> CreateAsync(Article articleModel)
        {
            await _context.Articles.AddAsync(articleModel);
            await _context.SaveChangesAsync();
            return articleModel;
        }

        public async Task<Article?> DeleteAsync(int id)
        {
            var articleModel = await _context.Articles.FirstOrDefaultAsync(a => a.Id == id);
            if (articleModel == null) {
                return null;
            }
            _context.Articles.Remove(articleModel);
            await _context.SaveChangesAsync();
            return articleModel;
        }

        public async Task<List<Article>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task<Article?> UpdateAsync(int id, UpdateArticleRequestDto articleDto)
        {
            var articleModel = await _context.Articles.FirstOrDefaultAsync(a => a.Id == id);
            if (articleModel == null) {
                return null;
            }
            articleModel.Title = articleDto.Title;
            articleModel.Slug = articleDto.Slug;
            articleModel.Content = articleDto.Content;
            articleModel.Status = articleDto.Status;
            articleModel.CategoryId = articleDto.CategoryId;
            articleModel.UserId = 1;
            await _context.SaveChangesAsync();
            
            return articleModel;
        }
    }
}