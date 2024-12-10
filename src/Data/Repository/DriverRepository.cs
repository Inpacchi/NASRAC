using Microsoft.EntityFrameworkCore;
using NASRAC.Core.Interfaces;
using NASRAC.Core.Models.Game.DriverEntities;
using NASRAC.Data.DAL;

namespace NASRAC.Data.Repository;

public class DriverRepository(DataContext dataContext) : IDriverRepository
{
    public DbSet<Driver> GetAllDrivers()
    {
        return dataContext.Driver;
    }
}