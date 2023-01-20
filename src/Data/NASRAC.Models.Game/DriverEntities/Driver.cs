using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.TeamEntities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.DriverEntities;

/// <summary>
/// Driver entity
/// </summary>
public class Driver
{
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Name of the driver
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    /// Age of the driver
    /// </summary>
    [Required]
    public int Age { get; set; }
    
    /// <summary>
    /// Measure of the driver's ratings overall (average of the individual ratings)
    /// </summary>
    [Required]
    public double OverallRating { get; set; }
    
    /// <summary>
    /// Measure of the driver's current performance
    /// </summary>
    [Required]
    public double PerformanceRating { get; set; }
    
    /// <summary>
    /// Measure of the driver's Short track capability
    /// </summary>
    [Required]
    public double ShortTrackRating { get; set; }
    
    /// <summary>
    /// Measure of the driver's Intermediate track capability
    /// </summary>
    [Required]
    public double IntermediateTrackRating { get; set; }
    
    /// <summary>
    /// Measure of the driver's Superspeedway track capability
    /// </summary>
    [Required]
    public double SuperspeedwayTrackRating { get; set; }
    
    /// <summary>
    /// Measure of the driver's Road track capability
    /// </summary>
    [Required]
    public double RoadTrackRating { get; set; }
    
    /// <summary>
    /// Max value that the overall rating can reach
    /// </summary>
    [Required]
    public double PotentialRating { get; set; }
    
    /// <summary>
    /// Measure of how much the driver's ratings can be increased by
    /// </summary>
    [Required]
    public double ProgressionRate { get; set; }
    
    /// <summary>
    /// Measure of how much the driver's ratings can be decreased by
    /// </summary>
    [Required]
    public double RegressionRate { get; set; }
    
    /// <summary>
    /// Age where the driver's stats progress the most and regress the least
    /// </summary>
    public int PeakAgeStart { get; set; }
    
    /// <summary>
    /// Age where the driver's stats start to regress more and progress less
    /// </summary>
    public int PeakAgeEnd { get; set; }
    
    /// <summary>
    /// Likelihood that a driver will retire
    /// </summary>
    [Required]
    public double RetirementFactor { get; set; }
    
    /// <summary>
    /// Likelihood that a driver will DNF (Did Not Finish)
    /// </summary>
    [Required]
    public double DNFOdds { get; set; }
    
    /// <summary>
    /// Measure of the driver's marketability
    /// </summary>
    [Required]
    public Marketability Marketability { get; set; }

    /// <summary>
    /// ID of the team the driver is contracted to
    /// </summary>
    public int TeamId { get; set; }

    /// <summary>
    /// Team the driver is contracted to
    /// </summary>
    public Team Team { get; set; }
}