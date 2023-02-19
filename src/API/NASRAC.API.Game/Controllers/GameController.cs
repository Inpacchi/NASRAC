using Microsoft.AspNetCore.Mvc;
using NASRAC.Services.Game.Interfaces;

namespace NASRAC.API.Game.Controllers;

public class GameController : BaseApiController
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }
    
    [HttpPost]
    public async Task<ActionResult> Run()
    {
        _gameService.RunRace();

        return Ok();
    }
}