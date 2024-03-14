using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Dtos.User;
using News.Interfaces;
using News.Models;

namespace News.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateAsync(User articleModel)
        {
            await _context.Users.AddAsync(articleModel);
            await _context.SaveChangesAsync();
            return articleModel;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var articleModel = await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
            if (articleModel == null) {
                return null;
            }
            _context.Users.Remove(articleModel);
            await _context.SaveChangesAsync();
            return articleModel;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserRequestDto articleDto)
        {
            var articleModel = await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
            if (articleModel == null) {
                return null;
            }
            articleModel.Name = articleDto.Name;
            articleModel.Username = articleDto.Username;
            articleModel.Password = articleDto.Password;
            articleModel.Status = articleDto.Status;
            await _context.SaveChangesAsync();
            
            return articleModel;
        }
    }
}