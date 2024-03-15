using Microsoft.EntityFrameworkCore;
using Schilderij.BL;
using Schilderij.DAL;
using Schilderij.DAL.EF;
using Schilderij.UI.CA;

DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<PainterDbContext>();
optionsBuilder.UseSqlite(@"Data Source=..\..\..\..\PainterDatabase.db");
PainterDbContext ctx = new PainterDbContext(optionsBuilder.Options);
IRepository repo = new Repository(ctx);
IManager mgr = new Manager(repo);

bool isCreatedNow = ctx.CreateDatabase();
if (isCreatedNow)
{
    DataSeeder.Seed(ctx);
}

ConsoleUi consoleUi = new ConsoleUi(mgr);
consoleUi.Run();