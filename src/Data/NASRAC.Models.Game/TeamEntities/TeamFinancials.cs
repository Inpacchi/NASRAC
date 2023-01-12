using System.ComponentModel.DataAnnotations;

namespace NASRAC.Models.Game.TeamEntities;

/// <summary>
/// Team Financials entity
/// </summary>
public class TeamFinancials
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public Team Team { get; set; }
    
    /// <summary>
    /// Current balance of the Team
    /// </summary>
    [Required]
    public double Balance { get; set; }
    
    /// <summary>
    /// The last day of the current financial cycle
    /// </summary>
    [Required]
    public DateTime StatementDate { get; set; }
}