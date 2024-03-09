using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class Article
    {
        public int Id {get; set;}
        public string Title {get; set;} = string.Empty;
        public string Content {get; set;} = string.Empty;
        public bool Status {get; set;}
        public int CatId {get; set;}
        public int? UserId {get; set;}

        public User? User {get; set;}


        public DateTime CreatedAt {get; set;} = DateTime.Now;
    }
}