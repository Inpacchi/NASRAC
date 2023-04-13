using System.ComponentModel.DataAnnotations;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.RaceEntities;

/// <summary>
/// Race entity
/// </summary>
public class Race
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Name of the race
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    /// Total amount of laps for the race
    /// </summary>
    [Required]
    public int Laps { get; set; }
    
    /// <summary>
    /// Total amount of stages for the race
    /// </summary>
    [Required]
    public int Stages { get; set; }
    
    /// <summary>
    /// Type of race
    /// </summary>
    [Required]
    public RaceType Type { get; set; }
    
    /// <summary>
    /// ID of the track the race is being held at
    /// </summary>
    [Required]
    public int TrackId { get; set; }
    
    /// <summary>
    /// Track the race is being held at
    /// </summary>
    [Required]
    public Track Track { get; set; }
}