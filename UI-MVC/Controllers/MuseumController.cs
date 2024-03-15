using Microsoft.AspNetCore.Mvc;

namespace Schilderij.UI.Web.MVC.Controllers;

public class MuseumController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}