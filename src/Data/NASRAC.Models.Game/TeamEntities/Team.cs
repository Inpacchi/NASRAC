using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Models.WebApp.Entities;

namespace NASRAC.Models.Game.TeamEntities;

public class Team
{
    public string Name { get; set; }
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