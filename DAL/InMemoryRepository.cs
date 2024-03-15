using Schilderij.BL.Domain;

namespace Schilderij.DAL;

public class InMemoryRepository : IRepository
{
    private static readonly List<Painter> Painters = new();
    private static readonly List<Painting> Paintings = new();


    public static void Seed()
    {
        #region Museums

        Museum louvre = new Museum
        {
            Id = 1,
            Name = "Louvre",
            Address = "Musée du Louvre, 75058 Paris, France",
            WebsiteUrl = "https://www.louvre.fr/en"
        };

        Museum museumModernArt = new Museum
        {
            Id = 2,
            Name = "Museum of Modern Art",
            Address = "11 West 53rd Street Manhattan, New York City, USA",
            WebsiteUrl = "https://www.moma.org/"
        };

        Museum laCountyMuseum = new Museum
        {
            Id = 3,
            Name = "Los Angeles County Museum of Art\n",
            Address = "5905 Wilshire Blvd, Los Angeles, CA 90036, USA",
            WebsiteUrl = "https://www.lacma.org/"
        };

        Museum krefeld = new Museum
        {
            Id = 4,
            Name = "Kunstmuseen Krefeld",
            Address = "Joseph-Beuys-Platz 1, 47798 Krefeld, Germany",
            WebsiteUrl = "https://kunstmuseenkrefeld.de/de"
        };

        #endregion

        #region Painters

        Painter daVinci = new Painter
        {
            Id = 1,
            PainterName = "Leonardo da Vinci",
            BirthDate = new DateTime(1452, 4, 15),
            DeathDate = new DateTime(1519, 5, 2),
            Nationality = "Italian",
            PaintingStyle = PaintingStyles.Renaissance
        };
        Painters.Add(daVinci);

        Painter vanGogh = new Painter
        {
            Id = 2,
            PainterName = "Vincent Van Gogh",
            BirthDate = new DateTime(1853, 3, 30),
            DeathDate = new DateTime(1890, 7, 29),
            Nationality = "Dutch",
            PaintingStyle = PaintingStyles.Postimpressionism
        };
        Painters.Add(vanGogh);

        Painter magritte = new Painter
        {
            Id = 3,
            PainterName = "René Magritte",
            BirthDate = new DateTime(1898, 11, 21),
            DeathDate = new DateTime(1967, 8, 15),
            Nationality = "Belgian",
            PaintingStyle = PaintingStyles.Surrealism
        };
        Painters.Add(magritte);

        Painter richter = new Painter
        {
            Id = 4,
            PainterName = "Gerhard Richter",
            BirthDate = new DateTime(1932, 2, 9),
            DeathDate = null,
            Nationality = "German",
            PaintingStyle = PaintingStyles.Conceptual
        };
        Painters.Add(richter);

        #endregion

        #region Paintings

        Painting monaLisa = new Painting
        {
            Id = 1,
            Title = "Mona Lisa",
            CreationYear = 1519,
            Price = 860000000,
            Museum = louvre
        };
        Paintings.Add(monaLisa);

        Painting starryNight = new Painting
        {
            Id = 2,
            Title = "The Starry Night",
            CreationYear = 1889,
            Price = 100000000,
            Museum = museumModernArt
        };
        Paintings.Add(starryNight);

        Painting treacheryImages = new Painting
        {
            Id = 3,
            Title = "The Treachery of Images",
            CreationYear = 1929,
            Price = 60000000,
            Museum = laCountyMuseum
        };
        Paintings.Add(treacheryImages);

        Painting colours1024 = new Painting
        {
            Id = 4,
            Title = "1024 Colours",
            CreationYear = 1973,
            Price = 40000000,
            Museum = krefeld
        };
        Paintings.Add(colours1024);

        #endregion
    }

    public Painting ReadPaintingWithPainters(int paintingId)
    {
        throw new NotImplementedException();
    }

    public Painter ReadPainter(int painterId)
    {
        return Painters.Find(painter => painter.Id == painterId);
    }

    public IEnumerable<Painter> ReadAllPainters()
    {
        return Painters;
    }

    public IEnumerable<Painter> ReadAllPaintersWithPaintings()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Painter> ReadPaintersByStyle(PaintingStyles paintingStyle)
    {
        return Painters.Where(painter => painter.PaintingStyle == paintingStyle);
    }

    public void CreatePainter(Painter painter)
    {
        painter.Id = Painters.Count + 1;
        Painters.Add(painter);
    }

    public Painting ReadPainting(int paintingId)
    {
        return Paintings.Find(painting => painting.Id == paintingId);
    }

    public IEnumerable<Painting> ReadAllPaintings()
    {
        return Paintings;
    }

    public IEnumerable<Painting> ReadAllPaintingsWithMuseum()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Painting> ReadPaintingsByTitleAndCreationYear(string title, int year)
    {
        ICollection<Painting> filteredPaintings = new List<Painting>(Paintings);

        if (!string.IsNullOrEmpty(title))
        {
            title = title.ToLower();
            filteredPaintings = filteredPaintings.Where(painting => painting.Title.ToLower().Contains(title)).ToList();
        }
        
        if (year != 0)
        {
            filteredPaintings = filteredPaintings.Where(painting => painting.CreationYear == year).ToList();
        }
        
        return filteredPaintings.ToList();
    }

    public void CreatePainting(Painting painting)
    {
        painting.Id = Paintings.Count + 1;
        Paintings.Add(painting);
    }

    public void CreatePainterPainting(PainterPainting painterPainting)
    {
        throw new NotImplementedException();
    }

    public void DeletePainterPainting(int painterId, int paintingId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Painting> ReadPaintingsOfPainter(int painterId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Museum> ReadAllMuseums()
    {
        throw new NotImplementedException();
    }

    public Museum ReadMuseum(int museumId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Museum> ReadAllMuseumsWithPaintings()
    {
        throw new NotImplementedException();
    }

    public void CreateMuseum(Museum museum)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Painting> ReadPaintingWithoutPainter(int id)
    {
        throw new NotImplementedException();
    }

    public bool AssociatePaintingToPainter(int painterId, int paintingId, string isSigned)
    {
        throw new NotImplementedException();
    }

    public Painter ReadPainterWithPaintings(int id)
    {
        throw new NotImplementedException();
    }
}