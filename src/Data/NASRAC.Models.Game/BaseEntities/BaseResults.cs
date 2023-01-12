using NASRAC.Models.Game.Entities;

namespace NASRAC.Models.Game.BaseEntities;

public abstract class BaseResults
{
    public Race Race { get; set; }
    public Driver Driver { get; set; }
    public double FastestTime { get; set; }
    public double TopSpeed { get; set; }
}