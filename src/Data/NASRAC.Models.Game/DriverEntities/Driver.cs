using System.ComponentModel.DataAnnotations;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.DriverEntities;

public class Driver
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int Age { get; set; }
    
    [Required]
    public double OverallRating { get; set; }
    
    [Required]
    public double PerformanceRating { get; set; }
    
    [Required]
    public double ShortTrackRating { get; set; }
    
    [Required]
    public double IntermediateTrackRating { get; set; }
    
    [Required]
    public double SuperspeedwayTrackRating { get; set; }
    
    [Required]
    public double RoadTrackRating { get; set; }
    
    [Required]
    public double PotentialRating { get; set; }
    
    [Required]
    public double ProgressionRate { get; set; }
    
    [Required]
    public double RegressionRate { get; set; }
    
    [Required]
    public int PeakAgeStart { get; set; }
    
    [Required]
    public int PeakAgeEnd { get; set; }
    
    [Required]
    public int RetirementFactor { get; set; }
    
    [Required]
    public double DNFOdds { get; set; }
    
    [Required]
    public Marketability Marketability { get; set; }
    
}