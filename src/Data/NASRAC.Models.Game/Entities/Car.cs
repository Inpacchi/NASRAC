using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.TeamEntities;

namespace NASRAC.Models.Game.Entities;

/// <summary>
/// Car entity
/// </summary>
public class Car
{
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Number of the car
    /// </summary>
    [Required]
    public int Number { get; set; }
    
    /// <summary>
    /// Manufacturer of the car
    /// </summary>
    [Required]
    public Manufacturer Manufacturer { get; set; }
    
    /// <summary>
    /// Owner of the car
    /// </summary>
    [Required]
    public Team Team { get; set; }
}