using System.ComponentModel.DataAnnotations;

namespace Schilderij.BL.Domain;

public class PainterPainting
{
    public bool IsSigned { get; set; }
    [Required] public Painter Painter { get; set; }
    [Required] public Painting Painting { get; set; }
}