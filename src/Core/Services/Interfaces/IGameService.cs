using NASRAC.Core.DTOs;
using NASRAC.Core.Entities.Game;

namespace NASRAC.Core.Services.Interfaces;

public interface IGameService
{
    public void RunRace();
    public List<RaceLogDto> GetRaceLogs(int raceId);
}