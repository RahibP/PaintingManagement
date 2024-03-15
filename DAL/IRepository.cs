using Schilderij.BL.Domain;

namespace Schilderij.DAL;

public interface IRepository
{
    Painter ReadPainter(int painterId);
    IEnumerable<Painter> ReadAllPainters();
    IEnumerable<Painter> ReadAllPaintersWithPaintings();
    IEnumerable<Painter> ReadPaintersByStyle(PaintingStyles paintingStyle);
    void CreatePainter(Painter painter);
    Painting ReadPainting(int paintingId);
    IEnumerable<Painting> ReadAllPaintings();
    IEnumerable<Painting> ReadAllPaintingsWithMuseum();
    Painting ReadPaintingWithPainters(int paintingId);
    IEnumerable<Painting> ReadPaintingsByTitleAndCreationYear(string title, int creationYear);
    void CreatePainting(Painting painting);
    void CreatePainterPainting(PainterPainting painterPainting);
    void DeletePainterPainting(int painterId, int paintingId);
    IEnumerable<Painting> ReadPaintingsOfPainter(int painterId);
    IEnumerable<Museum> ReadAllMuseums();
    Museum ReadMuseum(int museumId);
    void CreateMuseum(Museum museum);
    IEnumerable<Painting> ReadPaintingWithoutPainter(int id);
    bool AssociatePaintingToPainter(int painterId, int paintingId, string signed);
    Painter ReadPainterWithPaintings(int id);
}