using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.BaseEntities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class Sponsor
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public double Budget { get; set; }
    
    [Required]
    public PrestigeLevel PrestigeLevel { get; set; }
}