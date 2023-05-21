using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Models.Game.RaceEntities;

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
        for (var i = 1; i <= 40; i++)
            _modelBuilder.Entity<Driver>().HasData(Driver.GenerateRandomDriver(i));
        
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
}