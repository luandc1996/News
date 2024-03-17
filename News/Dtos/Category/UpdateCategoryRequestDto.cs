using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Dtos.Category
{
    public class UpdateCategoryRequestDto
    {
        public string Name {get; set;} = string.Empty;
        //public string Slug {get; set;} = string.Empty;
    }
}