using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Dtos.Article;
using News.Models;

namespace News.Dtos.User
{
    public class UserArticleDto: UserDto
    {
        public IEnumerable<ArticleDto>? Articles { get; set;}
    }
}