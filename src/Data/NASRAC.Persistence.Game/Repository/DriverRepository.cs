using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Persistence.Game.DAL;

namespace NASRAC.Persistence.Game.Repository;

public class DriverRepository : BaseRepository<Driver>
{
    public DriverRepository(DataContext dataContext) : base(dataContext)
    {
    }
    
    public ICollection<Driver> GetAllDrivers()
    {
        return Repository
            .Include(d => d.Team)
            .ToList();
    }
}