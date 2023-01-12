using System.ComponentModel.DataAnnotations;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class Race
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int Laps { get; set; }
    
    [Required]
    public int Stages { get; set; }
    
    [Required]
    public RaceType Type { get; set; }
    
    [Required]
    public Track Track { get; set; }
}