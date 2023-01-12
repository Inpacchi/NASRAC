using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.WebApp.Entities;

namespace NASRAC.Models.Game.Entities;

public class Team : GameObject
{
    public AppUser Owner { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public double EquipmentRating { get; set; }
    public double PersonnelRating { get; set; }
    public double PerformanceRating { get; set; }
    public double OverallRating { get; set; }
    public ICollection<Car> Cars { get; set; }
    public ICollection<Driver> Drivers { get; set; }

    // TODO: Implement
    public TeamFinancials GetLatestFinancials()
    {
        throw new NotImplementedException();
    }
}