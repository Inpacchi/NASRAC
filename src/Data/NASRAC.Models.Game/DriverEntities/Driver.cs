namespace NASRAC.Models.Game.DriverEntities;

public class Driver
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double OverallRating { get; set; }
    public double PerformanceRating { get; set; }
    public double ShortTrackRating { get; set; }
    public double IntermediateTrackRating { get; set; }
    public double SuperspeedwayTrackRating { get; set; }
    public double RoadTrackRating { get; set; }
    public double PotentialRating { get; set; }
    public double ProgressionRate { get; set; }
    public double RegressionRate { get; set; }
    public int PeakAgeStart { get; set; }
    public int PeakAgeEnd { get; set; }
}