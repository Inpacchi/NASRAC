using NASRAC.Core.Entities.Game;

namespace NASRAC.Core.DTOs;

public class RaceLogDto
{
    #region StatsBase
    public int Id { get; set; }
    public RaceDto Race { get; set; }
    public DriverDto Driver { get; set; }
    public double FastestTime { get; set; }
    public double TopSpeed { get; set; }
    #endregion
    
    #region SessionStatsBase
    public double AveragePosition { get; set; }
    public double AverageRunningPosition { get; set; }
    public int Top15LapCount { get; set; }
    public double Top15LapPercentage { get; set; }
    public int LapLedCount { get; set; }
    public double LapLedPercentage { get; set; }
    public int CautionLapCount { get; set; }
    public double CautionLapPercentage { get; set; }
    public int CautionsCaused { get; set; }
    public int TotalLapCount { get; set; }
    #endregion
    
    #region RaceLog
    public double DriverRating { get; set; }
    public double DnfOdds { get; set; }
    public bool IsRunning { get; set; }
    public int CurrentPosition { get; set; }
    #endregion
}