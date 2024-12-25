using NASRAC.Core.Enums;

namespace NASRAC.Core.DTOs;

public class TrackDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public double Length { get; set; }
    public TrackType Type { get; set; }
}