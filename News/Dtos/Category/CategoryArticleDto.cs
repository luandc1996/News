using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Dtos.Article;
using News.Models;

namespace News.Dtos.Category
{
    public class CategoryArticleDto: CategoryDto
    {
        public IEnumerable<ArticleDto>? Articles { get; set;}
    }
}