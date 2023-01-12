using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.Game.DriverEntities;

namespace NASRAC.Models.Game.TeamEntities;

public class DriverContract : BaseContract
{
    [Required]
    public Team Team { get; set; }
    
    [Required]
    public Driver Driver { get; set; }
}