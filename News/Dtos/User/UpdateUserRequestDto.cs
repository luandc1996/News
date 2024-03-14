using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Dtos.User
{
    public class UpdateUserRequestDto
    {
        public string? Name {get; set;}
        public string? Username {get; set;}
        public string? Password {get; set;}
        public bool Status {get; set;}
    }
}