using Schilderij.BL.Domain;

namespace Schilderij.UI.CA.Extensions;

internal static class PainterExtensions
{
    internal static string GetInfo(this Painter painter)
    {
        string status = "Alive";
        string painterInfo =
            $"Painter name: {painter.PainterName,-40} Birth date: {painter.BirthDate.ToShortDateString(),-30} ";

        if (painter.DeathDate.HasValue)
        {
            painterInfo += $"Date of death: {painter.DeathDate.Value.ToShortDateString(),-20}";
        }
        else
        {
            painterInfo += $"{status,-35}";
        }

        painterInfo += $"Nationality: {painter.Nationality,-20} ";
        painterInfo += $"Painting style: {painter.PaintingStyle}" + "\n\n";
        painterInfo += $"Has painted {painter.Paintings.Count} paintings: \n\n";

        
        foreach (var painting in painter.Paintings)
        {
            painterInfo += $"Title: {painting.Painting.Title,-25} Year created: {painting.Painting.CreationYear, -25}" +
                           "\n";
        }

        return painterInfo;
    }
}