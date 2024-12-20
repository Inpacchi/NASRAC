﻿using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Models.Game.DriverEntities;
using NASRAC.Core.Models.Game.RaceEntities;
using NASRAC.Core.Models.Game.Stats.Interfaces;

namespace NASRAC.Core.Models.Game.Stats.Abstractions;

/// <summary>
/// Base implementation of the Stats class that all Stats-related classes should implement
/// </summary>
public abstract class BaseStats : IBaseStats
{
    protected BaseStats()
    {
    }

    protected BaseStats(Race race, Driver driver)
    {
        Race = race;
        RaceId = race.Id;
        Driver = driver;
        DriverId = driver.Id;
    }
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int RaceId { get; set; }
    
    public Race Race { get; set; }
    
    [Required]
    public int DriverId { get; set; }
    
    public Driver Driver { get; set; }
    
    /// <summary>
    /// Fastest lap time achieved of the session
    /// </summary>
    [Required]
    public double FastestTime { get; set; }
    
    /// <summary>
    /// Fastest speed achieved of the session
    /// </summary>
    [Required]
    public double TopSpeed { get; set; }
}