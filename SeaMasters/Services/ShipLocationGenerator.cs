using SeaMasters;
using SeaMasters.Enums;
using SeaMasters.Models;

namespace SeaMasters;

public class ShipLocationGenerator
{
    private readonly Ship[][] shipsArea;

    public ShipLocationGenerator(Ship[][] argShipsArea)
    {
        shipsArea = argShipsArea;
    }

    public void SetShipsPositionsRandomly(List<Ship> ships)
    {
        foreach (var ship in ships)
        {
            CreateShipPosition(ship);
        }
    }

    private void CreateShipPosition(Ship ship)
    {
        List<Coordinates> shipPosition = new List<Coordinates>();
        do
        {
            Coordinates firstCoords = GenerateField();
            var direction = RandomGenerator.GetDirection();
            shipPosition = GenerateShipPosition(firstCoords, ship.Length, direction);
        } while (shipPosition.Count < ship.Length);

        foreach (var coords in shipPosition)
        {
            shipsArea[coords.Y][coords.X] = ship;
        }

        ship.Position = shipPosition;
    }

    private Coordinates GenerateField()
    {
        Coordinates firstCoords = null;
        do
        {
            Coordinates coords = RandomGenerator.GetRandomCoords();
            if (shipsArea[coords.Y][coords.X] == null)
            {
                HashSet<Coordinates> adjacentFields =
                    AdjacentFieldsHelper.FindAdjacentFields(new Coordinates(coords.X, coords.Y));

                bool areNeighboursEmpty = true;

                foreach (var fieldCoords in adjacentFields)
                {
                    if (shipsArea[fieldCoords.Y][fieldCoords.X] != null)
                    {
                        areNeighboursEmpty = false;
                        break;
                    }
                }

                if (areNeighboursEmpty)
                {
                    firstCoords = new Coordinates(coords.X, coords.Y);
                }
            }
        } while (firstCoords == null);

        return firstCoords;
    }

    private List<Coordinates> GenerateShipPosition(Coordinates firstCoords, int shipLength, Direction shipDirection)
    {
        int newX = firstCoords.X;
        int newY = firstCoords.Y;
        List<Coordinates> shipPosition = new List<Coordinates>();
        shipPosition.Add(firstCoords);
        Coordinates prevShipPart = firstCoords;
        for (int i = 1; i < shipLength; i++)
        {
            if (shipDirection == Direction.Horizontal)
            {
                newX += 1;
            }
            else
            {
                newY += 1;
            }

            Coordinates nextCoords;
            if (((shipDirection == Direction.Horizontal && newX < 10) ||
                 (shipDirection == Direction.Vertical && newY < 10)) && shipsArea[newY][newX] == null)
            {
                var adjacentFields = AdjacentFieldsHelper.FindAdjacentFields(new Coordinates(newX, newY));

                bool areNeihboursEmpty = true;

                foreach (var coords in adjacentFields)
                {
                    if (shipsArea[coords.Y][coords.X] != null &&
                        shipsArea[coords.Y][coords.X] != shipsArea[prevShipPart.Y][prevShipPart.X])
                    {
                        areNeihboursEmpty = false;
                        break;
                    }
                }

                if (areNeihboursEmpty)
                {
                    nextCoords = new Coordinates(newX, newY);
                    prevShipPart = nextCoords;
                    shipPosition.Add(nextCoords);
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }

        return shipPosition;
    }
}