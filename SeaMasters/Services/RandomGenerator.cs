using SeaMasters.Models;

namespace SeaMasters;

public class RandomGenerator
{
    private static Random random = new Random();
    
    public static Coordinates GetRandomCoords()
    {
        int x = random.Next(0, 10);
        int y = random.Next(0, 10);
        return new Coordinates(x, y);
    }

    public static Coordinates GetAdjacentCoords(Coordinates currentCoords)
    {
        int xMinValue = currentCoords.X - 1 >= 0 ? currentCoords.X - 1 : 0;
        int xMaxValue = currentCoords.X + 1 < 10 ? currentCoords.X + 1 : 9;
        int yMinValue = currentCoords.Y - 1 >= 0 ? currentCoords.Y - 1 : 0;
        int yMaxValue = currentCoords.Y + 1 < 10 ? currentCoords.Y + 1 : 9;
        
        int x = random.Next(xMinValue, xMaxValue+1);
        int y = random.Next(yMinValue, yMaxValue+1);
        return new Coordinates(x, y);
    }
    
    public static bool IsHorizontalDirection()
    {
        if (random.Next(0, 2) == 1)
        {
            return true;
        }
        return false;
    }

    public static int GetPlayerIndex()
    {
        int firstPlayerIndex = random.Next(0, 2);
        return firstPlayerIndex;
    }
}