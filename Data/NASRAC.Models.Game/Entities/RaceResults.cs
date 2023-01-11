using NASRAC.Models.Game.BaseEntities;

namespace NASRAC.Models.Game.Entities;

public class RaceResults : BaseResults
{
    public int StartPosition { get; set; }
    public ICollection<int> StagePositions { get; set; }
    public int FinishPosition { get; set; }
    public int LowestPosition { get; set; }
    public int HighestPosition { get; set; }
    public int AveragePosition { get; set; }
    public int Top15LapCount { get; set; }
    public int Top15LapPercentage { get; set; }
    public int LapLedCount { get; set; }
    public int LapLedPercentage { get; set; }
    public int TotalLapCount { get; set; }
}