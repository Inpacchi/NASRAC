namespace NASRAC.Models.Game.Entities;

public class TeamFinancials
{
    public Team Team { get; set; }
    public double Balance { get; set; }
    public DateTime StatementDate { get; set; }
}