using Microsoft.EntityFrameworkCore;
using Schilderij.BL.Domain;

namespace Schilderij.DAL.EF;

public class Repository : IRepository
{
    private readonly PainterDbContext _ctx;

    public Repository(PainterDbContext ctx)
    {
        _ctx = ctx;
    }


    public Painter ReadPainter(int painterId)
    {
        return _ctx.Painters.Find(painterId);
    }

    public IEnumerable<Painter> ReadAllPainters()
    {
        return _ctx.Painters;
    }

    public IEnumerable<Painter> ReadAllPaintersWithPaintings()
    {
        return _ctx.Painters
            .Include(painter => painter.Paintings)
            .ThenInclude(paintingPainter => paintingPainter.Painting);
    }

    public IEnumerable<Painter> ReadPaintersByStyle(PaintingStyles paintingStyle)
    {
        return _ctx.Painters.Where(painter => painter.PaintingStyle == paintingStyle)
            .Include(painter => painter.Paintings)
            .ThenInclude(paintingPainter => paintingPainter.Painting);
    }

    public void CreatePainter(Painter painter)
    {
        _ctx.Painters.Add(painter);
        _ctx.SaveChanges();
    }

    public Painting ReadPainting(int paintingId)
    {
        return _ctx.Paintings.Find(paintingId);
    }

    public IEnumerable<Painting> ReadAllPaintings()
    {
        return _ctx.Paintings;
    }

    public Painting ReadPaintingWithPainters(int paintingId)
    {
        return _ctx.Paintings
            .Include(painting => painting.Painters)
            .ThenInclude(paintingPainter => paintingPainter.Painter)
            .Single(painting => painting.Id == paintingId);
    }

    public IEnumerable<Painting> ReadAllPaintingsWithMuseum()
    {
        return _ctx.Paintings.Include(painting => painting.Museum);
    }

    public IEnumerable<Painting> ReadPaintingsByTitleAndCreationYear(string title, int year)
    {
        IQueryable<Painting> query = _ctx.Paintings.AsQueryable();

        // filters based on the parameters
        if (!string.IsNullOrEmpty(title))
        {
            title = title.ToLower();
            query = query.Where(painting => painting.Title.ToLower().Contains(title));
        }

        if (year != 0)
        {
            query = query.Where(painting => painting.CreationYear == year);
        }

        return query.Include(painting => painting.Museum);
    }

    public void CreatePainting(Painting painting)
    {
        _ctx.Paintings.Add(painting);
        _ctx.SaveChanges();
    }

    public void CreatePainterPainting(PainterPainting painterPainting)
    {
        _ctx.PainterPaintings.Add(painterPainting);
        _ctx.SaveChanges();
    }

    public void DeletePainterPainting(int painterId, int paintingId)
    {
        _ctx.PainterPaintings.Remove(_ctx.PainterPaintings
            .Single(painter => painter.Painter.Id == painterId && painter.Painting.Id == paintingId));
        _ctx.SaveChanges();
    }

    public IEnumerable<Painting> ReadPaintingsOfPainter(int painterId)
    {
        return _ctx.PainterPaintings
            .Include(painterPainting => painterPainting.Painting)
            .ThenInclude(painting => painting.Museum)
            .Where(painterPainting => painterPainting.Painter.Id == painterId)
            .Select(painterPainting => painterPainting.Painting);
    }

    public IEnumerable<Museum> ReadAllMuseums()
    {
        return _ctx.Museums;
    }

    public Museum ReadMuseum(int museumId)
    {
        return _ctx.Museums.Find(museumId);
    }

    public void CreateMuseum(Museum museum)
    {
        _ctx.Museums.Add(museum);
        _ctx.SaveChanges();
    }

    public IEnumerable<Painting> ReadPaintingWithoutPainter(int id)
    {
        List<PainterPainting> result =
            _ctx.PainterPaintings
                .Include(pp => pp.Painting)
                .Where(pp => pp.Painter.Id == id).ToList();
        List<Painting> paintings = _ctx.Paintings.ToList();

        foreach (PainterPainting pp in result)
        {
            Painting painting = pp.Painting;

            paintings.Remove(painting);
        }

        return paintings;
    }

    public bool AssociatePaintingToPainter(int painterid, int paintingid, string signed)
    {
        bool isSigned = false;
        Painter painter = _ctx.Painters.FirstOrDefault(painter => painter.Id == Convert.ToInt32(painterid));
        Painting painting = _ctx.Paintings.FirstOrDefault(painting => painting.Id == Convert.ToInt32(paintingid));
        if (signed == "on")
            isSigned = true;


        PainterPainting painterPainting = new PainterPainting()
        {
            IsSigned = isSigned,

            Painting = painting,
            Painter = painter,
        };

        _ctx.PainterPaintings.Add(painterPainting);
        _ctx.SaveChanges();
        _ctx.ChangeTracker.Clear();
        return true;
    }

    public Painter ReadPainterWithPaintings(int id)
    {
        return _ctx.Painters
            .Include(a => a.Paintings)
            .ThenInclude(p => p.Painting)
            .FirstOrDefault(painter => painter.Id == id);
    }
}