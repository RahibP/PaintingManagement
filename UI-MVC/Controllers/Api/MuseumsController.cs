using Microsoft.AspNetCore.Mvc;
using Schilderij.BL;
using Schilderij.BL.Domain;

namespace Schilderij.UI.Web.MVC.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class MuseumsController : ControllerBase
{
    private readonly IManager _mgr;

    public MuseumsController(IManager mgr)
    {
        _mgr = mgr;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<Museum> museums = _mgr.GetAllMuseums();
        if (museums.Any())
            return Ok(museums);
        return NoContent();
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int museumId)
    {
        Museum museum = _mgr.GetMuseum(museumId);
        if (museum == null)
        {
            return NotFound("Museum not found.");
        }

        return Ok(museum);
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] Museum museum)
    {
        Museum newMuseum = _mgr.AddMuseum(museum.Name, museum.Address, museum.WebsiteUrl);
        
        return CreatedAtAction("Get", new {id = newMuseum.Id}, newMuseum);
    }
}