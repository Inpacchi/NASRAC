using System.ComponentModel.DataAnnotations;
using NASRAC.Models.Game.BaseEntities;
using NASRAC.Models.Game.Entities;

namespace NASRAC.Models.Game.TeamEntities;

public class ManufacturerContract : BaseContract
{
    [Required]
    public Team Team { get; set; }
    
    [Required]
    public Manufacturer Manufacturer { get; set; }
}