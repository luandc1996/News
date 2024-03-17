using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Dtos.Article;
using News.Models;

namespace News.Dtos.User
{
    public class UserDto
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        // public string Username {get; set;}
        // public string Password {get; set;}
        // public bool Status {get; set;}
        public IEnumerable<ArticleDto>? Articles { get; set;}
    }
}