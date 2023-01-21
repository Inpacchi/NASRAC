using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Models.Game.JoinEntities;
using NASRAC.Models.Game.TeamEntities;

namespace NASRAC.Persistence.Game.DAL;

public class Seed
{
    private readonly ModelBuilder _modelBuilder;
    private readonly JsonSerializerOptions _options;
    
    private const string SeedPath = "..\\..\\Data\\NASRAC.Persistence.Game\\Seed Data\\";

    public Seed(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
        
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        _options.Converters.Add(new JsonStringEnumConverter());
    }

    public void Initialize()
    {
        SeedData<Track>("Track.json");
        SeedData<Series>("Series.json");
        SeedData<Race>("Race.json");
        SeedData<Schedule>("Schedule.json");
        SeedData<Driver>("Driver.json");
        SeedData<Manufacturer>("Manufacturer.json");
        SeedData<Team>("Team.json");
        SeedData<TeamManufacturers>("TeamManufacturers.json");
    }

    private void SeedData<T>(string filename) where T : class
    {
        var json = File.ReadAllText(SeedPath + filename);

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
}