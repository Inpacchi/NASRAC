using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.TeamEntities;

namespace NASRAC.Models.Game.Entities;

public class Loan
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public double TotalAmountLoaned { get; set; }
    
    [Required]
    public double TotalAmountPaid { get; set; }
    
    [Required]
    public DateTime MaturityDate { get; set; }
    
    [Required]
    public Team Lender { get; set; }
    
    [Required]
    public Team Borrower { get; set; }
}