using System.ComponentModel.DataAnnotations;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class Track
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Location { get; set; }
    
    [Required]
    public double Length { get; set; }
    
    [Required]
    public TrackType Type { get; set; }
}