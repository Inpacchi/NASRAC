using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Models.Game.BaseEntities;
using NASRAC.Core.Models.Game.Entities;

namespace NASRAC.Core.Models.Game.DriverEntities;

/// <summary>
/// Sponsor contract for drivers
/// </summary>
public class SponsorContract : BaseContract
{
    [Required]
    public Driver Driver { get; set; }
    
    [Required]
    public Sponsor Sponsor { get; set; }
}