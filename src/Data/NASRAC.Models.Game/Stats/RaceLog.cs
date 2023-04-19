using System.ComponentModel.DataAnnotations.Schema;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.RaceEntities;
using NASRAC.Models.Game.Stats.Abstractions;
using NASRAC.Services.Common.Services;

namespace NASRAC.Models.Game.Stats;

/// <summary>
/// Driver's Per-Lap Race Log
/// </summary>
public class RaceLog : BaseSessionStats
{
    public RaceLog()
    {
    }
    
    public RaceLog(Race race, Driver driver) : base(race, driver)
    {
        DNFOdds = RNG.RollDoubleTenths() * Math.Pow(driver.GetTrackRating(race.Track.Type) / 100, 2);
        IsRunning = true;
    }
    
    public double DriverRating { get; set; }
    public double DNFOdds { get; set; }
    public bool IsRunning { get; set; }
    public int CurrentPosition { get; set; }
    
    [NotMapped] private int AveragePositionSum { get; set; }
    
    [NotMapped] private int AverageRunningPositionSum { get; set; }
    
    public void CalculatePostLapStats(int currentLap, bool cautionLap = false)
    {
        if (!IsRunning) return;
        
        TotalLapCount += 1;
        
        AveragePositionSum += CurrentPosition;
        AveragePosition = AveragePositionSum / TotalLapCount;

        if (currentLap == TotalLapCount)
            AverageRunningPositionSum += CurrentPosition;
        AverageRunningPosition = AverageRunningPositionSum / TotalLapCount;

        if (cautionLap)
            CautionLapCount += 1;
        CautionLapPercentage = CautionLapCount / TotalLapCount * 100;

        if (CurrentPosition <= 15)
            Top15LapCount += 1;
        Top15LapPercentage = Top15LapCount / TotalLapCount * 100;

        if (CurrentPosition == 1)
            LapLedCount += 1;
        LapLedPercentage = LapLedCount / TotalLapCount * 100;
    }

    public void GenerateDNFOdds(double lowerBound, double upperbound)
    {
        DNFOdds += RNG.RollDoubleRange(lowerBound, upperbound);
    }
}