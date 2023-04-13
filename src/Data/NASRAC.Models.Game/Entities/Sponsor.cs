using System.ComponentModel.DataAnnotations;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

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