using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.Webapp.Entities;

namespace NASRAC.Models.Game.Entities;

public class Team : GameObject
{
    public AppUser Owner { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public TeamRatings Ratings { get; set; }
    public TeamFinancials Financials { get; set; }
    public ICollection<Car> Cars { get; set; }
    public ICollection<Driver> Drivers { get; set; }
}