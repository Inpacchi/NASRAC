using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

/// <summary>
/// Driver's Race Results & Stats
/// </summary>
public class RaceResults : BaseResults
{
    public RaceResults()
    {
        Initialize();
    }
    
    public RaceResults(Race race, Driver driver) : base(race, driver)
    {
        Initialize();
    }

    protected sealed override void Initialize()
    {
        base.Initialize();
        
        StartPosition = null;
        FinishPosition = null;
        LowestPosition = null;
        HighestPosition = null;
        AverageRacePosition= null;
        AverageRunningPosition = null;
        Stage1Position = null;
        Stage2Position = null;
        DNFPosition = null;
        Top15LapCount = null;
        Top15LapPercentage = null;
        LapLedCount = null;
        LapLedPercentage = null;
        CautionLapCount = null;
        CautionLapPercentage = null;
        CautionsCaused = null;
        TotalLapCount = null;
    }

    /// <summary>
    /// Driver's start position for the race
    /// </summary>
    public int? StartPosition { get; set; }
    
    /// <summary>
    /// Driver's end position for the race
    /// </summary>
    public int? FinishPosition { get; set; }
    
    /// <summary>
    /// Lowest position the driver dropped to during the race
    /// </summary>
    public int? LowestPosition { get; set; }
    
    /// <summary>
    /// Highest position the driver rose to during the race
    /// </summary>
    public int? HighestPosition { get; set; }
    
    /// <summary>
    /// Driver's overall average race position
    /// </summary>
    public int? AverageRacePosition { get; set; }
    
    /// <summary>
    /// Driver's average race position while on the lead lap
    /// </summary>
    public int? AverageRunningPosition { get; set; }

    /// <summary>
    /// Driver's position at the end of stage 1
    /// </summary>
    public int? Stage1Position { get; set; }

    /// <summary>
    /// Driver's position at the end of stage 2
    /// </summary>
    public int? Stage2Position { get; set; }

    /// <summary>
    /// Driver's position (if) at the time they DNF'd
    /// </summary>
    public int? DNFPosition { get; set; }
    
    /// <summary>
    /// How many laps the driver was in the top 15 standings
    /// </summary>
    public int? Top15LapCount { get; set; }
    
    /// <summary>
    /// Percentage of laps the driver was in the top 15 standings
    /// </summary>
    public int? Top15LapPercentage { get; set; }
    
    /// <summary>
    /// How many laps the driver led
    /// </summary>
    public int? LapLedCount { get; set; }
    
    /// <summary>
    /// Percentage of laps the driver led
    /// </summary>
    public int? LapLedPercentage { get; set; }

    /// <summary>
    /// How many laps the driver spent under caution
    /// </summary>
    public int? CautionLapCount { get; set; }
    
    /// <summary>
    /// Percentage of laps the driver spent under caution
    /// </summary>
    public int? CautionLapPercentage { get; set; }

    /// <summary>
    /// How many cautions the driver caused
    /// </summary>
    public int? CautionsCaused { get; set; }

    /// <summary>
    /// Driver's total lap count
    /// </summary>
    public int? TotalLapCount { get; set; }
}