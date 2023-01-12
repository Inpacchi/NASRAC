using System.ComponentModel.DataAnnotations;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

/// <summary>
/// Series entity
/// </summary>
public class Series
{
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Name of the series
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    /// Tier of the series
    /// </summary>
    [Required]
    public Series Tier { get; set; }
    
    /// <summary>
    /// Vehicle types allowed in the series
    /// </summary>
    [Required]
    public VehicleType VehicleType { get; set; }
}