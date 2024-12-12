using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Enums;

namespace NASRAC.Core.Entities.Game;

public class Race
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    public int Laps { get; set; }
    
    [Required]
    public int Stages { get; set; }
    
    [Required]
    public RaceType Type { get; set; }
    
    [Required]
    public int TrackId { get; set; }
    
    [Required]
    public virtual Track? Track { get; set; }
    
    public virtual List<RaceLog>? RaceLogs { get; set; }
}