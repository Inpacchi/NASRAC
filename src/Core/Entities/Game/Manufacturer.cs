using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Enums;

namespace NASRAC.Core.Entities.Game;

public class Manufacturer
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public VehicleType VehicleType { get; set; }
    
    public virtual List<TeamManufacturers>? TeamManufacturers { get; set; }
    
    public virtual List<Car>? Cars { get; set; } 
}