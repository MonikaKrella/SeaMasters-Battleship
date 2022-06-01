using SeaMasters.Consts;

namespace SeaMasters.Models;

public class Coordinates
{
    public static readonly Coordinates Up = new (0, 1);
    public static readonly Coordinates Down = new (0, -1);
    public static readonly Coordinates Right = new (1, 0);
    public static readonly Coordinates Left = new (-1, 0);
    public static readonly Coordinates UpRight = new (1, 1);
    public static readonly Coordinates UpLeft = new (-1, 1);
    public static readonly Coordinates DownRight = new (1, -1);
    public static readonly Coordinates DownLeft = new (-1, -1);
    
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

    public override bool Equals(object obj)
    {
        if (obj is not Coordinates coords)
        {
            return false;
        }
        
        return X == coords.X && Y == coords.Y;
    }
    
    // https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-overriding-gethashcode
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = MathConsts.HASH_PRIME_NUMBER_FIRST;
            hash = hash * MathConsts.HASH_PRIME_NUMBER_SEC + X.GetHashCode();
            hash = hash * MathConsts.HASH_PRIME_NUMBER_SEC + Y.GetHashCode();
            return hash;
        }
    }
}