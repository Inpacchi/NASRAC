using NASRAC.Models.Game.BaseEntities;
using NASRAC.Services.Common.Enums;

namespace NASRAC.Models.Game.Entities;

public class DriverContract : BaseContract
{
    public ContractType Type = ContractType.Driver;
    public GameObject Benefactor { get; set; }
    public GameObject Beneficiary { get; set; }

    public double Length()
    {
        return (EndDate.Date - StartDate.Date).TotalDays / 365;
    }
}