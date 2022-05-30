using SeaMasters;

namespace SeaMasters;

public class Ship
{
    public int Length { get; set; }
    
    public List<Coordinates> Position { get; set; }
    public List<Coordinates> DestroyedParts { get; set; }
    
    public bool IsDestroyed
    {
        get
        {
            return DestroyedParts.Count >= Length;
        }
    }

    public Ship(int argLength)
    {
        Length = argLength;
        DestroyedParts = new List<Coordinates>(argLength);
        Position = new List<Coordinates>(argLength);
    }
}