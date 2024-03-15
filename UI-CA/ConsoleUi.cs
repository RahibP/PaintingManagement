using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Schilderij.BL;
using Schilderij.BL.Domain;
using Schilderij.UI.CA.Extensions;

namespace Schilderij.UI.CA;

public class ConsoleUi
{
    private readonly IManager _mgr;

    public ConsoleUi(IManager manager)
    {
        _mgr = manager;
    }

    public void Run()
    {
        try
        {
            bool isActive;
            do
            {
                isActive = Menu();
            } while (isActive);
        }
        catch (ValidationException validationException)
        {
            Console.WriteLine(validationException.Message);
        }

        Console.WriteLine("Quitting...");
    }


    private bool Menu()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("==========================");
        Console.WriteLine("0) Quit\n");
        Console.WriteLine("1) Show all painters");
        Console.WriteLine("2) Show painters by style");
        Console.WriteLine("3) Show all paintings");
        Console.WriteLine("4) Show paintings with name and/or year of creation");
        Console.WriteLine("5) Add a painter");
        Console.WriteLine("6) Add a painting");
        Console.WriteLine("7) Add painting to painter");
        Console.WriteLine("8) Remove painting from painter");
        Console.WriteLine("Choice (0-8):");
        try
        {
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                throw new InvalidOperationException();
            }

