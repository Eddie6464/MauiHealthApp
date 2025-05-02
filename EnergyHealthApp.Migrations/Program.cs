using Microsoft.EntityFrameworkCore;
using EnergyHealthApp.Data;

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite("Data Source=app.db")
    .Options;

using var context = new AppDbContext(options);
context.Database.Migrate();

