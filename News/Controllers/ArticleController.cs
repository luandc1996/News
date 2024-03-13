using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Dtos.Article;
using News.Mappers;

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
        public async Task<IActionResult> GetAll()
        {
            var articles = await _context.Articles.ToListAsync();

            var modelArticles = articles.Select(s => s.ToArticleDto());

            return Ok(modelArticles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var article = _context.Articles.Find(id);
            if (article != null) {
                return Ok(article.ToArticleDto());
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateArticleRequestDto articleDto)
        {
            var articleModel = articleDto.ToArticleFromCreateDTO();
            _context.Articles.Add(articleModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = articleModel.Id}, articleModel.ToArticleDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateArticleRequestDto articleDto)
        {
            var articleModel = _context.Articles.FirstOrDefault(a => a.Id == id);
            if (articleModel == null) {
                return NotFound();
            }

            articleModel.Title = articleDto.Title;
            articleModel.Slug = articleDto.Slug;
            articleModel.Content = articleDto.Content;
            articleModel.Status = articleDto.Status;
            articleModel.CategoryId = articleDto.CategoryId;
            _context.SaveChanges();
            return Ok(articleModel.ToArticleDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var articleModel = _context.Articles.FirstOrDefault(a => a.Id == id);
            if (articleModel == null) {
                return NotFound();
            }
            _context.Articles.Remove(articleModel);
            _context.SaveChanges();

            return NoContent();
        }
    }
}