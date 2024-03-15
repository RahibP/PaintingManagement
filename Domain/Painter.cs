using System.ComponentModel.DataAnnotations;

namespace Schilderij.BL.Domain;

public class Painter : IValidatableObject
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "The name is required.")]
    [MinLength(2, ErrorMessage = "The name has to contain at least two characters.")]
    [StringLength(100, ErrorMessage = "There are only 100 characters allowed.")]
    public string PainterName { get; set; }

    public DateTime BirthDate { get; set; }

    public DateTime? DeathDate { get; set; } // can still be alive

    [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Please enter a nationality beginning with a capital letter.")]
    public string Nationality { get; set; }

    public PaintingStyles PaintingStyle { get; set; }
    public ICollection<PainterPainting> Paintings { get; set; }

    public Painter()
    {
        Paintings = new List<PainterPainting>();
    }
    IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new List<ValidationResult>();

        if (BirthDate > DateTime.Now)
        {
            errors.Add(new ValidationResult("Birth date cannot be in the future.", new[] { "BirthDate" }));
        }

        if (DeathDate.HasValue && DeathDate.Value > DateTime.Now)
        {
            errors.Add(new ValidationResult("Date of death cannot be in the future.", new[] { "DeathDate" }));
        }

        return errors;
    }
}