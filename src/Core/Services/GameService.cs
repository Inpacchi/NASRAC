using NASRAC.Models.Game.Stats;
using Data.DAL;
using Data.Repository;
using Core.Interfaces;
using Core.Logic;

namespace Core.Implementations;

public class GameService(DataContext dataContext, RaceRepository raceRepository) : IGameService
{
    private readonly RaceWeekend _raceWeekend = new(dataContext);
    private readonly DataContext _dataContext = dataContext;

    public void RunRace()
    {
        _raceWeekend.Initialize();
    }

    public RaceLog GetRaceLog(int raceId)
    {
        return raceRepository.GetRaceLogById(raceId);
    }
}