using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.RaceEntities;
using NASRAC.Models.Game.Stats.Abstractions;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Stats;

/// <summary>
/// Driver's Final Race Results
/// </summary>
public class SessionResults : BaseSessionStats
{
    public SessionResults()
    {
    }
    
    public SessionResults(Race race, Driver driver) : base(race, driver)
    {
    }
    
    /// <summary>
    /// Driver's start position for the session
    /// </summary>
    public int StartPosition { get; set; }
    
    /// <summary>
    /// Driver's finish position for the session
    /// </summary>
    public int FinishPosition { get; set; }
    
    /// <summary>
    /// Lowest position the driver dropped to during the session
    /// </summary>
    public int LowestPosition { get; set; }
    
    /// <summary>
    /// Highest position the driver rose to during the session
    /// </summary>
    public int HighestPosition { get; set; }

    /// <summary>
    /// Driver's position (if) at the time they DNF'd
    /// </summary>
    public int DNFPosition { get; set; }
    
    /// <summary>
    /// Description of the session's type
    /// </summary>
    public SessionType SessionType { get; set; }
    
    public void CalculatePositions(int currentPosition)
    {
        if (currentPosition == 1)
        {
            HighestPosition = 1;
        }
        else
        {
            if (currentPosition > LowestPosition)
            {
                LowestPosition = currentPosition;
            } else if (currentPosition < HighestPosition)
            {
                HighestPosition = currentPosition;
            }
        }
    }
    
    public void CalculatePostSessionStats(RaceLog raceLog, int raceLaps)
    {
        FinishPosition = raceLog.CurrentPosition;
        TotalLapCount = raceLog.TotalLapCount;
        
        AveragePosition /= raceLaps;
        AverageRunningPosition /= TotalLapCount;

        Top15LapPercentage = Top15LapCount / TotalLapCount * 100;
        LapLedPercentage = LapLedCount / TotalLapCount * 100;
        CautionLapPercentage = CautionLapCount / TotalLapCount * 100;
    }
}