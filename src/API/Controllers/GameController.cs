using Microsoft.AspNetCore.Mvc;
using NASRAC.Models.Game.Stats;
using Core.Interfaces;

namespace NASRAC.API.Game.Controllers;

public class GameController(IGameService gameService) : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult> Run()
    {
        gameService.RunRace();

        return Ok();
    }

    [HttpGet("GetRaceLog")]
    public async Task<ActionResult<RaceLog>> GetRaceLog(int raceId)
    {
        return gameService.GetRaceLog(raceId);
    }
}