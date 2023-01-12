using NASRAC.Models.Game.BaseEntities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class TeamSponsorContract : BaseContract
{
    public Team Team { get; set; }
    public Sponsor Sponsor { get; set; }
}