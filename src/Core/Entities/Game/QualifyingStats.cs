using NASRAC.Core.Entities.Game.Base;

namespace NASRAC.Core.Entities.Game;

public class QualifyingStats : StatsBase
{
    public QualifyingStats()
    {
    }

    public QualifyingStats(Race race, Driver driver) : base(race.Id, driver.Id)
    {
    }

    /// <summary>
    /// Final qualifying position
    /// </summary>
    public int Position { get; set; }
}