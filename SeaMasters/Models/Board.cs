namespace SeaMasters;

public class Board
{
    public List<Ship> Ships { get; set; }
    public Ship[][] ShipsArea { get; set; }
    
    private ShipLocationGenerator shipLocationGenerator;
    public Board(List<Ship> argShips)
    {
        Ships = argShips;
        ShipsArea = new Ship[10][];
        for (int i = 0; i < ShipsArea.Length; i++)
        {
            ShipsArea[i] = new Ship[10];
        }

        shipLocationGenerator = new ShipLocationGenerator(ShipsArea);

    }

    public void SetShips()
    {
        shipLocationGenerator.SetShips(Ships);
    } 
}