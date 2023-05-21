using NASRAC.Persistence.Game.DAL;
using NASRAC.Services.Game.Interfaces;
using NASRAC.Services.Game.Services;

namespace NASRAC.Services.Game.Implementations;

public class GameService : IGameService
{
    private readonly RaceWeekend _raceWeekend;
    private readonly DataContext _dataContext;
    
    public GameService(DataContext dataContext)
    {
        _dataContext = dataContext;
        _raceWeekend = new RaceWeekend(dataContext);
    }
    public void RunRace()
    {
        _raceWeekend.Initialize();
    }
}