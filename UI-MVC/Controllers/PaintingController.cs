using Microsoft.AspNetCore.Mvc;
using Schilderij.BL;
using Schilderij.BL.Domain;
using Schilderij.UI.Web.MVC.Models;

namespace Schilderij.UI.Web.MVC.Controllers;

public class PaintingController : Controller
{
    private readonly IManager _mgr;

    public PaintingController(IManager mgr)
    {
        _mgr = mgr;
    }

    public IActionResult Index()
    {
        IEnumerable<Painting> paintings = _mgr.GetAllPaintings();
        return View(paintings);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(NewPaintingViewModel model)
    {
        if (ModelState.IsValid)
        {
            Museum museum = new Museum
            {
                Name = model.MuseumName,
                Address = model.MuseumAddress,
                WebsiteUrl = model.MuseumUrl
            };

            Painting painting = _mgr.AddPainting(model.Title, model.CreationYear, model.Price, museum);

            return RedirectToAction("Details", new { id = painting.Id });
        }

        return View();
    }

    public IActionResult Details(int id)
    {
        return View(_mgr.GetPaintingWithPainters(id));
    }
}