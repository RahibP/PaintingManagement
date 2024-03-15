using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schilderij.BL.Domain;

public class Painting
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "The title is required.")]
    [MinLength(2, ErrorMessage = "The title has to contain at least two characters")]
    [StringLength(100, ErrorMessage = "There are only 100 characters allowed.")]
    public string Title { get; set; }

    [Range(1500, 2023, ErrorMessage = "The creation year must be between 1500 and 2023.")]
    public int CreationYear { get; set; }

    [Range(1000000, double.MaxValue, ErrorMessage = "The price must be at least 1 million dollars.")]
    public decimal Price { get; set; }


    public ICollection<PainterPainting> Painters { get; set; }

    public Painting()
    {
        Painters = new List<PainterPainting>();
    }

    [Required] public Museum Museum { get; set; }
}