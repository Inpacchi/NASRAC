using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class Series
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Series Tier { get; set; }
    public VehicleType VehicleType { get; set; }
}