using NASRAC.Models.Game.BaseEntities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class Sponsor
{
    public string Name { get; set; }
    public double Budget { get; set; }
    public PrestigeLevel PrestigeLevel { get; set; }
}