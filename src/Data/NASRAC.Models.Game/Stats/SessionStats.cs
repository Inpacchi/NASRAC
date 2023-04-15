using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.RaceEntities;
using NASRAC.Models.Game.Stats.Abstractions;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Stats;

/// <summary>
/// Driver's Session Statistics
/// </summary>
public class SessionStats : BaseSessionStats
{
    protected SessionStats()
    {
    }

    protected SessionStats(Race race, Driver driver) : base(race, driver)
    {
    }
    
    /// <summary>
    /// Session of the Race
    /// </summary>
    public RaceSession Session { get; set; }
}