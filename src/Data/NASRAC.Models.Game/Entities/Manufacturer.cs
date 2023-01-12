using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class Manufacturer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public VehicleType VehicleType { get; set; }
}