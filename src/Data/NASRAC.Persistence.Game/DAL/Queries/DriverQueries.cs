using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.DriverEntities;

namespace NASRAC.Persistence.Game.DAL.Queries;

public class DriverQueries : DataContext
{
    public DriverQueries(DbContextOptions options) : base(options)
    {
    }
    
    public ICollection<Driver> GetAllDrivers()
    {
        return Driver
            .Include(d => d.Team)
            .ToList();
    }
}