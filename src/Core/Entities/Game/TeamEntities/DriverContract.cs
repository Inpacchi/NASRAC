using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Models.Game.BaseEntities;
using NASRAC.Core.Models.Game.DriverEntities;

namespace NASRAC.Core.Models.Game.TeamEntities;

/// <summary>
/// Team contract for drivers
/// </summary>
public class DriverContract : BaseContract
{
    [Required]
    public Team Team { get; set; }
    
    [Required]
    public Driver Driver { get; set; }
}