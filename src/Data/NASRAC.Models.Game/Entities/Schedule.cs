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
    /// Event series number
    /// </summary>
    [Required]
    public int RaceNumber { get; set; }

    /// <summary>
    /// Date of the race
    /// </summary>
    [Required]
    public DateOnly Date { get; set; }
    
    /// <summary>
    /// ID of the event
    /// </summary>
    public int RaceId { get; set; }
    
    /// <summary>
    /// Event details
    /// </summary>
    [Required]
    public Race Race { get; set; }
    
    /// <summary>
    /// ID of the season the schedule is tied to
    /// </summary>
    public int SeasonId { get; set; }
}