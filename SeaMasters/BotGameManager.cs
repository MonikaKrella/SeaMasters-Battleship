using SeaMasters.Models;

namespace SeaMasters;

public class BotGameManager : IGameManager
{
    private Random random = new Random();
    private Player AttackingPlayer { get; set; }

    private Player DefendingPlayer { get; set; }

    private Player[] Players { get; set; }

    public Player[] PrepareGame(string player1Name, string player2Name)
    {
        Player[] players = { new Player(player1Name), new Player(player2Name) };
        foreach (var player in players)
        {
            player.SetShips();
        }

        Players = players;
        
        int firstPlayerIndex = random.Next(0, 2);
        AttackingPlayer = Players[firstPlayerIndex];
        DefendingPlayer = firstPlayerIndex == 0 ? Players[1] : Players[0];

        return players;
    }

    public List<PlayersRaport> RunTurn()
    {
        List<PlayersRaport> playersRaports = new List<PlayersRaport>();

        var shot = AttackingPlayer.MakeAShot();
        var (shotResult, isShipDestroyed) = DefendingPlayer.CheckEnemyShot(shot);
        var additionalFields =  AttackingPlayer.UpdateShootingBoard(shot, shotResult, isShipDestroyed);
        playersRaports.Add(new PlayersRaport(AttackingPlayer, isShipDestroyed, DefendingPlayer.HasLost, DefendingPlayer.PlayerShootingBoard));
        if (shotResult == FieldStateType.Hit && !DefendingPlayer.HasLost)
        {
            FieldStateType extrashotResult;
           do
           {
               var extraShot = isShipDestroyed ? AttackingPlayer.MakeAShot() : AttackingPlayer.MakeExtraShot();
               (extrashotResult, isShipDestroyed) = DefendingPlayer.CheckEnemyShot(extraShot);
               additionalFields = AttackingPlayer.UpdateShootingBoard(extraShot, extrashotResult, isShipDestroyed);
                playersRaports.Add(new PlayersRaport(AttackingPlayer, isShipDestroyed, DefendingPlayer.HasLost, DefendingPlayer.PlayerShootingBoard));
           } while (extrashotResult == FieldStateType.Hit && !DefendingPlayer.HasLost);
        }

        if (DefendingPlayer.HasLost)
        {
            return playersRaports;
        }

        (AttackingPlayer, DefendingPlayer) = (DefendingPlayer, AttackingPlayer);

        return playersRaports;
    }

    public HashSet<Coordinates> GetNeighbours(int x, int y)
    {
        var neighbours = AdjacentFieldsHelper.FindAdjacentFields(new Coordinates(x, y));
        return neighbours;
    }


}