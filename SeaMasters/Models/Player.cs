using SeaMasters.Consts;
using SeaMasters.Models;

namespace SeaMasters;

public class Player
{
    public string Name { get; }
    public Board PlayerBoard { get; }
    public ShootingBoard PlayerShootingBoard { get; }
    public List<Ship> Ships { get; }

    public ShotGenerator ShotGenerator { get;}

    private Coordinates LastShot { get; set; }

    public bool HasLost
    {
        get { return Ships.All(ship => ship.IsDestroyed); }
    }

    public Player(string argName)
    {
        Name = argName;
        Ships = new List<Ship>()
        {
            new Ship(Settings.SHIP_CARRIER),
            new Ship(Settings.SHIP_BATTLESHIP),
            new Ship(Settings.SHIP_SUBMARINE),
            new Ship(Settings.SHIP_SUBMARINE),
            new Ship(Settings.SHIP_DESTROYER)
        };
        PlayerBoard = new Board(Ships);
        PlayerShootingBoard = new ShootingBoard();
        ShotGenerator = new ShotGenerator(PlayerShootingBoard);
    }

    public void SetShips()
    {
        PlayerBoard.SetShips();
    }

    public Coordinates MakeAShot()
    {
        Coordinates shot = ShotGenerator.RandomShot();
        LastShot = shot;
        return shot;
    }

    public Coordinates MakeExtraShot()
    {
        Coordinates shot = ShotGenerator.SearchingShot(LastShot);
        LastShot = shot;
        return shot;
    }

    public (FieldStateType shootedFieldState , bool isShipDestroyed) CheckEnemyShot(Coordinates enemyShot)
    {
        if (PlayerBoard.ShipsArea[enemyShot.Y][enemyShot.X] == null)
        {
            return (FieldStateType.Miss, false);
        }

        Ship hittedShip = PlayerBoard.ShipsArea[enemyShot.Y][enemyShot.X];
        hittedShip.DestroyedParts.Add(new Coordinates(enemyShot.X, enemyShot.Y));
        return (FieldStateType.Hit, hittedShip.IsDestroyed);
    }

    public HashSet<Coordinates> UpdateShootingBoard(Coordinates shot, FieldStateType shotResult,
        bool isShipDestroyed)
    {
        if (isShipDestroyed)
        {
            var additionaFields = PlayerShootingBoard.UpdateAfterDestruction(shot);
            return additionaFields;
        }

        PlayerShootingBoard.UpdateField(shot, shotResult);
        return null;
    }
}