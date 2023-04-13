using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.Game.DriverEntities;

namespace NASRAC.Models.Game.RaceEntities;

/// <summary>
/// Qualifying Results entity
/// </summary>
public class QualifyingResults : BaseResults
{
    public QualifyingResults()
    {
    }
    public QualifyingResults(Race race, Driver driver) : base(race, driver)
    {
    }

    /// <summary>
    /// Final qualifying position
    /// </summary>
    public int Position { get; set; }
}