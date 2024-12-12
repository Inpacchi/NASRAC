using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Entities.WebApp;
using NASRAC.Core.Services;

namespace NASRAC.Core.Entities.Game;

public class Team
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public double EquipmentRating { get; set; }
    
    [Required]
    public double PersonnelRating { get; set; }
    
    [Required]
    public double PerformanceRating { get; set; }
    
    [Required]
    public double OverallRating { get; set; }
    
    public int? OwnerId { get; set; }
    
    public virtual AppUser? Owner { get; set; }

    public virtual List<Car>? Cars { get; set; }
    public virtual List<Driver> Drivers { get; set; } = [];
    
    public virtual List<TeamManufacturers>? TeamManufacturers { get; set; }

    // TODO: Implement
    public TeamFinancials GetLatestFinancials()
    {
        throw new NotImplementedException();
    }

    public static Team GenerateRandomTeam(int id)
    {
        var ratingMean = RandomService.RollDoubleRange(60, 100);
        var ratingStdDev = RandomService.RollDoubleRange(5, 20);
        
        var team = new Team
        {
            Id = id,
            Name = (RandomService.GetRandomColor() + " " + GetRacingTeamName() + " " + GetRandomRacingSuffix()).TrimStart(),
            EquipmentRating = RandomService.Clamp(MathService.GenerateNormal(ratingMean, ratingStdDev), 50, 100, 3),
            PersonnelRating = RandomService.Clamp(MathService.GenerateNormal(ratingMean, ratingStdDev), 50, 100, 3)
        };
        
        team.OverallRating = RandomService.Clamp((team.EquipmentRating + team.PersonnelRating) / 2, 50, 100, 3);

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
        
        return racingTeam[RandomService.RollInt(racingTeam.Count)];
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
        
        return racingSuffixes[RandomService.RollInt(racingSuffixes.Count)];
    }
}