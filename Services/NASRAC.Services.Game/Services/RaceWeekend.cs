using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Persistence.Game.DAL;
using NASRAC.Services.Common.Enums;
using NASRAC.Services.Common.Services;
using NASRAC.Services.Game.Entities;
using NASRAC.Services.Game.Interfaces;

namespace NASRAC.Services.Game.Services;

public class RaceWeekend : IRaceWeekend
{
    private const double DriverFactor = 1.25;
    private const double TeamFactor = 1.40;
    
    private readonly DataContext _dataContext;
    
    private readonly ICollection<Driver> _drivers;
    private Race _race;
    private RaceWeekendSession _session;
    
    private readonly ICollection<RateRange> _rateRanges = new List<RateRange>();
    private readonly ICollection<RaceStats> _raceStats = new List<RaceStats>();
    private readonly ICollection<QualifyingResults> _qualifyingResults = new List<QualifyingResults>();
    private readonly ICollection<RaceResults> _raceResults = new List<RaceResults>();

    private int _endingRange;
    private int _currentLap;

    public RaceWeekend(DataContext dataContext)
    {
        _dataContext = dataContext;
        _drivers = _dataContext.GetAllDrivers();
    }

    public async void Initialization()
    {
        _race = _dataContext.GetRaceByName("Bluegreen Vacations Duel 1 at DAYTONA");
        _session = RaceWeekendSession.Race;
        _currentLap = 1;
        
        Setup();
    }

