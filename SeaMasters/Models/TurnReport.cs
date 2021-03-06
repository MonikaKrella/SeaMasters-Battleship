using SeaMasters.Models;

namespace SeaMasters;

public class TurnReport
{
    public Player ActivePlayer { get; }
    public bool IsEnemyShipDestroyed { get; }
    public bool HasEnemyLost { get; }
    public ShootingBoard DefendingPlayerShootingBoard { get; }

    public TurnReport(
        Player argActivePlayer,
        bool argIsEnemyShipDestroyed,
        bool argHasEnemyLost,
        ShootingBoard argDefendingPlayerShootingBoard
    )
    {
        ActivePlayer = argActivePlayer;
        IsEnemyShipDestroyed = argIsEnemyShipDestroyed;
        HasEnemyLost = argHasEnemyLost;
        DefendingPlayerShootingBoard = argDefendingPlayerShootingBoard;
    }
}