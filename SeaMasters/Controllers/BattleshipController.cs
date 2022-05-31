using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SeaMasters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleshipController : ControllerBase
    {
        private IGameManager gameManager;

        private readonly ILogger<BattleshipController> _logger;

        public BattleshipController(IGameManager argGameManager, ILogger<BattleshipController> argLogger)
        {
            gameManager = argGameManager;
            _logger = argLogger;
        }

        [HttpPost]
        public async Task<ActionResult<Player[]>> PrepareGame([FromBody]CreatePlayersDTO playersDto)
        {
            try
            {
                var players = gameManager.PrepareGame(playersDto.name1, playersDto.name2);
                return players;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("test")]
        public JsonResult GetFieldsAround(int x, int y)
        {
            var neighbours = gameManager.GetNeighbours(x, y);
            return new JsonResult(neighbours);
        }

        [HttpGet("run-turn")]
        public async Task<ActionResult<List<PlayersRaport>>> StartGame()
        {
            var raport = gameManager.RunTurn();
            return raport;
        }
    }
}