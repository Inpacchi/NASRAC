using System.ComponentModel.DataAnnotations;

namespace NASRAC.Models.Game.BaseEntities;

/// <summary>
/// Base implementation of the Contract class that all Contract classes should implement
/// </summary>
public abstract class BaseContract
{
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Total amount of the contract
    /// </summary>
    [Required]
    public int Amount { get; set; }
    
    /// <summary>
    /// Date the contract was signed
    /// </summary>
    [Required]
    public DateTime DateSigned { get; set; }
    
    /// <summary>
    /// Start date of the contract
    /// </summary>
    [Required]
    public DateTime StartDate { get; set; }
    
    /// <summary>
    /// End date of the contract
    /// </summary>
    [Required]
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Calculates the length of the contract in years
    /// </summary>
    /// <returns>Length of the contract</returns>
    public double Length()
    {
        return (EndDate.Date - StartDate.Date).TotalDays / 365;
    }
}