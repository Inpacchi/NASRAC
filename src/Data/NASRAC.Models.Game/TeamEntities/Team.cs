using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Models.WebApp.Entities;

namespace NASRAC.Models.Game.TeamEntities;

public class Team
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public Manufacturer Manufacturer { get; set; }
    
    [Required]
    public double EquipmentRating { get; set; }
    
    [Required]
    public double PersonnelRating { get; set; }
    
    [Required]
    public double PerformanceRating { get; set; }
    
    [Required]
    public double OverallRating { get; set; }
    
    public AppUser Owner { get; set; }

    public ICollection<Car> Cars { get; set; }
    public ICollection<Driver> Drivers { get; set; }

    // TODO: Implement
    public TeamFinancials GetLatestFinancials()
    {
        throw new NotImplementedException();
    }
}