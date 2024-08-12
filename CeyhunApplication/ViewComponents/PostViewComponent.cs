using CeyhunApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CeyhunApplication.ViewComponents;

public class PostViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _context;
    public PostViewComponent(ApplicationDbContext context) => _context = context;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        // cd order. top 5  en son eklenen 5 post
        var posts = await _context.Posts
            .OrderByDescending(post => post.PublishDate)
            .Take(5)
            .ToListAsync();
        return View(posts);
    }
}