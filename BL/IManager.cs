using Schilderij.BL.Domain;

namespace Schilderij.BL;

public interface IManager
{
    Painter GetPainter(int painterId);
    IEnumerable<Painter> GetAllPainters();

    IEnumerable<Painter> GetAllPaintersWithPaintings();
    IEnumerable<Painter> GetPaintersByStyle(PaintingStyles paintingStyle);

    Painter AddPainter(string painterName, DateTime birthDate, DateTime? deathDate, string nationality,
        PaintingStyles paintingStyle);

    Painting GetPainting(int paintingId);
    IEnumerable<Painting> GetAllPaintings();
    IEnumerable<Painting> GetAllPaintingsWithMuseum();
    Painting GetPaintingWithPainters(int paintingId);
    IEnumerable<Painting> GetPaintingsByTitleAndCreationYear(string title, int creationYear);
    Painting AddPainting(string title, int creationYear, decimal price, Museum museum);
    void AddPaintingToPainter(Painter painter, Painting painting, bool isSigned);
    void RemovePaintingFromPainter(Painter painter, Painting painting);
    IEnumerable<Painting> GetPainterWithPaintings(int painterId);
    
    IEnumerable<Museum> GetAllMuseums();
    Museum GetMuseum(int museumId);
    Museum AddMuseum(string name, string address, string websiteUrl);
    IEnumerable<Painting> GetPaintingWithoutPainter(int id);
    bool LinkPaintingToPainter(int painterId, int paintingId, string signed);
    Painter GetPainterWithPainting(int id);
}