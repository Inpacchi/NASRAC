using NASRAC.Persistence.Game.DAL;
using NASRAC.Services.Game.Interfaces;

namespace NASRAC.Services.Game.Services;

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
        _raceWeekend.Initialization();
    }
}