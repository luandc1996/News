using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Models;

namespace News.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly AppDbContext _context;
        
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(a => a.Articles)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.Users.Find(id);
            if (user != null) {
                return Ok(user);
            }
            return NotFound();
        }
    }
}