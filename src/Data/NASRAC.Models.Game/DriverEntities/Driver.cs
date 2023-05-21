using System.ComponentModel.DataAnnotations;
using Bogus;
using Bogus.Distributions.Gaussian;
using NASRAC.Models.Game.TeamEntities;
using NASRAC.Services.Common.Enums;
using NASRAC.Services.Common.Equations;
using NASRAC.Services.Common.Services;

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
    public int? TeamId { get; set; }

    /// <summary>
    /// Team the driver is contracted to
    /// </summary>
    public Team Team { get; set; }

    public double GetTrackRating(TrackType trackType)
    {
        return trackType switch
        {
            TrackType.Short => ShortTrackRating,
            TrackType.Intermediate => IntermediateTrackRating,
            TrackType.Superspeedway => SuperspeedwayTrackRating,
            TrackType.Road => RoadTrackRating,
            _ => 0
        };
    }
    
    public static Driver GenerateRandomDriver(int id)
    {
        var driver = new Faker<Driver>()
            .RuleFor(d => d.Id, f => id)
            .RuleFor(d => d.Name, f => f.Name.FullName())
            .RuleFor(d => d.Age, f => f.Random.GaussianInt(30, 7))
            .Generate();

        driver.PeakAgeStart = RNG.RollIntRange(27, 38);
        driver.PeakAgeEnd = RNG.RollIntRange(driver.PeakAgeStart, 41);
        
        driver.PotentialRating = Gaussian.GeneratePotentialRating(driver.Age);

        var ratingMean = RNG.RollDoubleRange(driver.PotentialRating * .6, driver.PotentialRating);
        var ratingStdDev = RNG.RollDoubleRange(driver.PotentialRating * .05, driver.PotentialRating * .2);
        
        driver.ShortTrackRating = RNG.Clamp(Gaussian.GenerateNormal(ratingMean, ratingStdDev), 50, 100, 3);
        driver.IntermediateTrackRating = RNG.Clamp(Gaussian.GenerateNormal(ratingMean, ratingStdDev), 50, 100, 3);
        driver.SuperspeedwayTrackRating = RNG.Clamp(Gaussian.GenerateNormal(ratingMean, ratingStdDev), 50, 100, 3);
        driver.RoadTrackRating = RNG.Clamp(Gaussian.GenerateNormal(ratingMean, ratingStdDev), 50, 100, 3);
        
        driver.OverallRating = RNG.Clamp((driver.ShortTrackRating + driver.IntermediateTrackRating + driver.SuperspeedwayTrackRating + driver.RoadTrackRating) / 4, 0, 100, 3);
        
        driver.ProgressionRate = RNG.RollDoubleRange(0, .1, 3);
        driver.RegressionRate = RNG.RollDoubleRange(0, driver.ProgressionRate, 3);
        driver.RetirementFactor = RNG.RollDoubleRange(0, .005, 3);
        driver.DNFOdds = RNG.RollDoubleRange(0, .005, 3);
        driver.Marketability = RNG.RollEnum<Marketability>();

        return driver;
    }
}