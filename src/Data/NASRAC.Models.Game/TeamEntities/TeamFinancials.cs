using System.ComponentModel.DataAnnotations;

namespace NASRAC.Models.Game.TeamEntities;

public class TeamFinancials
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public Team Team { get; set; }
    
    [Required]
    public double Balance { get; set; }
    
    [Required]
    public DateTime StatementDate { get; set; }
}