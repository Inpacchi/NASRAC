namespace NASRAC.Models.Game.TeamEntities;

public class TeamFinancials
{
    public int Id { get; set; }
    public Team Team { get; set; }
    public double Balance { get; set; }
    public DateTime StatementDate { get; set; }
}