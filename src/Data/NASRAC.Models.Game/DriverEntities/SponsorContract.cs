using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.Game.Entities;

namespace NASRAC.Models.Game.DriverEntities;

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