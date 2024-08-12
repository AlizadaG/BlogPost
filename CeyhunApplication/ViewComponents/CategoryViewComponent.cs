using CeyhunApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CeyhunApplication.ViewComponents;

public class CategoryViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _context;
    public CategoryViewComponent(ApplicationDbContext context) => _context = context;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return View(categories);
    }
}


public class CustomViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(string firstname, string lastname, string? mail = null)
    {

        var tuple = new Tuple<string, string>(firstname, lastname);
        return View(tuple);
    }
}