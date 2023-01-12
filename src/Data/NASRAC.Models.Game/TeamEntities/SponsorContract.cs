using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.Game.Entities;

namespace NASRAC.Models.Game.TeamEntities;

public class SponsorContract : BaseContract
{
    public Team Team { get; set; }
    public Sponsor Sponsor { get; set; }
}