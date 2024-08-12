using Microsoft.AspNetCore.Mvc;

namespace CeyhunApplication.Areas.Admin.Controllers;
[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Privacy() => View();

}
