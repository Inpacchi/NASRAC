using Microsoft.AspNetCore.Mvc;
using NASRAC.Services.Game.Interfaces;

namespace NASRAC.API.Game.Controllers;

public class GameController : BaseApiController
{
    private readonly IGameService GameService;

    public GameController(IGameService gameService)
    {
        GameService = gameService;
    }
    
    [HttpPost]
    public async Task RunRace()
    {
        
    }
}