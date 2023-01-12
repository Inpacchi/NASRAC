using NASRAC.Models.Game.BaseEntities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class TeamManufacturerContract : BaseContract
{
    public Team Team { get; set; }
    public Manufacturer Manufacturer { get; set; }
}