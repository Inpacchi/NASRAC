using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Entities.Game.Base;

namespace NASRAC.Core.Entities.Game;

/// <summary>
/// Sponsor contract for drivers
/// </summary>
public class SponsorContract : ContractBase
{
    [Required]
    public Driver Driver { get; set; }
    
    [Required]
    public Sponsor Sponsor { get; set; }
}