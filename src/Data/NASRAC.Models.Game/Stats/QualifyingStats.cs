using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.RaceEntities;
using NASRAC.Models.Game.Stats.Abstractions;

namespace NASRAC.Models.Game.Stats;

/// <summary>
/// Driver's Qualifying Statistics
/// </summary>
public class QualifyingStats : BaseStats
{
    public QualifyingStats()
    {
    }
    public QualifyingStats(Race race, Driver driver) : base(race, driver)
    {
    }

    /// <summary>
    /// Final qualifying position
    /// </summary>
    public int Position { get; set; }
}