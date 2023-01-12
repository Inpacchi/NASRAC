using System.ComponentModel.DataAnnotations;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class Manufacturer
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public VehicleType VehicleType { get; set; }
}