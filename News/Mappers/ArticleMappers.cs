using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Dtos.Article;
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
                //User = articleModel.User.Select(u => u.ToUserDto()).ToList()
            };
        }

        public static Article ToArticleFromCreateDTO(this CreateArticleRequestDto articleDto)
        {
            return new Article
            {
                Title = articleDto.Title,
                Slug = articleDto.Slug,
                Content = articleDto.Content,
                Status = articleDto.Status,
                UserId = articleDto.UserId,
                CategoryId = articleDto.CategoryId
            };
        }
    }
}