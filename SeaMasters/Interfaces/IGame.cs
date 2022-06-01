namespace SeaMasters.Interfaces;

public interface IGame
{
    bool IsGameOver { get; }
    Player[] PrepareGame(string firstPlayerName, string secondPlayerName);
    List<TurnReport> RunTurn();
}