using NASRAC.Core.Entities.Game;
using NASRAC.Core.Enums;

namespace NASRAC.Core.Helpers;

public class RateRange
{
    private const double DriverFactor = 1.25;
    private const double TeamFactor = 1.4;
    private const double BonusFactor = 50;
    
    public Driver Driver { get; set; }
    public int StartingRange { get; set; }
    public int EndingRange { get; set; }

    public RateRange(Driver driver, TrackType trackType, int startingRange, int bonus = 0)
    {
        Driver = driver;
        StartingRange = startingRange;
        EndingRange = startingRange + CalculateRange(trackType, bonus);
    }

    private int CalculateRange(TrackType trackType, int bonus = 0)
    {
        var driverResult = Math.Pow(Driver.GetTrackRating(trackType), DriverFactor);
        var teamResult = Math.Pow((Driver.Team.EquipmentRating + Driver.Team.PersonnelRating) / 2, TeamFactor);
        var bonusResult = bonus * BonusFactor;
        
        return Convert.ToInt32(Math.Round((driverResult * teamResult + bonusResult) / 100));
    }
}