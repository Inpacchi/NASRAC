using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Services.Common.Enums;
using NASRAC.Services.Common.Services;

namespace NASRAC.Services.Game.Entities;

public class RaceStats : RaceResults
{
    public RaceStats(Race race, Driver driver) : base(race, driver)
    {
        DNFOdds = RNG.RollDoubleTenths() * Math.Pow((Driver.GetTrackRating(race.Track.Type) / 100), 2);
    }
    
    public double DriverRating { get; set; }
    public double DNFOdds { get; set; }
    public bool IsRunning { get; set; }
    public int CurrentPosition { get; set; }
}