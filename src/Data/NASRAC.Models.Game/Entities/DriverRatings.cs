namespace NASRAC.Models.Game.Entities;

public class DriverRatings
{
    public Driver Driver { get; set; }
    public double Overall { get; set; }
    public double Performance { get; set; }
    public double ShortTrack { get; set; }
    public double IntermediateTrack { get; set; }
    public double SuperspeedwayTrack { get; set; }
    public double RoadTrack { get; set; }
    public double Potential { get; set; }
    public double ProgressionRate { get; set; }
    public double RegressionRate { get; set; }
    public int PeakAgeStart { get; set; }
    public int PeakAgeEnd { get; set; }
}