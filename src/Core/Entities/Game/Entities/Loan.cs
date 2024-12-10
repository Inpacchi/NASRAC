using System.ComponentModel.DataAnnotations;
using NASRAC.Core.Models.Game.TeamEntities;

namespace NASRAC.Core.Models.Game.Entities;

/// <summary>
/// Loan entity
/// </summary>
public class Loan
{
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Total amount loaned to the borrower
    /// </summary>
    [Required]
    public double TotalAmountLoaned { get; set; }
    
    /// <summary>
    /// Total amount of the loan paid back
    /// </summary>
    [Required]
    public double TotalAmountPaid { get; set; }
    
    /// <summary>
    /// The principal due date of the loan, or when all money should be paid back by
    /// </summary>
    [Required]
    public DateTime MaturityDate { get; set; }
    
    /// <summary>
    /// Interest rate of the loan
    /// </summary>
    [Required]
    public double InterestRate { get; set; }
    
    [Required]
    public Team Lender { get; set; }
    
    [Required]
    public Team Borrower { get; set; }
}