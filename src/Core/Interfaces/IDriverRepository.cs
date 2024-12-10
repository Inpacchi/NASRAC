using Microsoft.EntityFrameworkCore;
using NASRAC.Core.Models.Game.DriverEntities;

namespace NASRAC.Core.Interfaces;

public interface IDriverRepository
{
    public DbSet<Driver> GetAllDrivers();
}