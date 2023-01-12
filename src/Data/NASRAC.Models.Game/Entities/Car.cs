using System.ComponentModel.DataAnnotations;

namespace NASRAC.Models.Game.Entities;

public class Car
{
    public int Number { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public Team Team { get; set; }
}