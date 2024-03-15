using Microsoft.EntityFrameworkCore;
using Schilderij.BL;
using Schilderij.DAL;
using Schilderij.DAL.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PainterDbContext>(optionsBuilder =>
    optionsBuilder.UseSqlite("Data Source=PainterDatabase_EFCodeFirst.db"));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IManager, Manager>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

InitializeDatabase(dropDatabase: true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void InitializeDatabase(bool dropDatabase)
{
    using var serviceScope = app.Services.CreateScope();
    PainterDbContext ctx = serviceScope.ServiceProvider.GetRequiredService<PainterDbContext>();

    if (dropDatabase)
    {
        ctx.Database.EnsureDeleted();
    }

    bool isCreated = ctx.CreateDatabase();
    
    if (isCreated)
    {
        DataSeeder.Seed(ctx);
    }
}