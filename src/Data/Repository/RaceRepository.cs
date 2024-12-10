using Microsoft.EntityFrameworkCore;
using Data.DAL;
using Data.Repository.Abstractions;

namespace Data.Repository;

public class RaceRepository(DataContext dataContext) : BaseRepository<Race>(dataContext)
{
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

    public RaceLog GetRaceLogById(int id)
    {
        return Repository
            .Include(r => r.Track)
            .First(r => r.Id.Equals(id))
            .RaceLogs
            .First();
    }
}