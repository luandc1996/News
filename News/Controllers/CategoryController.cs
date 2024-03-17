using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News.Data;
using News.Dtos.Category;
using News.Interfaces;
using News.Mappers;
using Slugify;

namespace News.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICategoryRepository _catRepo;
        
        public CategoryController(AppDbContext context, ICategoryRepository categoryRepo)
        {
            _context = context;
            _catRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _catRepo.GetAllAsync();
            var modelCategories = categories.Select(s => s.ToCategoryWithAricleDto());
            return Ok(modelCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _catRepo.GetByIdAsync(id);
            if (category != null) {
                return Ok(category.ToCategoryWithAricleDto());
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryFromCreateDTO();
            // Xu ly du lieu và kiểm tra trùng lặp
            SlugHelper slugHelper = new SlugHelper();
            categoryModel.Slug = slugHelper.GenerateSlug(categoryModel.Name);
            categoryModel.ParentId = (categoryModel.ParentId != 0) ? categoryModel.ParentId : null;
            if (categoryModel.Slug != "") {
                var isExist = await _catRepo.CheckDuplicate(categoryModel.Slug);
                if (isExist != null) {
                    return BadRequest("Chuyên mục " + categoryModel.Name + " đã tồn tại");
                }
            }
            // Xu ly luu
            await _catRepo.CreateAsync(categoryModel);
            return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id}, categoryModel.ToCategoryDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestDto categoryDto)
        {
            var categoryModel = await _catRepo.UpdateAsync(id, categoryDto);
            if (categoryModel == null) {
                return NotFound();
            }
            return Ok(categoryModel.ToCategoryDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var categoryModel = await _catRepo.DeleteAsync(id);
            if (categoryModel == null) {
                return NotFound();
            }
            return NoContent();
        }
    }
}