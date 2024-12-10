using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Models.Game.Entities;
using NASRAC.Core.Models.Game.TeamEntities;

namespace NASRAC.Core.Models.Game.JoinEntities;

public class TeamManufacturers
{
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// ID of the manufacturer
    /// </summary>
    public int ManufacturerId { get; set; }
    
    /// <summary>
    /// Team manufacturer
    /// </summary>
    public Manufacturer Manufacturer { get; set; }
    
    /// <summary>
    /// ID of the team
    /// </summary>
    public int TeamId { get; set; }
    
    /// <summary>
    /// Team the manufacturer provides for
    /// </summary>
    public Team Team { get; set; }
}