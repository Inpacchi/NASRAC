using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.TeamEntities;

namespace NASRAC.Models.Game.Entities;

public class Car
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public int Number { get; set; }
    
    [Required]
    public Manufacturer Manufacturer { get; set; }
    
    [Required]
    public Team Team { get; set; }
}