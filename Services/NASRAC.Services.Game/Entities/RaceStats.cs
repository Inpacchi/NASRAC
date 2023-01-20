using NASRAC.Models.Game.Entities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Services.Game.Entities;

public class RaceStats : RaceResults
{
    private readonly Random _rng = new Random();
    
    public double DriverRating { get; set; }
    public double DNFOdds { get; set; }
    public bool IsRunning { get; set; }

    public RaceStats(TrackType trackType)
    {
        DNFOdds = (_rng.NextDouble() / 10) * Math.Pow((Driver.GetTrackRating(trackType) / 100), 2);
    }
}