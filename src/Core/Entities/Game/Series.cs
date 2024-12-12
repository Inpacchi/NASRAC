using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Enums;

namespace NASRAC.Core.Entities.Game;

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
    public SeriesTier Tier { get; set; }
    
    /// <summary>
    /// Vehicle types allowed in the series
    /// </summary>
    [Required]
    public VehicleType VehicleType { get; set; }
}