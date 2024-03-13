using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Dtos.Article
{
    public class CreateArticleRequestDto
    {
        public string Title {get; set;} = string.Empty;
        public string Content {get; set;} = string.Empty;
        public string Slug {get; set;} = string.Empty;
        public bool Status {get; set;}
        public int? UserId {get; set;}
        public int? CategoryId {get; set;}
    }
}