using SeaMasters.Consts;

namespace SeaMasters.Models;

public class Coordinates
{
    public static readonly Coordinates Up = new Coordinates(0, 1);
    public static readonly Coordinates Down = new Coordinates(0, -1);
    public static readonly Coordinates Right = new Coordinates(1, 0);
    public static readonly Coordinates Left = new Coordinates(-1, 0);
    public static readonly Coordinates UpRight = new Coordinates(1, 1);
    public static readonly Coordinates UpLeft = new Coordinates(-1, 1);
    public static readonly Coordinates DownRight = new Coordinates(1, -1);
    public static readonly Coordinates DownLeft = new Coordinates(-1, -1);
    public int X { get; }
    public int Y { get; }

    public Coordinates(int argX, int argY)
    {
        X = argX;
        Y = argY;
    }

    public static Coordinates operator +(Coordinates a, Coordinates b)
    {
        return new Coordinates(a.X + b.X, a.Y + b.Y);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Coordinates coords)
        {
            if (X == coords.X && Y == coords.Y)
            {
                return true;
            }
        }
        return false;

    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = Settings.HASH_PRIME_NUMBER_FIRST;
            hash = hash * Settings.HASH_PRIME_NUMBER_SEC + X.GetHashCode();
            hash = hash * Settings.HASH_PRIME_NUMBER_SEC + Y.GetHashCode();
            return hash;
        }
    }
}