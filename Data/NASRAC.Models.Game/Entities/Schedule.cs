namespace NASRAC.Models.Game.Entities;

public class Schedule
{
    public int Year { get; set; }
    public int RaceAmount { get; set; }
    public ICollection<Race> Races { get; set; }
}