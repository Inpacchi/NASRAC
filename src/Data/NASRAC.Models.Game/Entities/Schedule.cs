using System.ComponentModel.DataAnnotations;

namespace NASRAC.Models.Game.Entities;

public class Schedule
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    [Required]
    public Series Series { get; set; }
    
    [Required]
    public Race Race { get; set; }
    
    [Required]
    public int EventNumber { get; set; }
}