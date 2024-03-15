using Schilderij.BL.Domain;

namespace Schilderij.UI.CA.Extensions
{
    internal static class PaintingExtensions
    {
        internal static string GetInfo(this Painting painting)
        {
            string museum = painting.Museum.Name;

            string formattedPrice = $"{painting.Price:N0}".Replace(",", ".");
            
            string paintingInfo =
                $"Title: {painting.Title,-25} Year created: {painting.CreationYear,-25} Price: ${formattedPrice, -30}" +
                $"Located in: {museum,-25}" + "\n";

            return paintingInfo;
        }
    }
}