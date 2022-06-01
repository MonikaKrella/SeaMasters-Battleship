using SeaMasters.Consts;
using SeaMasters.Enums;
using SeaMasters.Models;

namespace SeaMasters.Services;

public class RandomGenerator
{
    private static readonly Random Random = Random.Shared;
    
    public static Coordinates GetRandomCoords()
    {
        int x = Random.Next(0, GameSettings.BOARD_DIMENSION);
        int y = Random.Next(0, GameSettings.BOARD_DIMENSION);
        return new Coordinates(x, y);
    }

    public static Coordinates GetAdjacentCoords(Coordinates currentCoords)
    {
        int xMinValue = currentCoords.X - 1 >= 0 ? currentCoords.X - 1 : 0;
        int xMaxValue = currentCoords.X + 1 < GameSettings.BOARD_DIMENSION ? currentCoords.X + 1 : GameSettings.BOARD_LAST_INDEX;
        int yMinValue = currentCoords.Y - 1 >= 0 ? currentCoords.Y - 1 : 0;
        int yMaxValue = currentCoords.Y + 1 < GameSettings.BOARD_DIMENSION ? currentCoords.Y + 1 : GameSettings.BOARD_LAST_INDEX;
        
        int x = Random.Next(xMinValue, xMaxValue+1);
        int y = Random.Next(yMinValue, yMaxValue+1);
        return new Coordinates(x, y);
    }
    
    public static Direction GetDirection()
    {
        var directions = Enum.GetValues(typeof(Direction));
        var randomDirection = (Direction)directions.GetValue(Random.Next(directions.Length));
        return randomDirection;
    }

    public static int GetPlayerIndex()
    {
        int randomPlayerIndex = Random.Next(0, GameSettings.NUMBER_OF_PLAYERS);
        return randomPlayerIndex;
    }
}