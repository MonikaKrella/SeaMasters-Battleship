using SeaMasters.Consts;
using SeaMasters.Models;

namespace SeaMasters;

public class Board
{
    private List<Ship> Ships { get; }
    public Ship[][] ShipsArea { get; }
    
    private ShipLocationGenerator shipLocationGenerator;
    public Board(List<Ship> argShips)
    {
        Ships = argShips;
        ShipsArea = new Ship[Settings.BOARD_DIMENSION][];
        for (int i = 0; i < ShipsArea.Length; i++)
        {
            ShipsArea[i] = new Ship[Settings.BOARD_DIMENSION];
        }

        shipLocationGenerator = new ShipLocationGenerator(ShipsArea);

    }

    public void SetShips()
    {
        shipLocationGenerator.SetShips(Ships);
    } 
}