using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Schilderij.BL.Domain;

namespace Schilderij.DAL.EF;

public class PainterDbContext : DbContext
{
    public DbSet<Painter> Painters { get; set; }
    public DbSet<Painting> Paintings { get; set; }
    public DbSet<Museum> Museums { get; set; }
    
    public DbSet<PainterPainting> PainterPaintings { get; set; }


    public PainterDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlite(@"Data Source=PainterDatabase.db");

        optionsBuilder.LogTo(logMessage => Debug.WriteLine(logMessage), LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PainterPainting>()
            .HasOne(painterPainting => painterPainting.Painter)
            .WithMany(painting => painting.Paintings)
            .HasForeignKey("FK_PainterId")
            .IsRequired();
        
        modelBuilder.Entity<PainterPainting>()
            .HasOne(painterPainting => painterPainting.Painting)
            .WithMany(painter => painter.Painters)
            .HasForeignKey("FK_PaintingId")
            .IsRequired();
        
        modelBuilder.Entity<Painting>()
            .HasOne(painting => painting.Museum)
            .WithMany(museum => museum.Paintings)
            .IsRequired();
        
        modelBuilder.Entity<Museum>()
            .HasMany(museum => museum.Paintings)
            .WithOne(painting => painting.Museum)
            .IsRequired();
        
        modelBuilder.Entity<PainterPainting>()
            .HasKey("FK_PainterId", "FK_PaintingId");
        
        
        modelBuilder.Entity<PainterPainting>().Property<bool>("IsSigned").IsRequired(); 
    }

    public bool CreateDatabase(bool dropDatabase = false)
    {
        if (dropDatabase)
        {
            Database.EnsureDeleted(); // drop database if needed
        }

        bool isCreatedNow = Database.EnsureCreated(); // create database
        return isCreatedNow;
    }
}