using NASRAC.Models.Game.BaseEntities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class Manufacturer
{
    public string Name { get; set; }
    public VehicleType VehicleType { get; set; }
}