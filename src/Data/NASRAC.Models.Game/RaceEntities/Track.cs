using System.ComponentModel.DataAnnotations;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

/// <summary>
/// Track entity
/// </summary>
public class Track
{
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Name of the track
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    /// Location of the track
    /// </summary>
    [Required]
    public string Location { get; set; }
    
    /// <summary>
    /// Length of the track
    /// </summary>
    [Required]
    public double Length { get; set; }
    
    /// <summary>
    /// Type of track
    /// </summary>
    [Required]
    public TrackType Type { get; set; }
}