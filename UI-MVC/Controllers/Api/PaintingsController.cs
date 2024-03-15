using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schilderij.BL;
using Schilderij.BL.Domain;

namespace Schilderij.UI.Web.MVC.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class PaintingsController : ControllerBase
{
    private readonly IManager _mgr;

    public PaintingsController(IManager mgr)
    {
        _mgr = mgr;
    }

    [HttpGet]
    public IActionResult GetAll(int id)
    {
        IEnumerable<Painting> paintings = _mgr.GetPaintingWithoutPainter(id);
        List<SelectListItem> items = new List<SelectListItem>();
        foreach (var painting in paintings)
        {
            var item = new SelectListItem { Text = painting.Title, Value = painting.Id.ToString() };
            items.Add(item);
        }

        if (items.Any())
            return Ok(items);
        return NoContent();
    }

    [HttpGet]
    [Route("AddPainting")]
    public IActionResult AddPainting(int painterid, int paintingid, string signed)
    {
        bool result = _mgr.LinkPaintingToPainter(painterid, paintingid, signed);
        return Ok(result ? "success" : "fail");
    }
}