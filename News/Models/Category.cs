using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class Category
    {
        public int Id {get; set;}
        public int Name {get; set;}
        public int Slug {get; set;}

        public List<Article> Articles {get; set;} = new List<Article>();
    }
}