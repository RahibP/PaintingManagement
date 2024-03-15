using Schilderij.BL.Domain;

namespace Schilderij.DAL.EF;

public static class DataSeeder
{
    public static void Seed(PainterDbContext dbContext)
    {
        #region Museums

        Museum louvre = new Museum
        {
            Name = "Louvre",
            Address = "Musée du Louvre, 75058 Paris, France",
            WebsiteUrl = "https://www.louvre.fr/en"
        };

        Museum museumModernArt = new Museum
        {
            Name = "Museum of Modern Art",
            Address = "11 West 53rd Street Manhattan, New York City, USA",
            WebsiteUrl = "https://www.moma.org/"
        };

        Museum laCountyMuseum = new Museum
        {
            Name = "Los Angeles County Museum of Art\n",
            Address = "5905 Wilshire Blvd, Los Angeles, CA 90036, USA",
            WebsiteUrl = "https://www.lacma.org/"
        };

        Museum krefeld = new Museum
        {
            Name = "Kunstmuseen Krefeld",
            Address = "Joseph-Beuys-Platz 1, 47798 Krefeld, Germany",
            WebsiteUrl = "https://kunstmuseenkrefeld.de/de"
        };

        Museum osloMuseum = new Museum
        {
            Name = "National Museum of Oslo",
            Address = "Tøyengata 53, 0578 Oslo, Norway",
            WebsiteUrl = "https://www.nasjonalmuseet.no/"
        };

        #endregion

        #region Painters

        Painter daVinci = new Painter
        {
            PainterName = "Leonardo da Vinci",
            BirthDate = new DateTime(1452, 4, 15),
            DeathDate = new DateTime(1519, 5, 2),
            Nationality = "Italian",
            PaintingStyle = PaintingStyles.Renaissance
        };

        Painter vanGogh = new Painter
        {
            PainterName = "Vincent Van Gogh",
            BirthDate = new DateTime(1853, 3, 30),
            DeathDate = new DateTime(1890, 7, 29),
            Nationality = "Dutch",
            PaintingStyle = PaintingStyles.Postimpressionism
        };

        Painter magritte = new Painter
        {
            PainterName = "René Magritte",
            BirthDate = new DateTime(1898, 11, 21),
            DeathDate = new DateTime(1967, 8, 15),
            Nationality = "Belgian",
            PaintingStyle = PaintingStyles.Surrealism
        };


        Painter richter = new Painter
        {
            PainterName = "Gerhard Richter",
            BirthDate = new DateTime(1932, 2, 9),
            DeathDate = null,
            Nationality = "German",
            PaintingStyle = PaintingStyles.Conceptual
        };

        Painter munch = new Painter
        {
            PainterName = "Edvard Munch",
            BirthDate = new DateTime(1863, 12, 12),
            DeathDate = new DateTime(1944, 1, 23),
            Nationality = "Norwegian",
            PaintingStyle = PaintingStyles.Expressionism
        };

        Painter rousseau = new Painter
        {
            PainterName = "Henri Rousseau",
            BirthDate = new DateTime(1844, 5, 21),
            DeathDate = new DateTime(1910, 9, 2),
            Nationality = "French",
            PaintingStyle = PaintingStyles.ModernArt
        };

        Painter delacroix = new Painter
        {
            PainterName = "Eugène Delacroix",
            BirthDate = new DateTime(1798, 4, 26),
            DeathDate = new DateTime(1863, 8, 13),
            Nationality = "French",
            PaintingStyle = PaintingStyles.Romanticism
        };

        Painter deClerck = new Painter
        {
            PainterName = "Hendrick de Clerck",
            BirthDate = new DateTime(1560, 8, 25),
            DeathDate = new DateTime(1630, 8, 27),
            Nationality = "Belgian",
            PaintingStyle = PaintingStyles.Mannerism
        };

        Painter vanAlsloot = new Painter
        {
            PainterName = "Denis van Alsloot",
            BirthDate = new DateTime(1570, 1, 1),
            DeathDate = new DateTime(1626, 1, 1),
            Nationality = "Belgian",
            PaintingStyle = PaintingStyles.Mannerism
        };

        #endregion

        #region Paintings

        Painting monaLisa = new Painting
        {
            Title = "Mona Lisa",
            CreationYear = 1519,
            Price = 860000000,
            Museum = louvre
        };


        Painting starryNight = new Painting
        {
            Title = "The Starry Night",
            CreationYear = 1889,
            Price = 100000000,
            Museum = museumModernArt
        };

        Painting treacheryImages = new Painting
        {
            Title = "The Treachery of Images",
            CreationYear = 1929,
            Price = 60000000,
            Museum = laCountyMuseum
        };

        Painting colours1024 = new Painting
        {
            Title = "1024 Colours",
            CreationYear = 1973,
            Price = 40000000,
            Museum = krefeld
        };

        Painting colours4096 = new Painting
        {
            Title = "4096 Colours",
            CreationYear = 1974,
            Price = 45000000,
            Museum = krefeld
        };

        Painting theScream = new Painting
        {
            Title = "The Scream",
            CreationYear = 1893,
            Price = 120000000,
            Museum = osloMuseum
        };

        Painting sleepingGypsy = new Painting
        {
            Title = "The Sleeping Gypsy",
            CreationYear = 1897,
            Price = 153000000,
            Museum = museumModernArt
        };

        Painting lionHunt = new Painting
        {
            Title = "Lion Hunt",
            CreationYear = 1855,
            Price = 23000000,
            Museum = louvre
        };

        Painting theLovers = new Painting
        {
            Title = "The Lovers",
            CreationYear = 1928,
            Price = 50000000,
            Museum = museumModernArt
        };

        Painting flowerHead = new Painting
        {
            Title = "Flower with Head",
            CreationYear = 1944,
            Price = 3100000,
            Museum = laCountyMuseum
        };
        
        Painting paradise = new Painting
        {
            Title = "Paradise",
            CreationYear = 1607,
            Price = 5400000,
            Museum = osloMuseum
        };

        #endregion
        
        louvre.Paintings.Add(monaLisa);
        louvre.Paintings.Add(lionHunt);
        museumModernArt.Paintings.Add(starryNight);
        museumModernArt.Paintings.Add(sleepingGypsy);
        museumModernArt.Paintings.Add(theLovers);
        laCountyMuseum.Paintings.Add(treacheryImages);
        laCountyMuseum.Paintings.Add(flowerHead);
        krefeld.Paintings.Add(colours1024);
        krefeld.Paintings.Add(colours4096);
        osloMuseum.Paintings.Add(theScream);
        osloMuseum.Paintings.Add(paradise);
        
        #region PainterPaintings

        PainterPainting daVinciMl = new PainterPainting
        {
            IsSigned = true,
            Painter = daVinci,
            Painting = monaLisa,
        };

        PainterPainting delacroixLiberty = new PainterPainting
        {
            IsSigned = true,
            Painter = delacroix,
            Painting = lionHunt,
        };

        PainterPainting vanGoghStarryNight = new PainterPainting
        {
            IsSigned = true,
            Painter = vanGogh,
            Painting = starryNight,
        };

        PainterPainting rousseauSleepingGypsy = new PainterPainting
        {
            IsSigned = true,
            Painter = rousseau,
            Painting = sleepingGypsy
        };

        PainterPainting magritteLovers = new PainterPainting
        {
            IsSigned = true,
            Painter = magritte,
            Painting = theLovers
        };

        PainterPainting magritteTreacheryImages = new PainterPainting
        {
            IsSigned = true,
            Painter = magritte,
            Painting = treacheryImages
        };

        PainterPainting magritteFlowerHead = new PainterPainting
        {
            IsSigned = false,
            Painter = magritte,
            Painting = flowerHead
        };

        PainterPainting richterColours1024 = new PainterPainting
        {
            IsSigned = false,
            Painter = richter,
            Painting = colours1024
        };

        PainterPainting richterColours4096 = new PainterPainting
        {
            IsSigned = false,
            Painter = richter,
            Painting = colours4096
        };

        PainterPainting munchScream = new PainterPainting
        {
            IsSigned = false,
            Painter = munch,
            Painting = theScream
        };
        
        PainterPainting deClerckParadise = new PainterPainting
        {
            IsSigned = false,
            Painter = deClerck,
            Painting = paradise
        };
        
        PainterPainting vanAlslootParadise = new PainterPainting
        {
            IsSigned = false,
            Painter = vanAlsloot,
            Painting = paradise
        };

        #endregion
        
        daVinci.Paintings = new List<PainterPainting>() { daVinciMl };
        monaLisa.Painters.Add(daVinciMl);
        
        delacroix.Paintings = new List<PainterPainting>() { delacroixLiberty };
        lionHunt.Painters.Add(delacroixLiberty);

        vanGogh.Paintings = new List<PainterPainting>() { vanGoghStarryNight };
        starryNight.Painters.Add(vanGoghStarryNight);

        rousseau.Paintings = new List<PainterPainting>() { rousseauSleepingGypsy };
        sleepingGypsy.Painters.Add(rousseauSleepingGypsy);

        magritte.Paintings = new List<PainterPainting>()
            { magritteLovers, magritteTreacheryImages, magritteFlowerHead };
        theLovers.Painters.Add(magritteLovers);
        treacheryImages.Painters.Add(magritteTreacheryImages);
        flowerHead.Painters.Add(magritteFlowerHead);

        richter.Paintings = new List<PainterPainting>() { richterColours1024, richterColours4096 };
        colours1024.Painters.Add(richterColours1024);
        colours4096.Painters.Add(richterColours4096);

        munch.Paintings = new List<PainterPainting>() { munchScream };
        theScream.Painters.Add(munchScream);
        
        deClerck.Paintings = new List<PainterPainting>() { deClerckParadise };
        paradise.Painters.Add(deClerckParadise);
        
        vanAlsloot.Paintings = new List<PainterPainting>() { vanAlslootParadise };
        paradise.Painters.Add(vanAlslootParadise);

        dbContext.Museums.Add(louvre);
        dbContext.Museums.Add(museumModernArt);
        dbContext.Museums.Add(laCountyMuseum);
        dbContext.Museums.Add(krefeld);
        dbContext.Museums.Add(osloMuseum);

        dbContext.Painters.Add(daVinci);
        dbContext.Painters.Add(vanGogh);
        dbContext.Painters.Add(magritte);
        dbContext.Painters.Add(richter);
        dbContext.Painters.Add(munch);
        dbContext.Painters.Add(rousseau);
        dbContext.Painters.Add(delacroix);
        dbContext.Painters.Add(deClerck);
        dbContext.Painters.Add(vanAlsloot);

        dbContext.Paintings.Add(monaLisa);
        dbContext.Paintings.Add(starryNight);
        dbContext.Paintings.Add(treacheryImages);
        dbContext.Paintings.Add(colours1024);
        dbContext.Paintings.Add(colours4096);
        dbContext.Paintings.Add(theScream);
        dbContext.Paintings.Add(sleepingGypsy);
        dbContext.Paintings.Add(lionHunt);
        dbContext.Paintings.Add(theLovers);
        dbContext.Paintings.Add(flowerHead);
        dbContext.Paintings.Add(paradise);

        dbContext.PainterPaintings.Add(daVinciMl);
        dbContext.PainterPaintings.Add(delacroixLiberty);
        dbContext.PainterPaintings.Add(vanGoghStarryNight);
        dbContext.PainterPaintings.Add(rousseauSleepingGypsy);
        dbContext.PainterPaintings.Add(magritteLovers);
        dbContext.PainterPaintings.Add(magritteTreacheryImages);
        dbContext.PainterPaintings.Add(magritteFlowerHead);
        dbContext.PainterPaintings.Add(richterColours1024);
        dbContext.PainterPaintings.Add(richterColours4096);
        dbContext.PainterPaintings.Add(munchScream);
        dbContext.PainterPaintings.Add(deClerckParadise);
        dbContext.PainterPaintings.Add(vanAlslootParadise);

        dbContext.SaveChanges();
        dbContext.ChangeTracker.Clear();
    }
}