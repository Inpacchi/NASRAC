using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class Race
{
    public string Name { get; set; }
    public int Laps { get; set; }
    public int Stages { get; set; }
    public RaceType Type { get; set; }
    public Track Track { get; set; }
}