using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.Game.Entities;

namespace NASRAC.Models.Game.TeamEntities;

public class ManufacturerContract : BaseContract
{
    public Team Team { get; set; }
    public Manufacturer Manufacturer { get; set; }
}