using NASRAC.Models.Game.Stats;

namespace Core.Interfaces;

public interface IGameService
{
    public void RunRace();

    public RaceLog GetRaceLog(int raceId);
}