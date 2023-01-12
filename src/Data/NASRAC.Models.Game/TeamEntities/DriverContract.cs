using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.Game.DriverEntities;

namespace NASRAC.Models.Game.TeamEntities;

public class DriverContract : BaseContract
{
    public Team Team { get; set; }
    public Driver Driver { get; set; }
}