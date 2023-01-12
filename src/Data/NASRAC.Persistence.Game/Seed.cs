using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Models.Game.TeamEntities;
using NASRAC.Persistence.Game.DAL;

namespace NASRAC.Persistence.Game;

public class Seed
{
    private const string _seedPath = "..\\..\\Data\\NASRAC.Persistence.Game\\Seeds\\";

    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task SeedDevData(DataContext context)
    {
        _options.Converters.Add(new JsonStringEnumConverter());
        await SeedRaces(context);
        await SeedDrivers(context);
    }
    
    public static async Task SeedProductionData(DataContext context)
    {
        _options.Converters.Add(new JsonStringEnumConverter());
        await SeedManufacturers(context);
        await SeedTracks(context);
    }
    
    private static async Task SeedDrivers(DataContext context)
    {
        if (await context.Driver.AnyAsync()) return;
        var driverData = await File.ReadAllTextAsync(_seedPath + "Drivers.json");
        var drivers = JsonSerializer.Deserialize<List<Driver>>(driverData, _options);
        context.AddRange(drivers);
        await context.SaveChangesAsync();
    }
    
    private static async Task SeedManufacturers(DataContext context)
    {
        if (await context.Manufacturer.AnyAsync()) return;
        var manufacturerData = await File.ReadAllTextAsync(_seedPath + "ProductionData\\Manufacturers.json");
        var manufacturers = JsonSerializer.Deserialize<List<Manufacturer>>(manufacturerData, _options);
        context.AddRange(manufacturers);
        await context.SaveChangesAsync();
    }
    
    private static async Task SeedRaces(DataContext context)
    {
        if (await context.Race.AnyAsync()) return;
        var raceData = await File.ReadAllTextAsync(_seedPath + "Races.json");
        var races = JsonSerializer.Deserialize<List<Race>>(raceData, _options);
        context.AddRange(races);
        await context.SaveChangesAsync();
    }
    
    private static async Task SeedTracks(DataContext context)
    {
        if (await context.Track.AnyAsync()) return;
        var trackData = await File.ReadAllTextAsync(_seedPath + "ProductionData\\Tracks.json");
        var tracks = JsonSerializer.Deserialize<List<Track>>(trackData, _options);
        context.AddRange(tracks);
        await context.SaveChangesAsync();
    }
}