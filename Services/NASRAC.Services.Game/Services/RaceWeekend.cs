using NASRAC.Persistence.Game.DAL;
using NASRAC.Services.Common.Enums;
using NASRAC.Services.Game.Entities;
using NASRAC.Services.Game.Interfaces;

namespace NASRAC.Services.Game.Services;

public class RaceWeekend : IRaceWeekend
{
    private readonly DataContext _dataContext;
    
    public RaceWeekend(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void RunRace()
    {
        var drivers = _dataContext.Driver;
        var rateRanges = new List<RateRange>();
        var startingRange = 0;
        
        foreach (var driver in drivers)
        {
            var rateRange = new RateRange(driver, TrackType.Short, startingRange);
            startingRange = rateRange.EndingRange + 1;
            rateRanges.Add(rateRange);
        }
    } 
}