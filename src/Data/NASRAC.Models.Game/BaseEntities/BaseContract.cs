using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.BaseEntities;

public abstract class BaseContract
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public double Length()
    {
        return (EndDate.Date - StartDate.Date).TotalDays / 365;
    }
}