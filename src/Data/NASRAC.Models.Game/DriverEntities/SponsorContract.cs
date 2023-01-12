using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.Game.Entities;

namespace NASRAC.Models.Game.DriverEntities;

public class SponsorContract : BaseContract
{
    public Driver Driver { get; set; }
    public Sponsor Sponsor { get; set; }
}