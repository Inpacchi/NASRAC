namespace NASRAC.Models.Game.Entities;

public class Schedule
{
    public int Id { get; set; }
    public int Year { get; set; }
    public Series Series { get; set; }
    public Race Race { get; set; }
}