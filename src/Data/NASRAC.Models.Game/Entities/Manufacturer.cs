using NASRAC.Models.Game.BaseEntities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class Manufacturer : GameObject
{
    public VehicleType VehicleType { get; set; }
}