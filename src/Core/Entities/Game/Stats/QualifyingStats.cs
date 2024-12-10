using NASRAC.Core.Models.Game.DriverEntities;
using NASRAC.Core.Models.Game.RaceEntities;
using NASRAC.Core.Models.Game.Stats.Abstractions;

namespace NASRAC.Core.Models.Game.Stats;

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