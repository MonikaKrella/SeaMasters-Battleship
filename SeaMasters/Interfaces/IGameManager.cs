using SeaMasters.Models.ClientData;

namespace SeaMasters.Interfaces;

public interface IGameManager
{
    InitialGameDTO PrepareGame(string firstPlayerName, string secondPlayerName);
    List<TurnReport> MakeTurn(string id);
}