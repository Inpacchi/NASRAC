using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.JoinEntities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

/// <summary>
/// Manufacturer entity
/// </summary>
public class Manufacturer
{
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Name of the manufacturer
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    /// Type of vehicle the manufacturer produces
    /// </summary>
    [Required]
    public VehicleType VehicleType { get; set; }
    
    /// <summary>
    /// Teams the manufacturer provides for
    /// </summary>
    public ICollection<TeamManufacturers> TeamManufacturers { get; set; }
}