using System.ComponentModel.DataAnnotations;

namespace NASRAC.Models.Game.BaseEntities;

public abstract class BaseContract
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public int Amount { get; set; }
    
    [Required]
    public DateTime DateSigned { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }

    public double Length()
    {
        return (EndDate.Date - StartDate.Date).TotalDays / 365;
    }
}