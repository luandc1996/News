using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Dtos.Category;
using News.Dtos.User;
using News.Models;

namespace News.Dtos.Article
{
    public class ArticleDto
    {
        public int Id {get; set;}
        public string Title {get; set;} = string.Empty;
        public string Content {get; set;} = string.Empty;
        public string Slug {get; set;} = string.Empty;
        public bool Status {get; set;}
        public int? UserId {get; set;}
        public int? CategoryId {get; set;}
        public UserDto? Author {get; set;}
        public CategoryDto? Category {get; set;}
    }
}