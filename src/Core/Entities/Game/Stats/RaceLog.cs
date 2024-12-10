using System.ComponentModel.DataAnnotations.Schema;
using NASRAC.Core.Services;
using NASRAC.Core.Models.Game.DriverEntities;
using NASRAC.Core.Models.Game.RaceEntities;
using NASRAC.Core.Models.Game.Stats.Abstractions;

namespace NASRAC.Core.Models.Game.Stats;

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
        DNFOdds = RandomService.RollDoubleTenths() * Math.Pow(driver.GetTrackRating(race.Track.Type) / 100, 2);
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
        AveragePosition = Math.Round((double)AveragePositionSum / TotalLapCount, 2);

        if (currentLap == TotalLapCount)
            AverageRunningPositionSum += CurrentPosition;
        AverageRunningPosition = Math.Round((double)AverageRunningPositionSum / TotalLapCount, 2);

        if (cautionLap)
            CautionLapCount += 1;
        CautionLapPercentage = Math.Round((double)CautionLapCount / TotalLapCount * 100.0, 2);

        if (CurrentPosition <= 15)
            Top15LapCount += 1;
        Top15LapPercentage = Math.Round((double)Top15LapCount / TotalLapCount * 100.0, 2);

        if (CurrentPosition == 1)
            LapLedCount += 1;
        LapLedPercentage = Math.Round((double)LapLedCount / TotalLapCount * 100.0, 2);
    }

    public void GenerateDNFOdds(double lowerBound, double upperbound)
    {
        DNFOdds += RandomService.RollDoubleRange(lowerBound, upperbound);
    }
}