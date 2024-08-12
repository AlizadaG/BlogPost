using CeyhunApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CeyhunApplication.ViewComponents;

public class PopularTagViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _context;
    public PopularTagViewComponent(ApplicationDbContext context) => _context = context;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var tags = await _context.PopularTags.ToListAsync();
        return View(tags);
    }
}