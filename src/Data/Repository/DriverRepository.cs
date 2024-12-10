using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.DriverEntities;
using Data.DAL;
using Data.Repository.Abstractions;

namespace Data.Repository;

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