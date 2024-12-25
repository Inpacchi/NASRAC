using Microsoft.EntityFrameworkCore.ChangeTracking;
using NASRAC.Core.DTOs;
using NASRAC.Core.Entities.Game;

namespace NASRAC.Core.Interfaces;

public interface IRaceRepository
{
    public List<RaceLogDto> GetRaceLogsByRaceId(int raceId);
    public Race GetRaceById(int raceId);
    public Race GetRaceByName(string name);
    public EntityEntry<QualifyingStats> AddQualifyingStats(QualifyingStats qualifyingStats);
    public EntityEntry<RaceLog> AddRaceLog(RaceLog raceLog);
    public EntityEntry<SessionResults> AddSessionResults(SessionResults sessionResults);
    public int SaveChanges();
}