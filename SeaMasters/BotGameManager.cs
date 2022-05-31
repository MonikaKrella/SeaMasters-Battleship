using SeaMasters.Enums;
using SeaMasters.Interfaces;

namespace SeaMasters;

public class BotGameManager : IGameManager
{
    private Player attackingPlayer;
    private Player defendingPlayer;
    private Player[] players;
    
    public Player[] PrepareGame(string firstPlayerName, string secondPlayerName)
    {
        players = new []{ new Player(firstPlayerName), new Player(secondPlayerName) };
        foreach (var player in players)
        {
            player.SetShipsPositionsRandomly();
        }

        int startingPlayerIndex = RandomGenerator.GetPlayerIndex();
        attackingPlayer = players[startingPlayerIndex];
        defendingPlayer = startingPlayerIndex == 0 ? players[1] : players[0];

        return players;
    }

    public List<TurnReport> RunTurn()
    {
        List<TurnReport> playersReports = new List<TurnReport>();

        var shot = attackingPlayer.MakeAShot();
        var (shotResult, isShipDestroyed) = defendingPlayer.CheckEnemyShot(shot);
        var additionalFields =  attackingPlayer.UpdateShootingBoard(shot, shotResult, isShipDestroyed);
        playersReports.Add(new TurnReport(attackingPlayer, isShipDestroyed, defendingPlayer.HasLost, defendingPlayer.PlayerShootingBoard));
        if (shotResult == FieldStateType.Hit && !defendingPlayer.HasLost)
        {
            FieldStateType extrashotResult;
           do
           {
               var extraShot = isShipDestroyed ? attackingPlayer.MakeAShot() : attackingPlayer.MakeExtraShot();
               (extrashotResult, isShipDestroyed) = defendingPlayer.CheckEnemyShot(extraShot);
               additionalFields = attackingPlayer.UpdateShootingBoard(extraShot, extrashotResult, isShipDestroyed);
                playersReports.Add(new TurnReport(attackingPlayer, isShipDestroyed, defendingPlayer.HasLost, defendingPlayer.PlayerShootingBoard));
           } while (extrashotResult == FieldStateType.Hit && !defendingPlayer.HasLost);
        }

        if (defendingPlayer.HasLost)
        {
            return playersReports;
        }

        (attackingPlayer, defendingPlayer) = (defendingPlayer, attackingPlayer);

        return playersReports;
    }

}