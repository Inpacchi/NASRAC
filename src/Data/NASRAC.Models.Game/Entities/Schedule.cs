namespace NASRAC.Models.Game.Entities;

public class Schedule
{
    public int Year { get; set; }
    public Series Series { get; set; }
    public Race Race { get; set; }
}