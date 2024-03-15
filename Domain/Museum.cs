using System.ComponentModel.DataAnnotations;

namespace Schilderij.BL.Domain;

public class Museum
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string WebsiteUrl { get; set; }
    public ICollection<Painting> Paintings { get; set; }
    
    public Museum()
    {
        Paintings = new List<Painting>();
    }
}