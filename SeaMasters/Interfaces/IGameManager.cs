namespace SeaMasters;

public interface IGameManager
{
    Player[] PrepareGame(string player1Name, string player2Name);
    List<MoveData> RunTurn();

    //List<MoveData> StartAutoGame();
    Player StartAutoGame();

    HashSet<Coordinates> GetNeighbours(int x, int y);
}