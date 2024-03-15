using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Schilderij.UI.Web.MVC.Models;

public class NewPaintingViewModel
{
    [Required(ErrorMessage = "The title is required.")]
    public string Title { get; set; }

    [Range(1500, 2023, ErrorMessage = "The creation year must be between 1500 and 2023.")]
    public int CreationYear { get; set; }

    [Range(1000000, double.MaxValue, ErrorMessage = "The price must be at least 1 million dollars.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The museum name is required.")]
    public string MuseumName { get; set; }

    public string MuseumAddress { get; set; }

    public string MuseumUrl { get; set; }
}