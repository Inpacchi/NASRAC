using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.Game.DriverEntities;

namespace NASRAC.Models.Game.Entities;

/// <summary>
/// Qualifying Results entity
/// </summary>
public class QualifyingResults : BaseResults
{
    public QualifyingResults()
    {
        Initialize();
    }
    public QualifyingResults(Race race, Driver driver) : base(race, driver)
    {
        Initialize();
    }

    protected sealed override void Initialize()
    {
        base.Initialize();

        Position = null;
    }

    /// <summary>
    /// Final qualifying position
    /// </summary>
    public int? Position { get; set; }
}