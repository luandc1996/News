using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Dtos.Category;
using News.Dtos.User;
using News.Models;

namespace News.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Slug = categoryModel.Slug,
                ParentId = categoryModel.ParentId,
            };
        }

        public static CategoryDto ToCategoryWithAricleDto(this Category categoryModel)
        {
            return new CategoryArticleDto
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Slug = categoryModel.Slug,
                Articles = categoryModel.Articles?.Select(a => a.ToArticleDto()).ToList()
            };
        }

        public static Category ToCategoryFromCreateDTO(this CreateCategoryRequestDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
                ParentId = categoryDto.ParentId
                //Slug = categoryDto.Slug
            };
        }
    }
}