using Microsoft.EntityFrameworkCore;
using NASRAC.Core.Entities.Game;
using NASRAC.Core.Interfaces;
using NASRAC.Data.DAL;

namespace NASRAC.Data.Repository;

public class DriverRepository(DataContext dataContext) : IDriverRepository
{
    public List<Driver> GetAllDrivers()
    {
        return dataContext.Driver
            .Include(d => d.Team)
            .ToList();
    }
}