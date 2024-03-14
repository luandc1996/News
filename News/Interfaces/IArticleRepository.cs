using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Dtos.Article;
using News.Models;

namespace News.Interfaces
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAllAsync();
        Task<Article?> GetByIdAsync(int id);
        Task<Article?> CreateAsync(Article articleModel);
        Task<Article?> UpdateAsync(int id, UpdateArticleRequestDto articleDto);
        Task<Article?> DeleteAsync(int id);
    }
}