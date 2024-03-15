using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Schilderij.BL;
using Schilderij.BL.Domain;
using Schilderij.UI.Web.MVC.Models;

namespace Schilderij.UI.Web.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IManager _mgr;

    public HomeController(ILogger<HomeController> logger, IManager mgr)
    {
        _logger = logger;
        _mgr = mgr;
    }

    public IActionResult Index()
    {
        IEnumerable<Painting> paintings = _mgr.GetAllPaintings();
        return View(paintings);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}