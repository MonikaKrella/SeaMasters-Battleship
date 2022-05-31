using SeaMasters.Models;

namespace SeaMasters;

public interface IGameManager
{
    Player[] PrepareGame(string player1Name, string player2Name);
    List<PlayersRaport> RunTurn();
    HashSet<Coordinates> GetNeighbours(int x, int y);
}