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
    /// Season for the scheduled race
    /// </summary>
    [Required]
    public Season Season { get; set; }
    
    /// <summary>
    /// ID of the race for the season
    /// </summary>
    [Required]
    public int RaceNumber { get; set; }

    /// <summary>
    /// Date of the race
    /// </summary>
    [Required]
    public DateOnly ScheduleDate { get; set; }
    
    [Required]
    public Race Race { get; set; }
}