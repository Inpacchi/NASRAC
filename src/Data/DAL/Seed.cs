using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Models.Game.RaceEntities;
using NASRAC.Models.Game.TeamEntities;
using NASRAC.Services.Common.Services;

namespace Data.DAL;

public class Seed
{
    private readonly DbContext _dbContext;
    private readonly JsonSerializerOptions _options;
    private readonly string _seedPath;

    public Seed(DbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _seedPath = configuration.GetSection("SeedDataPath").Value;
        
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        _options.Converters.Add(new JsonStringEnumConverter());
    }

    public void Initialize()
    {
        List<Team> teams = [];
        
        for (var i = 1; i <= 30; i++)
        {
            var team = Team.GenerateRandomTeam(i);
            _dbContext.Set<Team>().Add(team);
            teams.Add(team);
        }
        _dbContext.SaveChanges();
        
        for (var i = 1; i <= 40; i++)
        {
            var driver = Driver.GenerateRandomDriver(i);
            _dbContext.Set<Driver>().Add(driver);
            AssignDriverToTeam(driver, teams);
        }
        _dbContext.SaveChanges();
        
        SeedData<Manufacturer>("Manufacturer.json");
        SeedData<Track>("Track.json");
        SeedData<Series>("Series.json");
        SeedData<Race>("Race.json");
        SeedData<Schedule>("Schedule.json");
    }

    public async Task InitializeAsync()
    {
        List<Team> teams = [];
        
        for (var i = 1; i <= 30; i++)
        {
            var team = Team.GenerateRandomTeam(i);
            _dbContext.Set<Team>().Add(team);
            teams.Add(team);
        }
        await _dbContext.SaveChangesAsync();
        
        for (var i = 1; i <= 40; i++)
        {
            var driver = Driver.GenerateRandomDriver(i);
            _dbContext.Set<Driver>().Add(driver);
            AssignDriverToTeam(driver, teams);
        }
        await _dbContext.SaveChangesAsync();
        
        await SeedDataAsync<Manufacturer>("Manufacturer.json");
        await SeedDataAsync<Track>("Track.json");
        await SeedDataAsync<Series>("Series.json");
        await SeedDataAsync<Race>("Race.json");
        await SeedDataAsync<Schedule>("Schedule.json");
    }

    private void SeedData<T>(string filename) where T : class
    {
        var json = File.ReadAllText(Path.Combine(_seedPath, filename));

        var data = JsonSerializer.Deserialize<List<T>>(json, _options);

        if (data != null)
        {
            foreach (var d in data)
            {
                _dbContext.Set<T>().Add(d);
            }
            _dbContext.SaveChanges();
        }
        else
        {
            throw new NullReferenceException($"Filename {filename} returned an error - please double check the filename, location and contents.");
        }
    }

    private async Task SeedDataAsync<T>(string filename) where T : class
    {
        var json = await File.ReadAllTextAsync(Path.Combine(_seedPath, filename));

        var data = JsonSerializer.Deserialize<List<T>>(json, _options);

        if (data != null)
        {
            foreach (var d in data)
            {
                _dbContext.Set<T>().Add(d);
            }
            await _dbContext.SaveChangesAsync();
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