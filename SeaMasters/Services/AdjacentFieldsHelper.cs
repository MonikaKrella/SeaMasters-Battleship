using SeaMasters.Models;

namespace SeaMasters;

public static class AdjacentFieldsHelper
{
    public static HashSet<Coordinates> FindAdjacentFields(Coordinates currField)
    {
        HashSet<Coordinates> adjacentFields = new HashSet<Coordinates>();
        if ((currField + Coordinates.Up).Y < 10)
        {
            adjacentFields.Add(currField + Coordinates.Up);
        } 
        if ((currField + Coordinates.Down).Y >= 0)
        {
            adjacentFields.Add(currField + Coordinates.Down);
        }
        if ((currField + Coordinates.Right).X < 10)
        {
            adjacentFields.Add(currField + Coordinates.Right);
        }
        if ((currField + Coordinates.Left).X >= 0)
        {
            adjacentFields.Add(currField + Coordinates.Left);
        }

        if ((currField + Coordinates.UpRight).Y < 10 && (currField + Coordinates.UpRight).X < 10)
        {
            adjacentFields.Add(currField + Coordinates.UpRight);
        }
        if ((currField + Coordinates.UpLeft).Y < 10 && (currField + Coordinates.UpLeft).X >= 0)
        {
            adjacentFields.Add(currField + Coordinates.UpLeft);
        }
        if ((currField + Coordinates.DownRight).Y >= 0 && (currField + Coordinates.DownRight).X < 10)
        {
            adjacentFields.Add(currField + Coordinates.DownRight);
        }
        if ((currField + Coordinates.DownLeft).Y >= 0 && (currField + Coordinates.DownLeft).X >= 0)
        {
            adjacentFields.Add(currField + Coordinates.DownLeft);
        }

        return adjacentFields;

    }
}