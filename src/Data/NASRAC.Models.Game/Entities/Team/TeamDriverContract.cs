using NASRAC.Models.Game.BaseEntities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class TeamDriverContract : BaseContract
{
    public Team Team { get; set; }
    public Driver Driver { get; set; }
}