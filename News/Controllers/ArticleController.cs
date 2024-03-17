using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Dtos.Article;
using News.Interfaces;
using News.Mappers;

namespace News.Controllers
{
    [Route("api/article")]
    [ApiController]
    public class ArticleController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IArticleRepository _articleRepo;
        
        public ArticleController(AppDbContext context, IArticleRepository articleRepo)
        {
            _context = context;
            _articleRepo = articleRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _articleRepo.GetAllAsync();
            var modelArticles = articles.Select(s => s.ToArticleDto());
            return Ok(modelArticles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var article = await _articleRepo.GetByIdAsync(id);
            if (article != null) {
                return Ok(article.ToArticleDto());
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateArticleRequestDto articleDto)
        {
            var articleModel = articleDto.ToArticleFromCreateDTO();
            articleModel.UserId = 1;
            await _articleRepo.CreateAsync(articleModel);
            return CreatedAtAction(nameof(GetById), new { id = articleModel.Id}, articleModel.ToArticleDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateArticleRequestDto articleDto)
        {
            var articleModel = await _articleRepo.UpdateAsync(id, articleDto);
            if (articleModel == null) {
                return NotFound();
            }
            return Ok(articleModel.ToArticleDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var articleModel = await _articleRepo.DeleteAsync(id);
            if (articleModel == null) {
                return NotFound();
            }
            return NoContent();
        }
    }
}