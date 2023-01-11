namespace NASRAC.Models.Game.Entities;

public class Loan
{
    public double TotalAmountLoaned { get; set; }
    public double TotalAmountPaid { get; set; }
    public DateTime MaturityDate { get; set; }
    public Team Lender { get; set; }
    public Team Borrower { get; set; }
}