using System.ComponentModel.DataAnnotations;

namespace NASRAC.Core.Entities.Game;

public class TeamFinancials
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int TeamId { get; set; }
    
    [Required]
    public virtual Team? Team { get; set; }
    
    [Required]
    public double Balance { get; set; }
    
    /// <summary>
    /// The last day of the current financial cycle
    /// </summary>
    [Required]
    public DateTime StatementDate { get; set; }
}