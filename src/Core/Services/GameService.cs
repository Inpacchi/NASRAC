using NASRAC.Core.DTOs;
using NASRAC.Core.Entities.Game;
using NASRAC.Core.Interfaces;
using NASRAC.Core.Services.Interfaces;

namespace NASRAC.Core.Services;

public class GameService(IRaceWeekend raceWeekend, IRaceRepository raceRepository) : IGameService
{
    public void RunRace()
    {
        raceWeekend.Initialize();
    }

    public List<RaceLogDto> GetRaceLogs(int raceId)
    {
        return raceRepository.GetRaceLogsByRaceId(raceId);
    }
}