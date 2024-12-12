using System.ComponentModel.DataAnnotations;

namespace NASRAC.Core.Entities.Game;

public class Schedule
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int RaceNumber { get; set; }

    [Required]
    public DateOnly Date { get; set; }
    
    public int RaceId { get; set; }
    
    [Required]
    public virtual Race? Race { get; set; }
    
    public int SeasonId { get; set; }
}