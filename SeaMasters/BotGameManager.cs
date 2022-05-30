namespace SeaMasters;

public class BotGameManager : IGameManager
{
    private Random random = new Random();
    public Player AttackingPlayer { get; set; }
    
    public Player DefendingPlayer { get; set; }
    
    public Player[] Players { get; set; }
    
    public List<MoveData> Raport { get; set; }

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

    // public List<MoveData> StartAutoGame()
    public Player StartAutoGame()
    {
        int firstPlayerIndex = random.Next(0, 2);
        AttackingPlayer = Players[firstPlayerIndex];
        DefendingPlayer = firstPlayerIndex == 0 ? Players[1] : Players[0];
        return DefendingPlayer;
    }

    public List<MoveData> RunTurn()
    {
        List<MoveData> gameRaport = new List<MoveData>();

        var shot = AttackingPlayer.MakeAShot();
        var (shotResult, isShipDestroyed) = DefendingPlayer.CheckEnemyShot(shot);
        var additionalFields =  AttackingPlayer.UpdateShootingBoard(shot, shotResult, isShipDestroyed);
        gameRaport.Add(new MoveData(AttackingPlayer, shot, shotResult, isShipDestroyed, DefendingPlayer.HasLost, additionalFields));
        if (shotResult == FieldStateType.Hit && !DefendingPlayer.HasLost)
        {
            FieldStateType extrashotResult;
           do
           {
               var extraShot = isShipDestroyed ? AttackingPlayer.MakeAShot() : AttackingPlayer.MakeExtraShot();
               (extrashotResult, isShipDestroyed) = DefendingPlayer.CheckEnemyShot(extraShot);
                Console.WriteLine(extrashotResult);
                additionalFields = AttackingPlayer.UpdateShootingBoard(extraShot, extrashotResult, isShipDestroyed);
                gameRaport.Add(new MoveData(AttackingPlayer, extraShot, extrashotResult, isShipDestroyed, DefendingPlayer.HasLost, additionalFields));
                Console.WriteLine(extrashotResult);
            } while (extrashotResult == FieldStateType.Hit && !DefendingPlayer.HasLost);
        }
        Console.WriteLine("Po pętli");

        if (DefendingPlayer.HasLost)
        {
            return gameRaport;
        }

        (AttackingPlayer, DefendingPlayer) = (DefendingPlayer, AttackingPlayer);

        return gameRaport;

    }

    public HashSet<Coordinates> GetNeighbours(int x, int y)
    {
        var neighbours = AdjacentFieldsHelper.FindAdjacentFields(new Coordinates(x, y));
        return neighbours;
    }


}