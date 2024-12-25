using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NASRAC.Core.DTOs;
using NASRAC.Core.Entities.Game;
using NASRAC.Core.Interfaces;
using NASRAC.Data.DAL;
using NASRAC.Data.Extensions;

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

    public List<RaceLogDto> GetRaceLogsByRaceId(int raceId)
    {
        return dataContext.RaceLog
            .Include(rl => rl.Race)
                .ThenInclude(r => r.Track)
            .Include(rl => rl.Driver)
                .ThenInclude(d => d.Team)
            .Where(rl => rl.Race.Id == raceId)
            .MapProperties<RaceLog, RaceLogDto>()
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