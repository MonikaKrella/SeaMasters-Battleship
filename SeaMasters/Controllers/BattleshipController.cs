using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<Player[]>> PrepareGame([FromBody]CreatePlayersDTO playersDto)
        {
            try
            {
                var players = gameManager.PrepareGame(playersDto.FirstPlayerName, playersDto.SecondPlayerName);
                return players;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("run-turn")]
        public async Task<ActionResult<List<TurnReport>>> StartGame()
        {
            try
            {
                var report = gameManager.RunTurn();
                return report;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500);
            }
            
        }
    }
}