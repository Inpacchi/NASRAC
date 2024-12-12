using System.ComponentModel.DataAnnotations;

namespace NASRAC.Core.Entities.Game;

/// <summary>
/// Season entity
/// </summary>
public class Season
{
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Name of the season, e.g. 2022-23 for seasons that cross into the next year
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    /// Start date of the season
    /// </summary>
    [Required]
    public DateOnly StartDate { get; set; }
    
    /// <summary>
    /// End date of the season
    /// </summary>
    [Required]
    public DateOnly EndDate { get; set; }
    
    /// <summary>
    /// Series ID for the season
    /// </summary>
    [Required]
    public int SeriesId { get; set; }
    
    /// <summary>
    /// Series for the season
    /// </summary>
    [Required]
    public Series Series { get; set; }
    
    /// <summary>
    /// Collection of the scheduled events for the season
    /// </summary>
    public ICollection<Schedule> Schedules { get; set; }
}