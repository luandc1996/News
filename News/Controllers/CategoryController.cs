using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News.Data;

namespace News.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly AppDbContext _context;
        
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var category = _context.Categories.ToList();

            return Ok(category);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null) {
                return Ok(category);
            }
            return NotFound();
        }
    }
}