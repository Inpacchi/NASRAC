using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Enums;

namespace NASRAC.Core.Entities.Game;

/// <summary>
/// Sponsor entity
/// </summary>
public class Sponsor
{
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Name of the sponsor
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    /// Budget of the sponsor
    /// </summary>
    [Required]
    public double Budget { get; set; }
    
    /// <summary>
    /// Prestige level of the sponsor
    /// </summary>
    [Required]
    public PrestigeLevel PrestigeLevel { get; set; }
}