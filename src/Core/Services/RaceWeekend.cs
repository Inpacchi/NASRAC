﻿using NASRAC.Core.Entities;
using NASRAC.Core.Entities.Game;
using NASRAC.Core.Enums;
using NASRAC.Core.Interfaces;
using NASRAC.Core.Helpers;

namespace NASRAC.Core.Services;

public class RaceWeekend(IDriverRepository driverRepository, IRaceRepository raceRepository) : IRaceWeekend
{
    private const double DriverFactor = 1.25;
    private const double TeamFactor = 1.40;
    
    private readonly ICollection<Driver> _drivers = driverRepository.GetAllDrivers();
    private Race _race;
    private RaceWeekendSession _session;
    
    private readonly ICollection<RateRange> _rateRanges = new List<RateRange>();
    private readonly ICollection<RaceLog> _raceLogs = new List<RaceLog>();
    private readonly ICollection<QualifyingStats> _qualifyingStats = new List<QualifyingStats>();
    private readonly ICollection<SessionResults> _sessionResults = new List<SessionResults>();

    private int _endingRange;
    private int _currentLap;

    public void Initialize()
    {
        _race = raceRepository.GetRaceByName("Bluegreen Vacations Duel 1 at DAYTONA");
        _session = RaceWeekendSession.Race;
        _currentLap = 1;
        
        Setup();
        Race();
        raceRepository.SaveChanges();
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
                    var qualifyingStats = new QualifyingStats(_race, driver);
                    raceRepository.AddQualifyingStats(qualifyingStats);
                    _qualifyingStats.Add(qualifyingStats);
                    break;
                case RaceWeekendSession.Race:
                    var raceLog = new RaceLog(_race, driver);
                    raceRepository.AddRaceLog(raceLog);
                    _raceLogs.Add(raceLog);

                    var sessionResults = new SessionResults(_race, driver);
                    raceRepository.AddSessionResults(sessionResults);
                    _sessionResults.Add(sessionResults);
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
                    var raceLog = _raceLogs.First(rs => rs.Driver.Equals(rateRange.Driver));
                    
                    if (!raceLog.IsRunning) continue;

                    if (raceLog.TotalLapCount == _currentLap - 1)
                    {
                        CalculateLeadLapPosition(rateRange, raceLog, averagePositionChange, positionChanges, floorPosition, lastPosition);
                    }
                    else
                    {
                        driversNotOnLeadLap.Add(raceLog.Driver);
                    }
                }

                if (driversNotOnLeadLap.Count > 1)
                {
                    // process non lead lap drivers
                }
                else if (driversNotOnLeadLap.Count == 1)
                {
                    var raceLog = _raceLogs.First(rs => rs.Driver.Equals(driversNotOnLeadLap[0]));
                    raceLog.DnfOdds += RandomService.RollDoubleRange(.001, .002);
                }
                
                CalculatePostLapStats();
                
