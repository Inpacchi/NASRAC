using System.ComponentModel.DataAnnotations;

namespace NASRAC.Core.Entities.Game;

public class Car
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int Number { get; set; }
    
    [Required]
    public int ManufacturerId { get; set; }
    
    [Required]
    public int TeamId { get; set; }
}