using Microsoft.EntityFrameworkCore.ChangeTracking;
using NASRAC.Core.Entities.Game;

namespace NASRAC.Core.Interfaces;

public interface IRaceRepository
{
    public List<RaceLog> GetRaceLogsByRaceId(int raceId);
    public Race GetRaceById(int raceId);
    public Race GetRaceByName(string name);
    public EntityEntry<QualifyingStats> AddQualifyingStats(QualifyingStats qualifyingStats);
    public EntityEntry<RaceLog> AddRaceLog(RaceLog raceLog);
    public EntityEntry<SessionResults> AddSessionResults(SessionResults sessionResults);
    public int SaveChanges();
}