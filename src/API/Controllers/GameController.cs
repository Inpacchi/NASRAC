using Microsoft.AspNetCore.Mvc;
using NASRAC.API.Controllers.Base;
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
    public string GetRaceLog(int raceId)
    {
        var raceLogs = gameService.GetRaceLogs(raceId);
        var raceLogsSerialized = JsonConvert.SerializeObject(raceLogs,
            Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
        );
        return raceLogsSerialized;
    }
}