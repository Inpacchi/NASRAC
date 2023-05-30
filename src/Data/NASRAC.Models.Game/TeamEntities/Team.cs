using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.DriverEntities;
using NASRAC.Models.Game.Entities;
using NASRAC.Models.Game.JoinEntities;
using NASRAC.Models.WebApp.Entities;
using NASRAC.Services.Common.Equations;
using NASRAC.Services.Common.Services;

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

    public static Team GenerateRandomTeam(int id)
    {
        var ratingMean = RNG.RollDoubleRange(60, 100);
        var ratingStdDev = RNG.RollDoubleRange(5, 20);
        
        var team = new Team
        {
            Id = id,
            Name = (RNG.GetRandomColor() + " " + GetRacingTeamName() + " " + GetRandomRacingSuffix()).TrimStart(),
            EquipmentRating = RNG.Clamp(Gaussian.GenerateNormal(ratingMean, ratingStdDev), 50, 100, 3),
            PersonnelRating = RNG.Clamp(Gaussian.GenerateNormal(ratingMean, ratingStdDev), 50, 100, 3),
            Drivers = new List<Driver>(),
        };
        
        team.OverallRating = RNG.Clamp((team.EquipmentRating + team.PersonnelRating) / 2, 50, 100, 3);

        return team;
    }

    private static string GetRacingTeamName()
    {
        var racingTeam = new List<string>
        {
            "Apex",
            "Velocity",
            "Burnout",
            "Safari",
            "Nitro",
            "Adrenaline",
            "Finish Line",
            "Mountain",
            "Valley",
            "Ridge",
            "Canyon",
            "Spire",
            "Summit",
            "Peak",
            "Pinnacle",
            "Crest",
            "Crown",
            "Climax",
            "Zenith",
            "Vertex",
            "Sun",
            "Hole",
            "Star",
            "Comet",
            "Galaxy",
            "Universe",
            "Cosmos",
            "Asteroid",
            "Meteor",
            "Planet",
            "Moon"
        };
        
        return racingTeam[RNG.RollInt(racingTeam.Count)];
    }

    private static string GetRandomRacingSuffix()
    {
        var racingSuffixes = new List<string>
        {
            "Enterprises",
            "Motorsports",
            "Racing",
            "Racing Enterprises",
            "Racing Inc.",
            "Racing Incorporated",
            "Racing LLC",
            "Racing Limited",
            "Racing Ltd.",
            "Racing Team Inc.",
            "Racing Team Incorporated",
            "Racing Team LLC",
            "Racing Team Limited",
            "Racing Team Ltd.",
            "Racing Group",
            "Racing Group Inc.",
            "Racing Group Incorporated",
            "Racing Group LLC",
            "Racing Group Limited",
            "Racing Group Ltd.",
        };
        
        return racingSuffixes[RNG.RollInt(racingSuffixes.Count)];
    }
}