using System.ComponentModel.DataAnnotations;

namespace NASRAC.Models.Game.Entities;

/// <summary>
/// Schedule entity
/// </summary>
public class Schedule
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Date of the race
    /// </summary>
    [Required]
    public DateOnly ScheduleDate { get; set; }
    
    [Required]
    public Race Race { get; set; }
}