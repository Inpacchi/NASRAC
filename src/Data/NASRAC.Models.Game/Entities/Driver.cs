using NASRAC.Models.Game.BaseEntities;

namespace NASRAC.Models.Game.Entities;

public class Driver : GameObject
{
    public int Age { get; set; }
    public DriverRatings Ratings { get; set; }
}