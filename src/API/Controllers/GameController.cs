using Microsoft.AspNetCore.Mvc;
using NASRAC.API.Controllers.Base;
using NASRAC.Core.DTOs;
using NASRAC.Core.Interfaces;
using NASRAC.Core.Services.Interfaces;
using Newtonsoft.Json;

namespace NASRAC.API.Controllers;

public class GameController(IGameService gameService) : BaseApiController
{
    [HttpPost("RunRace")]
    public Task<ActionResult> RunRace()
    {
        gameService.RunRace();

        return Task.FromResult<ActionResult>(Ok());
    }
    [HttpGet("GetRaceLog")] 
    public List<RaceLogDto> GetRaceLog(int raceId)
    {
        var raceLogs = gameService.GetRaceLogs(raceId);
        return raceLogs;
    }
}