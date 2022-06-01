using SeaMasters.Consts;
using SeaMasters.Models;
using SeaMasters.Services;

namespace SeaMasters;

public class Board
{
    public Ship[][] ShipsArea { get; }
    
    private readonly List<Ship> Ships;
    private readonly ShipLocationGenerator shipLocationGenerator;

    public Board(List<Ship> argShips)
    {
        Ships = argShips;
        ShipsArea = new Ship[GameSettings.BOARD_DIMENSION][];
        for (int i = 0; i < ShipsArea.Length; i++)
        {
            ShipsArea[i] = new Ship[GameSettings.BOARD_DIMENSION];
        }

        shipLocationGenerator = new ShipLocationGenerator(ShipsArea);
    }

    public void SetShipsPositionsRandomly()
    {
        shipLocationGenerator.SetShipsPositionsRandomly(Ships);
    }
}