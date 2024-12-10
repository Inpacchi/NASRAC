using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Models.Game.BaseEntities;
using NASRAC.Core.Models.Game.Entities;

namespace NASRAC.Core.Models.Game.TeamEntities;

public class SponsorContract : BaseContract
{
    [Required]
    public Team Team { get; set; }
    
    [Required]
    public Sponsor Sponsor { get; set; }
}