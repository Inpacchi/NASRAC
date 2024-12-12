using System.ComponentModel.DataAnnotations;

namespace NASRAC.Core.Entities.Game;

public class Loan
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public double TotalAmountLoaned { get; set; }
    
    [Required]
    public double TotalAmountPaid { get; set; }
    
    /// <summary>
    /// The principal due date of the loan, or when all money should be paid back by
    /// </summary>
    [Required]
    public DateTime MaturityDate { get; set; }
    
    [Required]
    public double InterestRate { get; set; }
    
    [Required]
    public int LendingTeamId { get; set; }
    
    [Required]
    public int BorrowingTeamId { get; set; }
}