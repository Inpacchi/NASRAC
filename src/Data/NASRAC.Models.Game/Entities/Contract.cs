using NASRAC.Models.Game.BaseEntities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class Contract
{
    public int Amount { get; set; }
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ContractType Type { get; }
    public GameObject Benefactor { get; set; }
    public GameObject Beneficiary { get; set; }

    public double Length()
    {
        return (EndDate.Date - StartDate.Date).TotalDays / 365;
    }
}