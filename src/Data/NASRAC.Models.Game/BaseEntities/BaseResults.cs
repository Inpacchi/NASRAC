using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;

namespace NASRAC.Models.Game.BaseEntities;

public abstract class BaseResults
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public Race Race { get; set; }
    
    [Required]
    public Driver Driver { get; set; }
    
    [Required]
    public double FastestTime { get; set; }
    
    [Required]
    public double TopSpeed { get; set; }
}