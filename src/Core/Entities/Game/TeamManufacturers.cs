using System.ComponentModel.DataAnnotations;

namespace NASRAC.Core.Entities.Game;

public class TeamManufacturers
{
    [Key]
    public int Id { get; set; }
    
    public int ManufacturerId { get; set; }
    
    public int TeamId { get; set; }
}