using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using SeaMasters.Interfaces;
using SeaMasters.Models.ClientData;

namespace SeaMasters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleshipController : ControllerBase
    {
        private readonly IGameManager gameManager;
        private readonly ILogger<BattleshipController> logger;

        public BattleshipController(IGameManager argGameManager, ILogger<BattleshipController> argLogger)
        {
            gameManager = argGameManager;
            logger = argLogger;
        }

        [HttpPost]
        public async Task<ActionResult<InitialGameDTO>> PrepareGame([FromBody]CreatePlayersDTO playersDto)
        {
            try
            {
                var initialGameData = gameManager.PrepareGame(playersDto.FirstPlayerName, playersDto.SecondPlayerName);
                return initialGameData;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("run-turn")]
        public async Task<ActionResult<List<TurnReport>>> RunTurn(string gameId)
        {
            try
            {
                var report = gameManager.MakeTurn(gameId);
                if (report != null)
                {
                    return report;
                }

                return NotFound("Not found game");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500);
            }
            
        }
    }
}