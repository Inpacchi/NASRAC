using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NASRAC.Persistence.Game.DAL;
using NASRAC.Services.Game.Services;

namespace NASRAC.Services.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), @"../../../../../API/NASRAC.API.Game"))
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
    
        var configuration = builder.Build();

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

        using var dataContext = new DataContext(optionsBuilder.Options, Path.Combine("..", "..", "..", "..", "..", "Data", "NASRAC.Persistence.Game", "Seed Data"));
        var raceWeekend = new RaceWeekend(dataContext);
        raceWeekend.Initialize();
    }
}