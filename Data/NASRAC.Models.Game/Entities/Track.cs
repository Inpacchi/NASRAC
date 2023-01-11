using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class Track
{
    public string Name { get; set; }
    public string Location { get; set; }
    public double Length { get; set; }
    public TrackType Type { get; set; }
}