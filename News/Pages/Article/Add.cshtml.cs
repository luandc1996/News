using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using News.Interfaces;
using News.Models;

namespace News.Pages.Articles
{
    public class Add : PageModel
    {
        private readonly ICategoryRepository _catRepo;

        public Add(ICategoryRepository categoryRepository)
        {
            _catRepo = categoryRepository;
        }

        public IList<Category> Categories {get; set;}

        public async Task OnGetAsync()
        {
            Categories = await _catRepo.GetAllAsync();
        }
    }
}