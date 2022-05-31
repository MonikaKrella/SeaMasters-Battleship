using SeaMasters.Consts;
using SeaMasters.Enums;
using SeaMasters.Models;

namespace SeaMasters;

public class Player
{
    public string Name { get; }
    public Board PlayerBoard { get; }
    public ShootingBoard PlayerShootingBoard { get; }
    public List<Ship> Ships { get; }

    private readonly ShotGenerator shotGenerator;
    private Coordinates lastShot;

    public bool HasLost => Ships.All(ship => ship.IsDestroyed);

    public Player(string argName)
    {
        Name = argName;
        Ships = new List<Ship>()
        {
            new (GameSettings.SHIP_CARRIER_LENGTH),
            new (GameSettings.SHIP_BATTLESHIP_LENGTH),
            new (GameSettings.SHIP_SUBMARINE_LENGTH),
            new (GameSettings.SHIP_SUBMARINE_LENGTH),
            new (GameSettings.SHIP_DESTROYER_LENGTH)
        };
        PlayerBoard = new Board(Ships);
        PlayerShootingBoard = new ShootingBoard();
        shotGenerator = new ShotGenerator(PlayerShootingBoard);
    }

    public void SetShipsPositionsRandomly()
    {
        PlayerBoard.SetShipsPositionsRandomly();
    }

    public Coordinates MakeAShot()
    {
        Coordinates shot = shotGenerator.RandomShot();
        lastShot = shot;
        return shot;
    }

    public Coordinates MakeExtraShot()
    {
        Coordinates shot = shotGenerator.SearchingShot(lastShot);
        lastShot = shot;
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
            var additionalFields = PlayerShootingBoard.UpdateAfterDestruction(shot);
            return additionalFields;
        }

        PlayerShootingBoard.UpdateField(shot, shotResult);
        return null;
    }
}