﻿using NASRAC.Core.Models.Game.DriverEntities;
using NASRAC.Core.Models.Game.RaceEntities;
using NASRAC.Core.Models.Game.Stats.Interfaces;

namespace NASRAC.Core.Models.Game.Stats.Abstractions;

/// <summary>
/// Driver's Session Results (used for Stages and End of Race)
/// </summary>
public abstract class BaseSessionStats : BaseStats, IBaseSessionStats
{
    protected BaseSessionStats()
    {
    }
    
    protected BaseSessionStats(Race race, Driver driver) : base(race, driver)
    {
    }
    
    /// <summary>
    /// Driver's overall average position
    /// </summary>
    public double AveragePosition { get; set; }
    
    /// <summary>
    /// Driver's average position while on the lead lap
    /// </summary>
    public double AverageRunningPosition { get; set; }
    
    /// <summary>
    /// How many laps the driver was in the top 15 standings
    /// </summary>
    public int Top15LapCount { get; set; }
    
    /// <summary>
    /// Percentage of laps the driver was in the top 15 standings
    /// </summary>
    public double Top15LapPercentage { get; set; }
    
    /// <summary>
    /// How many laps the driver led
    /// </summary>
    public int LapLedCount { get; set; }
    
    /// <summary>
    /// Percentage of laps the driver led
    /// </summary>
    public double LapLedPercentage { get; set; }

    /// <summary>
    /// How many laps the driver spent under caution
    /// </summary>
    public int CautionLapCount { get; set; }
    
    /// <summary>
    /// Percentage of laps the driver spent under caution
    /// </summary>
    public double CautionLapPercentage { get; set; }

    /// <summary>
    /// How many cautions the driver caused
    /// </summary>
    public int CautionsCaused { get; set; }

    /// <summary>
    /// Driver's total lap count
    /// </summary>
    public int TotalLapCount { get; set; }
}