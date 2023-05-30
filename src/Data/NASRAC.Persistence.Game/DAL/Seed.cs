using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Models.Game.RaceEntities;
using NASRAC.Models.Game.TeamEntities;
using NASRAC.Services.Common.Services;

namespace NASRAC.Persistence.Game.DAL;

public class Seed
{
    private readonly ModelBuilder _modelBuilder;
    private readonly JsonSerializerOptions _options;

    private readonly string _seedPath;

    public Seed(ModelBuilder modelBuilder, string seedPath)
    {
        _modelBuilder = modelBuilder;
        _seedPath = seedPath;
        
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        _options.Converters.Add(new JsonStringEnumConverter());
    }

    public void Initialize()
    {
        List<Team> teams = new();
        
        for (var i = 1; i <= 30; i++)
        {
            var team = Team.GenerateRandomTeam(i);
            _modelBuilder.Entity<Team>().HasData(team);
            teams.Add(team);
        }
        
        for (var i = 1; i <= 40; i++)
        {
            var driver = Driver.GenerateRandomDriver(i);
            _modelBuilder.Entity<Driver>().HasData(driver);
            AssignDriverToTeam(driver, teams);
        }
        
        SeedData<Track>("Track.json");
        SeedData<Series>("Series.json");
        SeedData<Race>("Race.json");
        SeedData<Schedule>("Schedule.json");
        SeedData<Manufacturer>("Manufacturer.json");
    }

    private void SeedData<T>(string filename) where T : class
    {
        var json = File.ReadAllText(Path.Combine(_seedPath, filename));

        var data = JsonSerializer.Deserialize<List<T>>(json, _options);

        if (data != null)
        {
            foreach (var d in data)
            {
                _modelBuilder.Entity<T>().HasData(d);
            }
        }
        else
        {
            throw new NullReferenceException($"Filename {filename} returned an error - please double check the filename, location and contents.");
        }
    }


    private void AssignDriverToTeam(Driver driver, List<Team> teams)
    {
        var team = teams[RNG.RollInt(teams.Select(t => t.Drivers.Count < 2).Count())];
        driver.TeamId = team.Id;
    }
}