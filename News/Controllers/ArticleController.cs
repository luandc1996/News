using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News.Data;

namespace News.Controllers
{
    [Route("api/article")]
    [ApiController]
    public class ArticleController: ControllerBase
    {
        private readonly AppDbContext _context;
        
        public ArticleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var articles = _context.Articles.ToList();

            return Ok(articles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var article = _context.Articles.Find(id);
            if (article != null) {
                return Ok(article);
            }
            return NotFound();
        }
    }
}