using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.RaceEntities;
using NASRAC.Models.Game.Stats.Abstractions;

namespace NASRAC.Models.Game.Stats;

/// <summary>
/// Driver's Final Race Results
/// </summary>
public class RaceResults : BaseSessionStats
{
    public RaceResults()
    {
    }

    public RaceResults(Race race, Driver driver) : base(race, driver)
    {
    }
    
    /// <summary>
    /// Driver's position at the end of stage 1
    /// </summary>
    public int Stage1Position { get; set; }

    /// <summary>
    /// Driver's position at the end of stage 2
    /// </summary>
    public int Stage2Position { get; set; }

    /// <summary>
    /// Driver's position at the end of the race
    /// </summary>
    public int EndPosition { get; set; }
}