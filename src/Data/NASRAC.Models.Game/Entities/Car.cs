using System.ComponentModel.DataAnnotations;

namespace NASRAC.Models.Game.Entities;

public class Car
{
    public int Number { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public Driver Driver { get; set; }
    public Team Team { get; set; }
    public ICollection<Sponsor> Sponsors { get; set; }
}