            Console.Clear();
            switch (choice)
            {
                case 0:
                    return false;
                case 1:
                    Console.Clear();
                    ShowAllPainters();
                    return true;
                case 2:
                    Console.Clear();
                    ShowPaintersByStyle();
                    return true;
                case 3:
                    Console.Clear();
                    ShowAllPaintings();
                    return true;
                case 4:
                    Console.Clear();
                    ShowFilteredPaintings();
                    return true;
                case 5:
                    Console.Clear();
                    AddPainters();
                    return true;
                case 6:
                    Console.Clear();
                    AddPaintings();
                    return true;
                case 7:
                    Console.Clear();
                    AddPaintingToPainter();
                    return true;
                case 8:
                    Console.Clear();
                    RemovePaintingFromPainter();
                    return true;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You did not enter a valid number. Please try again.\n");
                    Console.ResetColor();
                    return true;
            }
        }
        catch (FormatException)
        {
            Console.Clear();
            Console.WriteLine("Wrong input. Please try again!\n");
        }
        catch (InvalidOperationException)
        {
            Console.Clear();
            Console.WriteLine("Wrong input. Please try again\n");
        }

        return true;
    }

    private void ShowAllPainters()
    {
        foreach (Painter painter in _mgr.GetAllPaintersWithPaintings())
        {
            Console.WriteLine(painter.GetInfo());
        }
    }


    private void ShowAllPaintings()
    {
        foreach (Painting painting in _mgr.GetAllPaintingsWithMuseum())
        {
            Console.WriteLine(painting.GetInfo());
        }
    }

    private void ShowPaintersByStyle()
    {
        foreach (string name in Enum.GetNames(typeof(PaintingStyles)))
        {
            Console.WriteLine(name + " - " + (int)Enum.Parse(typeof(PaintingStyles), name));
        }

        try
        {
            Console.Write("Choose a style by entering the corresponding number: ");
            _mgr.GetPaintersByStyle((PaintingStyles)int.Parse(Console.ReadLine() ?? string.Empty)).ToList()
                .ForEach(painter => Console.WriteLine(painter.GetInfo()));
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input. Please try again.");
        }
    }

    private void ShowFilteredPaintings()
    {
        Console.Write("Enter (part of) a name or leave this blank: ");
        string inputName = Console.ReadLine();
        Console.Write("Enter a year between 1500 and 2023 or leave this blank: ");
        string yearInput = Console.ReadLine();
        Console.WriteLine();

        int.TryParse(yearInput, out int inputYear);

        foreach (Painting painting in _mgr.GetPaintingsByTitleAndCreationYear(inputName, inputYear))
        {
            Console.WriteLine(painting.GetInfo());
        }
    }

    private void AddPainters()
    {
        Console.WriteLine("Add painter");
        Console.WriteLine("===========");

        Console.Write("Enter a painter's name: ");
        string painterName = Console.ReadLine();


        DateTime birthDatePainter;
        while (true)
        {
            Console.Write("Enter a date of birth (dd/mm/yyyy): ");
            string inputBirthDate = Console.ReadLine();

            if (DateTime.TryParseExact(inputBirthDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None,
                    out birthDatePainter))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a date in the format dd/mm/yyyy.");
            }
        }

        DateTime? deathDatePainter = null;
        Console.Write("Enter a death date (dd/mm/yyyy) or leave blank if alive: ");
        string inputDeathDate = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(inputDeathDate))
        {
            while (true)
            {
                if (string.IsNullOrWhiteSpace(inputDeathDate))
                {
                    break;
                }

                if (!DateTime.TryParseExact(inputDeathDate, "dd/MM/yyyy", null,
                        System.Globalization.DateTimeStyles.None,
                        out DateTime deathDate))
                {
                    Console.Write(
                        "Invalid date format. Please enter a date in the format dd/mm/yyyy or leave blank if alive: ");
                    inputDeathDate = Console.ReadLine();
                }
                else
                {
                    deathDatePainter = deathDate;
                    break;
                }
            }
        }

        Console.Write("Enter a nationality: ");
        string nationality = Console.ReadLine();

        Console.WriteLine("Choose a style by entering the corresponding number: \n");
        foreach (PaintingStyles paintingStyle in Enum.GetValues(typeof(PaintingStyles)))
        {
            Console.WriteLine($"{paintingStyle} - {(int)paintingStyle}");
        }

        PaintingStyles chosenStyle = (PaintingStyles)int.Parse(Console.ReadLine() ?? string.Empty);

        try
        {
            _mgr.AddPainter(painterName, birthDatePainter, deathDatePainter, nationality, chosenStyle);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Painter added successfully!");
            Console.ResetColor();
        }
        catch (ValidationException ex)
        {
            Console.WriteLine("Failed to add painter.");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }

    private void AddPaintings()
    {
        Museum museum = new Museum();
        Console.Write("Enter the painting title: ");
        string paintingTitle = Console.ReadLine();
        Console.Write("Enter the year of creation: ");
        int creationYear = int.TryParse(Console.ReadLine(), out int year) ? year : 0;
        Console.Write("Enter a price in USD (at least 1 million dollars): ");
        decimal price = Decimal.Parse(Console.ReadLine() ?? "0");
        Console.Write("Enter a museum name: ");
        museum.Name = Console.ReadLine();
        Console.Write("Enter the address of the museum: ");
        museum.Address = Console.ReadLine();
        Console.Write("Enter the website URL of the museum: ");
        museum.WebsiteUrl = Console.ReadLine();

        try
        {
            _mgr.AddPainting(paintingTitle, creationYear, price, museum);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Painting added successfully!");
            Console.ResetColor();
        }
        catch (ValidationException ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Failed to add painting.");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }

    private void AddPaintingToPainter()
    {
        Console.WriteLine("Which painter would you like to add a painting to?");
        foreach (Painter painter in _mgr.GetAllPainters())
        {
            Console.WriteLine($"[{painter.Id}] {painter.PainterName}");
        }

        Console.Write("Please enter a painter's ID: ");
        int painterId = int.Parse(Console.ReadLine() ?? string.Empty);

        while (_mgr.GetPainter(painterId) == null)
        {
            Console.Write("Please enter a valid painter ID: ");
            painterId = int.Parse(Console.ReadLine() ?? string.Empty);
        }


        Console.WriteLine("Which painting would you like to assign to this painter?");
        foreach (Painting painting in _mgr.GetAllPaintings())
        {
            Console.WriteLine($"[{painting.Id}] {painting.Title}");
        }

        Console.Write("Please enter the painting's ID: ");
        int paintingId = int.Parse(Console.ReadLine() ?? string.Empty);


        while (_mgr.GetPainting(paintingId) == null)
        {
            Console.Write("Please enter a valid painting ID: ");
            paintingId = int.Parse(Console.ReadLine() ?? string.Empty);
        }


        bool isSigned = false;
        string userInputSigned;

        Console.Write("Is this painting signed by the painter? (y/n): ");
        do
        {
            userInputSigned = Console.ReadLine()?.ToLower();

            if (userInputSigned == "y")
            {
                isSigned = true;
            }
            else if (userInputSigned == "n")
            {
                isSigned = false;
            }
            else
            {
                Console.WriteLine("Please enter a valid value (y/n).");
            }
        } while (userInputSigned != "y" && userInputSigned != "n");

        try
        {
            _mgr.AddPaintingToPainter(_mgr.GetPainter(painterId), _mgr.GetPainting(paintingId), isSigned);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Painting added successfully to the painter!\n");
            Console.ResetColor();
        }
        catch (DbUpdateException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("This painting is already assigned to this painter.\n");
            Console.ResetColor();
        }
        catch (InvalidOperationException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("This painting is already assigned to this painter.\n");
            Console.ResetColor();
        }
    }

    private void RemovePaintingFromPainter()
    {
        Console.WriteLine("Which painter would you like to remove a painting from?");
        foreach (Painter painter in _mgr.GetAllPainters())
        {
            Console.WriteLine($"[{painter.Id}] {painter.PainterName}");
        }

        Console.Write("Please enter a painter's ID: ");
        int painterId = int.Parse(Console.ReadLine() ?? string.Empty);

        while (_mgr.GetPainter(painterId) == null)
        {
            Console.Write("Please enter a valid painter ID: ");
            painterId = int.Parse(Console.ReadLine() ?? string.Empty);
        }

        Console.WriteLine("Which painting would you like to remove from this painter?");
        foreach (Painting painting in _mgr.GetPainterWithPaintings(painterId))
        {
            Console.WriteLine($"[{painting.Id}] {painting.Title}");
        }

        Console.Write("Please enter the painting's ID: ");
        int paintingId = int.Parse(Console.ReadLine() ?? string.Empty);

        while (_mgr.GetPainting(paintingId) == null)
        {
            Console.Write("Please enter a valid painting ID: ");
            paintingId = int.Parse(Console.ReadLine() ?? string.Empty);
        }

        try
        {
            _mgr.RemovePaintingFromPainter(_mgr.GetPainter(painterId), _mgr.GetPainting(paintingId));
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Painting successfully removed from the painter!\n");
            Console.ResetColor();
        }
        catch (InvalidOperationException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The entered painting ID was not correct.\n");
            Console.ResetColor();
        }
        catch (DbUpdateException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Something went wrong. Please try again.\n");
            Console.ResetColor();
        }
    }
}