                foreach (var raceLog in _raceLogs)
                {
                    if (raceLog.IsRunning && raceLog.DnfOdds > .1)
                    {
                        // process wreck chances
                    } 
                }
            }

            Console.WriteLine($"********** End of lap {_currentLap} **********");
            _currentLap++;
            Thread.Sleep(3000);
        }
        
        
        // process post race
        CalculatePostRaceStats(_race.Laps);
    }

    private int DetermineLastPosition()
    {
        var lastPosition = _raceLogs.Count;

        foreach (var raceLog in _raceLogs)
        {
            if (!raceLog.IsRunning)
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
            var randomNumber = RandomService.RollIntRange(0, _endingRange);
            var raceLog = _raceLogs.First(rs => rs.Driver.Equals(rateRange.Driver));
            
            /* Any driver that has their rate range hit will get first pickings at the high end of the positions.
                Use the nonRangeHits to keep track of how many drivers don't get their ranges hit. */
            if (rateRange.StartingRange <= randomNumber && randomNumber <= rateRange.EndingRange)
            {
                raceLog.GenerateDnfOdds(0, runningPosition == 1 ? .001 : .002);
                raceLog.CurrentPosition = runningPosition;
                runningPosition += 1;
            }
            else
            {
                raceLog.GenerateDnfOdds(.002, .003);
                nonRangeHits += 1;
            }
        }

        // For any driver that doesn't have their range hit, we'll assign them a random position based on what's left
        var positions = new List<int>();
        for (var i = 0; i < nonRangeHits; i++)
        {
            positions.Add(runningPosition);
            runningPosition += 1;
        }
        
        foreach (var rateRange in _rateRanges)
        {
            var raceLog = _raceLogs.First(rs => rs.Driver.Equals(rateRange.Driver));

            if (raceLog.CurrentPosition == 0)
            {
                var position = RandomService.RollFromList(positions);
                raceLog.CurrentPosition = position;
                positions.Remove(position);
            }
            
            var sessionResults = _sessionResults.First(sr => sr.Driver.Equals(rateRange.Driver));
            sessionResults.StartPosition = raceLog.CurrentPosition;
        }
        
        
    }

    private void CalculatePostLapStats(bool cautionLap = false)
    {
        foreach (var raceLog in _raceLogs)
        {
            raceLog.CalculatePostLapStats(_currentLap, cautionLap);
            
            var sessionResults = _sessionResults.First(sr => sr.Driver.Equals(raceLog.Driver));
            sessionResults.CalculatePositions(raceLog.CurrentPosition);
            
            // if (_currentLap != _race.Laps)
            //     _dataContext.Clone(raceLog, new RaceLog());
        }
    }

    private void CalculatePostRaceStats(int laps)
    {
        foreach (var sessionResults in _sessionResults)
        {
            var raceLog = _raceLogs.First(rs => rs.Driver.Equals(sessionResults.Driver));
            sessionResults.CalculatePostSessionStats(raceLog);
        }
    }

    private void RepopulateRanges(int stageSwitch = 0)
    {
        Console.WriteLine("Repopulating ranges");
        var placementRange = 0;

        foreach (var driver in _drivers)
        {
            Console.WriteLine("Now processing ranges for " + driver.Name);
            var raceLog = _raceLogs.First(rl => rl.Driver.Equals(driver));
            
            if (!raceLog.IsRunning) continue;
            
            var rateRange = _rateRanges.First(rr => rr.Driver.Equals(driver));
            var cautionsCausedPenalty = 0;
            int bonus;
                
            Console.WriteLine("Old Rate Range Start: " + rateRange.StartingRange);
            rateRange.StartingRange = placementRange;
            Console.WriteLine("New Rate Range Start: " + rateRange.StartingRange);

            if (raceLog.CautionsCaused > 0)
            {
                cautionsCausedPenalty = raceLog.CautionsCaused * -250;
            }

            if (raceLog.TotalLapCount < _currentLap)
            {
                var lapDifference = _currentLap - raceLog.TotalLapCount;
                var lapDownPenalty = lapDifference * -100;
                bonus = lapDownPenalty + cautionsCausedPenalty;
            }
            else if (stageSwitch != -1)
            {
                var sessionResults = stageSwitch switch
                {
                    1 => _sessionResults.First(sr => sr.Driver.Equals(driver) && sr.SessionType == SessionType.Stage1),
                    2 => _sessionResults.First(sr => sr.Driver.Equals(driver) && sr.SessionType == SessionType.Stage2),
                    _ => throw new ArgumentOutOfRangeException(nameof(stageSwitch), stageSwitch, null)
                };

                bonus = sessionResults.FinishPosition + cautionsCausedPenalty;
            }
            else
            {
                if (raceLog.LapLedCount == 0)
                {
                    bonus = raceLog.LapLedCount + cautionsCausedPenalty;
                } else if (raceLog.Top15LapCount != 0)
                {
                    bonus = raceLog.Top15LapCount + cautionsCausedPenalty;
                }
                else
                {
                    bonus = 0;
                }
            }

            placementRange += CalculateRange(driver, bonus);
                
            var positionBonus = PositionBonus.Get(raceLog.CurrentPosition);
            var bonusRange = (int)Math.Floor((placementRange * positionBonus) + placementRange);

            Console.WriteLine("Old Rate Range End: " + rateRange.EndingRange);
            if (rateRange.EndingRange <= bonusRange)
            {
                rateRange.EndingRange = bonusRange;
            }
            else
            {
                var endingRange = rateRange.EndingRange;
                rateRange.EndingRange = (int)Math.Floor(endingRange * positionBonus) + endingRange;
            }
            Console.WriteLine("New Rate Range End: " + rateRange.EndingRange);

            placementRange = rateRange.EndingRange++;
            Console.WriteLine("Current Placement Range: " + placementRange);
        }

        _endingRange = placementRange;
        Console.WriteLine("Ending Range: " + _endingRange);
    }

    private int CalculateRange(Driver driver, int bonus)
    {
        var driverResult = Math.Pow(driver.GetTrackRating(_race.Track.Type), DriverFactor);
        var teamResult = Math.Pow((driver.Team.EquipmentRating + driver.Team.PersonnelRating) / 2, TeamFactor);
        var bonusResult = bonus * 50;
        
        return (int)Math.Round((driverResult * teamResult + bonusResult) / 100);
    }

    private void CalculateLeadLapPosition(RateRange rateRange, RaceLog raceLog, int averagePositionChange, List<int> positionChanges, int floorPosition, int lastPosition)
    {
        var magicNumber = RandomService.RollIntRange(0, _endingRange);
        var currentPosition = raceLog.CurrentPosition;
        
        if (rateRange.StartingRange <= magicNumber && magicNumber <= rateRange.EndingRange)
        {
            var randomPosition = currentPosition <= averagePositionChange
                ? RandomService.RollIntRange(1, currentPosition)
                : RandomService.RollIntRange(currentPosition - averagePositionChange, currentPosition);

            if (randomPosition == 1)
            {
                if (!positionChanges.Contains(randomPosition))
                {
                    raceLog.DnfOdds += RandomService.RollDoubleRange(0, .001);
                    positionChanges.Add(1);
                }
                else
                {
                    raceLog.DnfOdds += RandomService.RollDoubleRange(0, .0015);

                    for (var i = 0; i < randomPosition; i++)
                    {
                        randomPosition = currentPosition <= averagePositionChange
                            ? RandomService.RollIntRange(2, currentPosition)
                            : RandomService.RollIntRange(currentPosition - averagePositionChange, currentPosition);
                    }
                }
            }
            else
            {
                raceLog.DnfOdds += RandomService.RollDoubleRange(0, .002);
            }

            raceLog.CurrentPosition = randomPosition;
            
            ShiftDrivers(rateRange.Driver, currentPosition, randomPosition, ShiftDirection.Up);
        }
        else
        {
            var previousPosition = raceLog.CurrentPosition;
            raceLog.DnfOdds += RandomService.RollDoubleRange(.002, .002);
            var randomPosition = currentPosition >= floorPosition ?
                RandomService.RollIntRange(previousPosition, lastPosition) :
                RandomService.RollIntRange(currentPosition, currentPosition + averagePositionChange);

            raceLog.CurrentPosition = randomPosition;
            ShiftDrivers(rateRange.Driver, previousPosition, randomPosition, ShiftDirection.Down);
        }
    }

    private void ShiftDrivers(Driver driver, int oldPosition, int newPosition, ShiftDirection direction)
    {
        while (oldPosition != newPosition)
        {
            foreach (var raceLog in _raceLogs)
            {
                if (raceLog.Driver != driver && raceLog.CurrentPosition == newPosition)
                {
                    if (direction == ShiftDirection.Up)
                        newPosition += 1;
                    else
                        newPosition -= 1;

                    raceLog.CurrentPosition = newPosition;
                    driver = raceLog.Driver;

                    if (!raceLog.IsRunning)
                    {
                        var sessionResults = _sessionResults.First(sr => sr.Driver.Equals(driver));
                        sessionResults.FinishPosition = newPosition;
                    }
                    
                    break;
                }
                    
            }
        }
    }
}