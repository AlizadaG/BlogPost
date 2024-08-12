using Microsoft.AspNetCore.Mvc;

namespace CeyhunApplication.Areas.Shabnam.Controllers;
[Area("Shabnam")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
