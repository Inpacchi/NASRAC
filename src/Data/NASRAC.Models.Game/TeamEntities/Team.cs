using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Models.Game.JoinEntities;
using NASRAC.Models.WebApp.Entities;

namespace NASRAC.Models.Game.TeamEntities;

/// <summary>
/// Team entity
/// </summary>
public class Team
{
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Name of the team
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    /// Measure of the team's equipment quality
    /// </summary>
    [Required]
    public double EquipmentRating { get; set; }
    
    /// <summary>
    /// Measure of the team's personnel quality
    /// </summary>
    [Required]
    public double PersonnelRating { get; set; }
    
    /// <summary>
    /// Measure of the team's current performance
    /// </summary>
    [Required]
    public double PerformanceRating { get; set; }
    
    /// <summary>
    /// Measure of the team's ratings overall (average of the individual ratings)
    /// </summary>
    [Required]
    public double OverallRating { get; set; }
    
    /// <summary>
    /// Owner of the team
    /// </summary>
    public AppUser Owner { get; set; }
    
    /// <summary>
    /// Team manufacturers
    /// </summary>
    public ICollection<TeamManufacturers> TeamManufacturers { get; set; }

    public ICollection<Car> Cars { get; set; }
    public ICollection<Driver> Drivers { get; set; }

    // TODO: Implement
    public TeamFinancials GetLatestFinancials()
    {
        throw new NotImplementedException();
    }
}