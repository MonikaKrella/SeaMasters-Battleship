namespace SeaMasters;

public class Coordinates
{
    public static Coordinates Up = new Coordinates(0, 1);
    public static Coordinates Down = new Coordinates(0, -1);
    public static Coordinates Right = new Coordinates(1, 0);
    public static Coordinates Left = new Coordinates(-1, 0);
    public static Coordinates UpRight = new Coordinates(1, 1);
    public static Coordinates UpLeft = new Coordinates(-1, 1);
    public static Coordinates DownRight = new Coordinates(1, -1);
    public static Coordinates DownLeft = new Coordinates(-1, -1);
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
            int hash = 17;
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            return hash;
        }
    }
}