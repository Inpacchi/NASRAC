using System.ComponentModel.DataAnnotations.Schema;
using NASRAC.Core.Entities.Game.Base;
using NASRAC.Core.Services;

namespace NASRAC.Core.Entities.Game;

/// <summary>
/// Driver's Per-Lap Race Log
/// </summary>
public class RaceLog : SessionStatsBase
{
    public RaceLog()
    {
    }

    public RaceLog(Race race, Driver driver) : base(race.Id, driver.Id)
    {
        DnfOdds = RandomService.RollDoubleTenths() * Math.Pow(driver.GetTrackRating(race.Track.Type) / 100, 2);
    }
    
    public double DriverRating { get; set; }
    public double DnfOdds { get; set; }
    public bool IsRunning { get; set; } = true;
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

    public void GenerateDnfOdds(double lowerBound, double upperbound)
    {
        DnfOdds += RandomService.RollDoubleRange(lowerBound, upperbound);
    }
}