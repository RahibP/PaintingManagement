using Microsoft.AspNetCore.Mvc;
using Schilderij.BL;

namespace Schilderij.UI.Web.MVC.Controllers;

public class PainterController : Controller
{
    private readonly IManager _mgr;

    public PainterController(IManager mgr)
    {
        _mgr = mgr;
    }

    [Route("Details")]
    public ActionResult Details(int id)
    {
        return View(_mgr.GetPainter(id));
    }
    
    [HttpGet]
    [Route("ReloadData")]
    public IActionResult ReloadData(int id)
    {
        var result = _mgr.GetPainterWithPainting(id);
        return PartialView("ReloadData", result);
    }
}