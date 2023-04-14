﻿using NASRAC.Models.Game.DriverEntities;
using NASRAC.Services.Common.Services;

namespace NASRAC.Models.Game.RaceEntities;

/// <summary>
/// Driver's Per-Lap Race Log
/// </summary>
public class RaceLog : RaceResults
{
    public RaceLog() : base()
    {
    }
    
    public RaceLog(Race race, Driver driver) : base(race, driver)
    {
        DNFOdds = RNG.RollDoubleTenths() * Math.Pow((driver.GetTrackRating(race.Track.Type) / 100), 2);
    }
    
    public double DriverRating { get; set; }
    public double DNFOdds { get; set; }
    public bool IsRunning { get; set; }
    public int CurrentPosition { get; set; }

    public void UpdateLap1Positions(int position)
    {
        CurrentPosition = position;
        StartPosition = position;
        LowestPosition = position;
        HighestPosition = position;
    }
    
    public void CalculatePostLapStats(int currentLap, bool cautionLap = false)
    {
        if (!IsRunning) return;
        
        AverageRacePosition += CurrentPosition;
        TotalLapCount += 1;

        if (currentLap == TotalLapCount)
        {
            AverageRunningPosition += CurrentPosition;
        }

        if (cautionLap)
        {
            CautionLapCount += 1;
        }

        if (CurrentPosition <= 15)
        {
            Top15LapCount += 1;
        }

        if (CurrentPosition == 1)
        {
            LapLedCount += 1;
            HighestPosition = 1;
        }
        else
        {
            if (CurrentPosition > LowestPosition)
            {
                LowestPosition = CurrentPosition;
            } else if (CurrentPosition < HighestPosition)
            {
                HighestPosition = CurrentPosition;
            }
        }
    }
}