    private void Setup()
    {
        var startingRange = 0;
        
        foreach (var driver in _drivers)
        {
            var rateRange = new RateRange(driver, _race.Track.Type, startingRange);
            startingRange = rateRange.EndingRange + 1;
            _rateRanges.Add(rateRange);

            switch (_session)
            {
                case RaceWeekendSession.Qualifying:
                    _qualifyingResults.Add(new QualifyingResults(_race, driver));
                    break;
                case RaceWeekendSession.Race:
                    _raceStats.Add(new RaceStats(_race, driver));
                    _raceResults.Add(new RaceResults(_race, driver));
                    break;
                case RaceWeekendSession.Practice:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        _endingRange = startingRange;
    }

    private void Race()
    {
        const int averagePositionChange = 6;
        const int averageLapsUnderCaution = 4;
        
        while (_currentLap <= _race.Laps)
        {
            var lastPosition = DetermineLastPosition();
            var floorPosition = lastPosition - averagePositionChange;
            
            Console.WriteLine($"********** Processing lap {_currentLap} **********");

            if (_currentLap == 1)
            {
                CalculateLap1Positions();
                CalculatePostLapStats();
            }
            else
            {
                var positionChanges = new List<int>();
                var driversNotOnLeadLap = new List<Driver>();
                RepopulateRanges();
                
                foreach (var rateRange in _rateRanges)
                {
                    var raceStats = _raceStats.First(rs => rs.Driver.Equals(rateRange.Driver));
                    
                    if (!raceStats.IsRunning) continue;

                    if (raceStats.TotalLapCount == _currentLap - 1)
                    {
                        CalculateLeadLapPosition(rateRange, raceStats, averagePositionChange, positionChanges, floorPosition, lastPosition);
                    }
                    else
                    {
                        driversNotOnLeadLap.Add(raceStats.Driver);
                    }
                }

                if (driversNotOnLeadLap.Count > 1)
                {
                    // process non lead lap drivers
                }
                else if (driversNotOnLeadLap.Count == 1)
                {
                    var raceStats = _raceStats.First(rs => rs.Driver.Equals(driversNotOnLeadLap[0]));
                    raceStats.DNFOdds += RNG.RollDoubleRange(.001, .002);
                }
                
                CalculatePostLapStats();
                
                foreach (var raceStats in _raceStats)
                {
                    if (raceStats.IsRunning && raceStats.DNFOdds > .1)
                    {
                        // process wreck chances
                    } 
                }
            }
        }
    }

    private int DetermineLastPosition()
    {
        var lastPosition = _raceStats.Count;

        foreach (var raceStats in _raceStats)
        {
            if (!raceStats.IsRunning)
            {
                lastPosition -= 1;
            }
        }

        return lastPosition;
    }

    private void CalculateLap1Positions()
    {
        var runningPosition = 1;
        var nonRangeHits = 0;
        
        foreach (var rateRange in _rateRanges)
        {
            var randomNumber = RNG.RollIntRange(0, _endingRange);
            var raceStats = _raceStats.First(rs => rs.Driver.Equals(rateRange.Driver));
            
            /* Any driver that has thier rate range hit will get first pickings at the high end of the positions.
                Use the nonRangeHits to keep track of how many drivers don't get their ranges hit. */
            if (rateRange.StartingRange <= randomNumber && randomNumber <= rateRange.EndingRange)
            {
                if (runningPosition == 1)
                {
                    raceStats.DNFOdds += RNG.RollDoubleRange(0, .001);
                }
                else
                {
                    raceStats.DNFOdds += RNG.RollDoubleRange(0, .002);
                }

                raceStats.UpdateLap1Positions(runningPosition);
                runningPosition += 1;
            }
            else
            {
                raceStats.DNFOdds += RNG.RollDoubleRange(.002, .003);
                nonRangeHits += 1;
            }
        }

        // For any driver that doesn't have their range hit, we'll assign them a random position based on what's left
        var positions = new List<int>();
        for (int i = 0; i < nonRangeHits; i++)
        {
            positions.Add(runningPosition);
            runningPosition += 1;
        }
        
        foreach (var rateRange in _rateRanges)
        {
            var raceStats = _raceStats.First(rs => rs.Driver.Equals(rateRange.Driver));

            if (raceStats.CurrentPosition == 0)
            {
                var position = RNG.RollFromList(positions);
                raceStats.UpdateLap1Positions(position);
                positions.Remove(position);
            }
        }
    }

    private void CalculatePostLapStats(bool cautionLap = false)
    {
        foreach (var raceStats in _raceStats)
        {
            raceStats.CalculatePostLapStats(_currentLap, cautionLap);
        }
    }

    private void RepopulateRanges(int stageSwitch = 0)
    {
        var placementRange = 0;

        foreach (var driver in _drivers)
        {
            var raceStats = _raceStats.First(rs => rs.Driver.Equals(driver));

            if (!raceStats.IsRunning) continue;
            
            var rateRange = _rateRanges.First(rr => rr.Driver.Equals(driver));
            var cautionsCausedPenalty = 0;
            int bonus;
                
            rateRange.StartingRange = placementRange;

            if (raceStats.CautionsCaused > 0)
            {
                cautionsCausedPenalty = raceStats.CautionsCaused * -250;
            }

            if (raceStats.TotalLapCount < _currentLap)
            {
                var lapDifference = _currentLap - raceStats.TotalLapCount;
                var lapDownPenalty = lapDifference * -100;
                bonus = lapDownPenalty + cautionsCausedPenalty;
            }
            else if (stageSwitch != -1)
            {
                var stageBonus = stageSwitch switch
                {
                    1 => raceStats.Stage1Position,
                    2 => raceStats.Stage2Position,
                    _ => throw new ArgumentOutOfRangeException()
                };

                bonus = stageBonus + cautionsCausedPenalty;
            }
            else
            {
                if (raceStats.LapLedCount == 0)
                {
                    bonus = raceStats.LapLedCount + cautionsCausedPenalty;
                } else if (raceStats.Top15LapCount != 0)
                {
                    bonus = raceStats.Top15LapCount + cautionsCausedPenalty;
                }
                else
                {
                    bonus = 0;
                }
            }

            placementRange += CalculateRange(driver, bonus);
                
            var positionBonus = PositionBonus.Get(raceStats.CurrentPosition);
            var bonusRange = (int)Math.Floor((placementRange * positionBonus) + placementRange);

            if (rateRange.EndingRange <= bonusRange)
            {
                rateRange.EndingRange = bonusRange;
            }
            else
            {
                var endingRange = rateRange.EndingRange;
                rateRange.EndingRange = (int)Math.Floor(endingRange * positionBonus) + endingRange;
            }

            placementRange = rateRange.EndingRange++;
        }

        _endingRange = placementRange;
    }

    private int CalculateRange(Driver driver, int bonus)
    {
        var driverResult = Math.Pow(driver.GetTrackRating(_race.Track.Type), DriverFactor);
        var teamResult = Math.Pow((driver.Team.EquipmentRating + driver.Team.PersonnelRating) / 2, TeamFactor);
        var bonusResult = bonus * 50;
        
        return (int)Math.Round((driverResult * teamResult + bonusResult) / 100);
    }

    private void CalculateLeadLapPosition(RateRange rateRange, RaceStats raceStats, int averagePositionChange, List<int> positionChanges, int floorPosition, int lastPosition)
    {
        var magicNumber = RNG.RollIntRange(0, _endingRange);
        var currentPosition = raceStats.CurrentPosition;
        
        if (rateRange.StartingRange <= magicNumber && magicNumber <= rateRange.EndingRange)
        {
            var randomPosition = currentPosition <= averagePositionChange
                ? RNG.RollIntRange(1, currentPosition)
                : RNG.RollIntRange(currentPosition - averagePositionChange, currentPosition);

            if (randomPosition == 1)
            {
                if (!positionChanges.Contains(randomPosition))
                {
                    raceStats.DNFOdds += RNG.RollDoubleRange(0, .001);
                    positionChanges.Add(1);
                }
                else
                {
                    raceStats.DNFOdds += RNG.RollDoubleRange(0, .0015);

                    for (var i = 0; i < randomPosition; i++)
                    {
                        randomPosition = currentPosition <= averagePositionChange
                            ? RNG.RollIntRange(2, currentPosition)
                            : RNG.RollIntRange(currentPosition - averagePositionChange, currentPosition);
                    }
                }
            }
            else
            {
                raceStats.DNFOdds += RNG.RollDoubleRange(0, .002);
            }

            raceStats.CurrentPosition = randomPosition;
            
            ShiftDrivers(rateRange.Driver, currentPosition, randomPosition, ShiftDirection.Up);
        }
        else
        {
            var previousPosition = raceStats.CurrentPosition;
            raceStats.DNFOdds += RNG.RollDoubleRange(.002, .002);
            var randomPosition = currentPosition >= floorPosition ?
                RNG.RollIntRange(previousPosition, lastPosition) :
                RNG.RollIntRange(currentPosition, currentPosition + averagePositionChange);

            raceStats.CurrentPosition = randomPosition;
            ShiftDrivers(rateRange.Driver, previousPosition, randomPosition, ShiftDirection.Down);
        }
    }

    private void ShiftDrivers(Driver driver, int oldPosition, int newPosition, ShiftDirection direction)
    {
        while (oldPosition != newPosition)
        {
            foreach (var raceStats in _raceStats)
            {
                if (raceStats.Driver != driver && raceStats.CurrentPosition == newPosition)
                {
                    if (direction == ShiftDirection.Up)
                        newPosition += 1;
                    else
                        newPosition -= 1;

                    raceStats.CurrentPosition = newPosition;
                    driver = raceStats.Driver;

                    if (!raceStats.IsRunning)
                        raceStats.FinishPosition = newPosition;
                    
                    break;
                }
                    
            }
        }
    }
}