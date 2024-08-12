
using CeyhunApplication.Abstractions.Repositories;
using CeyhunApplication.Abstractions.Services;
using CeyhunApplication.Data;
using CeyhunApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CeyhunApplication.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoriesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ICategoryWriteRepository _categoryWriteRepository;
    private readonly ICategoryReadRepository _categoryReadRepository;

    private readonly ICategoryService _categoryService;

    public CategoriesController(ApplicationDbContext context, ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository, ICategoryService categoryService)
    {
        _context = context;
        _categoryWriteRepository = categoryWriteRepository;
        _categoryReadRepository = categoryReadRepository;
        _categoryService = categoryService;
    }

    // GET: Admin/Categories
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Categories.Include(c => c.ParentCategory);
        return View(await applicationDbContext.ToListAsync());
    }

    /*    // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                 .Include(c => c.ParentCategory)
                 .FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

    */

    // GET: Admin/Categories/Details/5
    public IActionResult Details(int id)
    {
        Category category = _categoryService.GetCategoryById(id);
        return View(category);
    }




    // GET: Admin/Categories/Create
    public IActionResult Create()
    {
        ViewData["ParentCategoryId"] = new SelectList(
            _context.Categories.Where(c => c.ParentCategoryId == null)  // only show categories that don't have a parent
            , "Id", "Title");
        return View();
    }

    // POST: Admin/Categories/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,ParentCategoryId,Id")] Category category)
    {
        if (ModelState.IsValid)
        {
            /*_context.Add(category);
            await _context.SaveChangesAsync();*/

            _categoryWriteRepository.Add(category);
            await _categoryWriteRepository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        ViewData["ParentCategoryId"] = new SelectList(
                 _context.Categories.Where(c => c.ParentCategoryId == null)  // only show categories that don't have a parent
                 , "Id", "Title");
        return View(category);
    }

    // GET: Admin/Categories/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Id", category.ParentCategoryId);
        return View(category);
    }

    // POST: Admin/Categories/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Title,ParentCategoryId,Id")] Category category)
    {
        if (id != category.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Id", category.ParentCategoryId);
        return View(category);
    }

    // GET: Admin/Categories/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var category = await _context.Categories
            .Include(c => c.ParentCategory)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    // POST: Admin/Categories/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CategoryExists(int id)
    {
        return _context.Categories.Any(e => e.Id == id);
    }
}



