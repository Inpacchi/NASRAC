using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Persistence.Game.DAL;

namespace NASRAC.Persistence.Game;

public class Seed
{
    private const string SeedPath = "..\\..\\Data\\NASRAC.Persistence.Game\\Seeds\\";

    private readonly JsonSerializerOptions _options;
    public Seed()
    {
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        _options.Converters.Add(new JsonStringEnumConverter());
    }

    #region Development Seeds
    public List<Driver> SeedDrivers()
    {
        var driverData = File.ReadAllText(SeedPath + "Drivers.json");
        
        return JsonSerializer.Deserialize<List<Driver>>(driverData, _options) ?? throw new ArgumentNullException();
    }
    
    public List<Schedule> SeedSchedule()
    {
        var scheduleData = File.ReadAllText(SeedPath + "Schedule.json");
        
        return JsonSerializer.Deserialize<List<Schedule>>(scheduleData, _options) ?? throw new ArgumentNullException();
    }
    #endregion

    #region Production Seeds
    public async Task SeedProductionData(DataContext context)
    {
        _options.Converters.Add(new JsonStringEnumConverter());
        await SeedManufacturers(context);
        await SeedTracks(context);
    }
    
    private async Task SeedManufacturers(DataContext context)
    {
        if (await context.Manufacturer.AnyAsync()) return;
        var manufacturerData = await File.ReadAllTextAsync(SeedPath + "ProductionData\\Manufacturers.json");
        var manufacturers = JsonSerializer.Deserialize<List<Manufacturer>>(manufacturerData, _options);
        context.AddRange(manufacturers);
        await context.SaveChangesAsync();
    }
    
    private async Task SeedTracks(DataContext context)
    {
        if (await context.Track.AnyAsync()) return;
        var trackData = await File.ReadAllTextAsync(SeedPath + "ProductionData\\Tracks.json");
        var tracks = JsonSerializer.Deserialize<List<Track>>(trackData, _options);
        context.AddRange(tracks);
        await context.SaveChangesAsync();
    }
    #endregion
}