using NASRAC.Core.Interfaces;
using NASRAC.Core.Models.Game.RaceEntities;
using NASRAC.Core.Models.Game.Stats;
using NASRAC.Data.DAL;

namespace NASRAC.Data.Repository;

public class RaceRepository(DataContext dataContext)
{
    // public Race GetRaceById(int id)
    // {
    //     return dataContext
    //         .Include(r => r.Track)
    //         .First(r => r.Id.Equals(id));
    // }
    //
    // public Race GetRaceByName(string name)
    // {
    //     return Repository
    //         .Include(r => r.Track)
    //         .First(r => r.Name.Equals(name));
    // }
    //
    // public RaceLog GetRaceLogById(int id)
    // {
    //     return Repository
    //         .Include(r => r.Track)
    //         .First(r => r.Id.Equals(id))
    //         .RaceLogs
    //         .First();
    // }
}