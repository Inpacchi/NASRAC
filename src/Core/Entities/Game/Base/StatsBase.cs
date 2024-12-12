using System.ComponentModel.DataAnnotations;

namespace NASRAC.Core.Entities.Game.Base;

/// <summary>
/// Base implementation of the Stats class that all Stats & Results related classes should implement
/// </summary>
public abstract class StatsBase
{
    protected StatsBase()
    {
    }

    protected StatsBase(int raceId, int driverId)
    {
        RaceId = raceId;
        DriverId = driverId;
    }
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int RaceId { get; set; }
    
    public virtual Race? Race { get; set; }
    
    [Required]
    public int DriverId { get; set; }
    
    public virtual Driver? Driver { get; set; }
    
    [Required]
    public double FastestTime { get; set; }
    
    [Required]
    public double TopSpeed { get; set; }
}