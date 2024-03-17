using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Interfaces;
using News.Models;

namespace News.Pages.Articles;

public class Index : PageModel
{
    private readonly IArticleRepository _articleRepo;

    public Index(IArticleRepository articleRepository) 
    {
        _articleRepo = articleRepository;
    }

    public IList<Article> Articles {get; set;}
    
    public async Task OnGetAsync()
    {
        Articles = await _articleRepo.GetAllAsync();   
    }
}