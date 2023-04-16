using Microsoft.EntityFrameworkCore;
using NASRAC.Models.Game.RaceEntities;
using NASRAC.Persistence.Game.DAL;

namespace NASRAC.Persistence.Game.Repository;

public class RaceRepository : BaseRepository<Race>
{
    public RaceRepository(DataContext dataContext) : base(dataContext)
    {
    }
    
    public Race GetRaceById(int id)
    {
        return Repository
            .Include(r => r.Track)
            .First(r => r.Id.Equals(id));
    }

    public Race GetRaceByName(string name)
    {
        return Repository
            .Include(r => r.Track)
            .First(r => r.Name.Equals(name));
    }
}