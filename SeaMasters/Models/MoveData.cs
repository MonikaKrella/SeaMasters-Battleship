namespace SeaMasters;

public class MoveData
{
    public Player ActivePlayer { get;  }
    public Coordinates ShotCoordinates { get; }
    public FieldStateType ShootedFieldState { get;  }
    public bool IsEnemyShipDestroyed { get;  }
    public bool HasEnemyLost { get; }
    public HashSet<Coordinates> AdditionalEmptyFieldsAroundDestroyedShip { get; }

    public MoveData(
        Player argActivePlayer, 
        Coordinates argShotCoords, 
        FieldStateType argShootedFieldState, 
        bool argIsShipDestroyed, 
        bool argEnemyLost,
        HashSet<Coordinates> additionalFields = null)
    {
        ActivePlayer = argActivePlayer;
        ShotCoordinates = argShotCoords;
        ShootedFieldState = argShootedFieldState;
        IsEnemyShipDestroyed = argIsShipDestroyed;
        HasEnemyLost = argEnemyLost;
        AdditionalEmptyFieldsAroundDestroyedShip = additionalFields;
    }
}