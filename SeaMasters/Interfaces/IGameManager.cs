namespace SeaMasters.Interfaces;

public interface IGameManager
{
    Player[] PrepareGame(string firstPlayerName, string secondPlayerName);
    List<TurnReport> RunTurn();
}