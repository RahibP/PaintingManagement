using Schilderij.BL.Domain;

namespace Schilderij.UI.CA.Extensions;

internal static class MuseumExtensions
{
    internal static string GetInfo(this Museum museum)
    {
        return $"Name: {museum.Name} Address: {museum.Address} website URL: {museum.WebsiteUrl}";
    }
}