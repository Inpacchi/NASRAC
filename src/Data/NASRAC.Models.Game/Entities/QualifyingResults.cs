using NASRAC.Models.Game.BaseEntities;

namespace NASRAC.Models.Game.Entities;

/// <summary>
/// Qualifying Results entity
/// </summary>
public class QualifyingResults : BaseResults
{
    /// <summary>
    /// Final qualifying position
    /// </summary>
    public int Position { get; set; }
}