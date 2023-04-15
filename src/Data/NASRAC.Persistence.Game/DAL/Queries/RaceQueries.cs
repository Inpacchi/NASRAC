using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.RaceEntities;

namespace NASRAC.Persistence.Game.DAL.Queries;

public class RaceQueries : DataContext
{
    public RaceQueries(DbContextOptions options) : base(options)
    {
    }
    
    public Race GetRaceById(int id)
    {
        return Race
            .Include(r => r.Track)
            .First(r => r.Id.Equals(id));
    }

    public Race GetRaceByName(string name)
    {
        return Race
            .Include(r => r.Track)
            .First(r => r.Name.Equals(name));
    }
}