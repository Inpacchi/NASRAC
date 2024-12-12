using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NASRAC.Core.Entities.Game;
using NASRAC.Core.Interfaces;
using NASRAC.Data.DAL;

namespace NASRAC.Data.Repository;

public class RaceRepository(DataContext dataContext) : IRaceRepository
{
    public Race GetRaceById(int id)
    {
        return dataContext.Race
            .Include(r => r.Track)
            .First(r => r.Id.Equals(id));
    }
    
    public Race GetRaceByName(string name)
    {
        return dataContext.Race
            .Include(r => r.Track)
            .First(r => r.Name.Equals(name));
    }

    public List<RaceLog> GetRaceLogsByRaceId(int raceId)
    {
        return dataContext.RaceLog
            .Include(rl => rl.Race)
            .ThenInclude(r => r.Track)
            .Where(rl => rl.RaceId == raceId)
            .ToList();
    }

    public EntityEntry<QualifyingStats> AddQualifyingStats(QualifyingStats qualifyingStats)
    {
        return dataContext.QualifyingStats.Add(qualifyingStats);
    }

    public EntityEntry<RaceLog> AddRaceLog(RaceLog raceLog)
    {
        return dataContext.RaceLog.Add(raceLog);
    }

    public EntityEntry<SessionResults> AddSessionResults(SessionResults sessionResults)
    {
        return dataContext.SessionResults.Add(sessionResults);
    }

    public int SaveChanges()
    {
        return dataContext.SaveChanges();
    }
}