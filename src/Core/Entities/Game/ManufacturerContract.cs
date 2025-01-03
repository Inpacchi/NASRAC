﻿using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Entities.Game.Base;

namespace NASRAC.Core.Entities.Game;

/// <summary>
/// Manufacturer contract for teams
/// </summary>
public class ManufacturerContract : ContractBase
{
    /// <summary>
    /// ID for the team associated with the contract
    /// </summary>
    [Required]
    public int TeamId { get; set; }
    
    /// <summary>
    /// Team associated with the contract
    /// </summary>
    [Required]
    public Team Team { get; set; }
    
    /// <summary>
    /// ID for the manufacturer associated with the contract
    /// </summary>
    [Required]
    public int ManufacturerId { get; set; }
    
    /// <summary>
    /// Manufacturer associated with the contract
    /// </summary>
    [Required]
    public Manufacturer Manufacturer { get; set; }
}