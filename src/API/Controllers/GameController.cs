using Microsoft.AspNetCore.Mvc;
using NASRAC.Core.Interfaces;
using NASRAC.Core.Models.Game.Stats;

namespace NASRAC.API.Controllers;

public class GameController(IGameService gameService) : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult> Run()
    {
        //gameService.RunRace();

        return Ok();
    }

    [HttpGet("GetRaceLog")]
    public async Task<ActionResult<RaceLog>> GetRaceLog(int raceId)
    {
        //return gameService.GetRaceLog(raceId);
        return Ok();
    }
}