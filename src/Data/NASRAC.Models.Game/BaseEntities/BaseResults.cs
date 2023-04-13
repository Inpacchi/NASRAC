using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.RaceEntities;

namespace NASRAC.Models.Game.BaseEntities;

/// <summary>
/// Base implementation of the Results class that all Results classes should implement
/// </summary>
public abstract class BaseResults
{
    protected BaseResults()
    {
    }

    protected BaseResults(Race race, Driver driver)
    {
        Race = race;
        RaceId = race.Id;
        Driver = driver;
        DriverId = driver.Id;
    }
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int RaceId { get; set; }
    
    public Race Race { get; set; }
    
    [Required]
    public int DriverId { get; set; }
    
    public Driver Driver { get; set; }
    
    /// <summary>
    /// Fastest lap time achieved of the session
    /// </summary>
    [Required]
    public double FastestTime { get; set; }
    
    /// <summary>
    /// Fastest speed achieved of the session
    /// </summary>
    [Required]
    public double TopSpeed { get; set; }
}