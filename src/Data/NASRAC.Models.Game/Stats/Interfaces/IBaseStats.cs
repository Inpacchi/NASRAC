using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.RaceEntities;

namespace NASRAC.Models.Game.Stats.Interfaces;

public interface IBaseStats
{
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