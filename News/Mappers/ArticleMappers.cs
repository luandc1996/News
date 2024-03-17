using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Dtos.Article;
using News.Dtos.Category;
using News.Dtos.User;
using News.Models;

namespace News.Mappers
{
    public static class ArticleMappers
    {
        public static ArticleDto ToArticleDto(this Article articleModel)
        {
            return new ArticleDto
            {
                Id = articleModel.Id,
                Title = articleModel.Title,
                Slug = articleModel.Slug,
                Content = articleModel.Content,
                Status = articleModel.Status,
                UserId = articleModel.UserId,
                CategoryId = articleModel.CategoryId,
                Category = (articleModel.Category != null) ? new CategoryDto() {
                    Id = articleModel.Category.Id,
                    Name = articleModel.Category.Name,
                    Slug = articleModel.Category.Slug
                } : null,
                User = (articleModel.User != null) ? new UserDto() {
                    Id = articleModel.User.Id,
                    Name = articleModel.User.Name,
                } : null,
            };
        }

        public static Article ToArticleFromCreateDTO(this CreateArticleRequestDto articleDto)
        {
            return new Article
            {
                Title = articleDto.Title,
                Content = articleDto.Content,
                Status = articleDto.Status,
                UserId = articleDto.UserId,
                CategoryId = articleDto.CategoryId
            };
        }
    }
}