using Microsoft.EntityFrameworkCore;
using NASRAC.Core.Entities.Game;

namespace NASRAC.Core.Interfaces;

public interface IDriverRepository
{
    public List<Driver> GetAllDrivers();
}