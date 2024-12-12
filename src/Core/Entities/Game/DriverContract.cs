using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Entities.Game.Base;

namespace NASRAC.Core.Entities.Game;

/// <summary>
/// Team contract for drivers
/// </summary>
public class DriverContract : ContractBase
{
    [Required]
    public Team Team { get; set; }
    
    [Required]
    public Driver Driver { get; set; }
}