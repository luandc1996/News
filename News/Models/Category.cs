using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class Category
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? Slug {get; set;}
        public int? ParentId {get; set;}
        public Category? Parent {get; set;}
        public IEnumerable<Category>? Childs { get; set;}
        public IEnumerable<Article>? Articles { get; set;}
    }
}