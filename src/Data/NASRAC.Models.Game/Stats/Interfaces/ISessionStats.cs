namespace NASRAC.Models.Game.Stats.Interfaces;

public interface IBaseSessionStats : IBaseStats
{
    /// <summary>
    /// Driver's start position
    /// </summary>
    public int StartPosition { get; set; }
    
    /// <summary>
    /// Driver's finish position
    /// </summary>
    public int FinishPosition { get; set; }
    
    /// <summary>
    /// Lowest position the driver dropped to
    /// </summary>
    public int LowestPosition { get; set; }
    
    /// <summary>
    /// Highest position the driver rose to
    /// </summary>
    public int HighestPosition { get; set; }
    
    /// <summary>
    /// Driver's overall average position
    /// </summary>
    public int AveragePosition { get; set; }
    
    /// <summary>
    /// Driver's average position while on the lead lap
    /// </summary>
    public int AverageRunningPosition { get; set; }

    /// <summary>
    /// Driver's position at the time they DNF'd (if they did)
    /// </summary>
    public int DNFPosition { get; set; }
    
    /// <summary>
    /// How many laps the driver was in the top 15 standings
    /// </summary>
    public int Top15LapCount { get; set; }
    
    /// <summary>
    /// Percentage of laps the driver was in the top 15 standings
    /// </summary>
    public int Top15LapPercentage { get; set; }
    
    /// <summary>
    /// How many laps the driver led
    /// </summary>
    public int LapLedCount { get; set; }
    
    /// <summary>
    /// Percentage of laps the driver led
    /// </summary>
    public int LapLedPercentage { get; set; }

    /// <summary>
    /// How many laps the driver spent under caution
    /// </summary>
    public int CautionLapCount { get; set; }
    
    /// <summary>
    /// Percentage of laps the driver spent under caution
    /// </summary>
    public int CautionLapPercentage { get; set; }

    /// <summary>
    /// How many cautions the driver caused
    /// </summary>
    public int CautionsCaused { get; set; }

    /// <summary>
    /// Driver's total lap count
    /// </summary>
    public int TotalLapCount { get; set; }
}