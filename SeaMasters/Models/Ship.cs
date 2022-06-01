namespace SeaMasters.Models;

public class Ship
{
    public int Length { get; }
    public IReadOnlyList<Coordinates> Position { get; private set; }
    public IReadOnlyList<Coordinates> DestroyedParts => destroyedParts;
    public bool IsDestroyed => DestroyedParts.Count >= Length;

    private readonly List<Coordinates> destroyedParts;

    public Ship(int argLength)
    {
        Length = argLength;
        destroyedParts = new List<Coordinates>(argLength);
        Position = new List<Coordinates>(argLength);
    }

    public void SetPosition(List<Coordinates> shipPosition)
    {
        Position = shipPosition;
    }

    public void AddDestroyedPart(Coordinates destroyedPartCoords)
    {
        destroyedParts.Add(destroyedPartCoords);
    }
}