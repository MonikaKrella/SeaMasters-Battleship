using System.Collections.Concurrent;
using SeaMasters.Interfaces;
using SeaMasters.Models.ClientData;

namespace SeaMasters.Models;

public class GameManager : IGameManager
{
    private readonly ConcurrentDictionary<string, IGame> games = new();

    public InitialGameDTO PrepareGame(string firstPlayerName, string secondPlayerName)
    {
        var newGame = new BotGame();
        var players = newGame.PrepareGame(firstPlayerName, secondPlayerName);
        var id = Guid.NewGuid().ToString();
        games.TryAdd(id, newGame);
        return new InitialGameDTO(id, players);
    }

    public List<TurnReport> MakeTurn(string id)
    {
        if (!games.ContainsKey(id))
        {
            return null;
        }

        var clientGame = games[id];
        var reportFromTurn = clientGame.RunTurn();
        if (clientGame.IsGameOver)
        {
            games.TryRemove(id, out _);
        }
        return reportFromTurn;
    }
}