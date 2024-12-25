using NASRAC.Core.Enums;

namespace NASRAC.Core.DTOs;

public class RaceDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Laps { get; set; }
    public int Stages { get; set; }
    public RaceType Type { get; set; }
    public TrackDto Track { get; set; }
}