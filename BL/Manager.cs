using System.ComponentModel.DataAnnotations;
using System.Text;
using Schilderij.BL.Domain;
using Schilderij.DAL;

namespace Schilderij.BL;

public class Manager : IManager
{
    private readonly IRepository _repository;

    public Manager(IRepository repository)
    {
        _repository = repository;
    }

    public Painter GetPainter(int painterId)
    {
        return _repository.ReadPainter(painterId);
    }

    public IEnumerable<Painter> GetAllPainters()
    {
        return _repository.ReadAllPainters();
    }

    public IEnumerable<Painter> GetAllPaintersWithPaintings()
    {
        return _repository.ReadAllPaintersWithPaintings();
    }

    public IEnumerable<Painter> GetPaintersByStyle(PaintingStyles paintingStyle)
    {
        return _repository.ReadPaintersByStyle(paintingStyle);
    }

    public Painter AddPainter(string painterName, DateTime birthDate, DateTime? deathDate, string nationality,
        PaintingStyles paintingStyle)
    {
        Painter painter = new Painter()
        {
            PainterName = painterName,
            BirthDate = birthDate,
            DeathDate = deathDate,
            Nationality = nationality,
            PaintingStyle = paintingStyle
        };

        List<ValidationResult> errors = new List<ValidationResult>();

        bool valid = Validator.TryValidateObject(painter, new ValidationContext(painter), errors,
            validateAllProperties: true);

        if (valid)
        {
            _repository.CreatePainter(painter);
            return painter;
        }

        StringBuilder errorMessage = new StringBuilder();
        foreach (ValidationResult error in errors)
        {
            errorMessage.Append(error.ErrorMessage + "\n");
        }

        throw new ValidationException(errorMessage.ToString());
    }

    public Painting GetPainting(int paintingId)
    {
        return _repository.ReadPainting(paintingId);
    }

    public IEnumerable<Painting> GetAllPaintings()
    {
        return _repository.ReadAllPaintings();
    }

    public Painting GetPaintingWithPainters(int paintingId)
    {
        return _repository.ReadPaintingWithPainters(paintingId);
    }

    public IEnumerable<Painting> GetAllPaintingsWithMuseum()
    {
        return _repository.ReadAllPaintingsWithMuseum();
    }

    public IEnumerable<Painting> GetPaintingsByTitleAndCreationYear(string title, int creationYear)
    {
        return _repository.ReadPaintingsByTitleAndCreationYear(title.ToLower(), creationYear);
    }

    public Painting AddPainting(string title, int creationYear, decimal price, Museum museum)
    {
        Painting painting = new Painting()
        {
            Title = title,
            CreationYear = creationYear,
            Price = price,
            Museum = museum
        };

        List<ValidationResult> errors = new List<ValidationResult>();

        bool valid = Validator.TryValidateObject(painting, new ValidationContext(painting), errors,
            validateAllProperties: true);

        if (valid)
        {
            _repository.CreatePainting(painting);
            return painting;
        }
        else
        {
            StringBuilder errorMessage = new StringBuilder();
            foreach (ValidationResult error in errors)
            {
                errorMessage.Append(error.ErrorMessage + "\n");
            }

            throw new ValidationException(errorMessage.ToString());
        }
    }

    public void AddPaintingToPainter(Painter painter, Painting painting, bool isSigned)
    {
        PainterPainting painterPainting = new PainterPainting
        {
            IsSigned = isSigned,
            Painter = painter,
            Painting = painting
        };

        _repository.CreatePainterPainting(painterPainting);
    }

    public void RemovePaintingFromPainter(Painter painter, Painting painting)
    {
        _repository.DeletePainterPainting(painter.Id, painting.Id);
    }

    public IEnumerable<Painting> GetPainterWithPaintings(int painterId)
    {
        return _repository.ReadPaintingsOfPainter(painterId);
    }

    public IEnumerable<Museum> GetAllMuseums()
    {
        return _repository.ReadAllMuseums();
    }

    public Museum GetMuseum(int museumId)
    {
        return _repository.ReadMuseum(museumId);
    }

    public Museum AddMuseum(string name, string address, string websiteUrl)
    {
        Museum museum = new Museum()
        {
            Name = name,
            Address = address,
            WebsiteUrl = websiteUrl
        };

        List<ValidationResult> errors = new List<ValidationResult>();

        bool valid = Validator.TryValidateObject(museum, new ValidationContext(museum), errors,
            validateAllProperties: true);

        if (valid)
        {
            _repository.CreateMuseum(museum);
            return museum;
        }

        StringBuilder errorMessage = new StringBuilder();
        foreach (ValidationResult error in errors)
        {
            errorMessage.Append(error.ErrorMessage + "\n");
        }

        throw new ValidationException(errorMessage.ToString());
    }

    public IEnumerable<Painting> GetPaintingWithoutPainter(int id)
    {
        return _repository.ReadPaintingWithoutPainter(id);
    }

    public bool LinkPaintingToPainter(int painterId, int paintingId, string signed)
    {
        return _repository.AssociatePaintingToPainter(painterId, paintingId, signed);
    }

    public Painter GetPainterWithPainting(int id)
    {
        return _repository.ReadPainterWithPaintings(id);
    }
}