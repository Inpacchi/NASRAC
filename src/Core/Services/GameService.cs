using NASRAC.Core.Interfaces;
using NASRAC.Core.Models.Game.Stats;

namespace NASRAC.Core.Services;

public class GameService(IDriverRepository driverRepository) : IGameService
{
}