using SeaMasters.Consts;
using SeaMasters.Enums;
using SeaMasters.Services;

namespace SeaMasters.Models;

public class ShootingBoard
{
    public FieldStateType[][] ShootingArea { get; }
    
    public ShootingBoard()
    {
        ShootingArea = new FieldStateType[GameSettings.BOARD_DIMENSION][];
        for (int i = 0; i < ShootingArea.Length; i++)
        {
            ShootingArea[i] = new FieldStateType[GameSettings.BOARD_DIMENSION];
        }
    }

    public void UpdateField(Coordinates field, FieldStateType state)
    {
        ShootingArea[field.Y][field.X] = state;
    }

    public HashSet<Coordinates> UpdateAfterDestruction(Coordinates field)
    {
        HashSet<Coordinates> destroyedShipParts = new HashSet<Coordinates>();
        HashSet<Coordinates> emptyFieldsAroundShip = new HashSet<Coordinates>();

        ShootingArea[field.Y][field.X] = FieldStateType.Hit;
        destroyedShipParts.Add(field);

        FindNeighboursAroundShip(field, emptyFieldsAroundShip, destroyedShipParts);

        
        return emptyFieldsAroundShip;
    }

    private void FindNeighboursAroundShip(Coordinates currField, HashSet<Coordinates> emptyFieldsAroundShip, HashSet<Coordinates> destroyedShipParts )
    {
        HashSet<Coordinates> adjacentFields = AdjacentFieldsHelper.FindAdjacentFields(currField);
        foreach (var neighbourCoords in adjacentFields)
        {
            if (ShootingArea[neighbourCoords.Y][neighbourCoords.X] == FieldStateType.Hit)
            {
                bool isNewAdded = destroyedShipParts.Add(neighbourCoords);
                if (isNewAdded)
                {
                    FindNeighboursAroundShip(neighbourCoords, emptyFieldsAroundShip, destroyedShipParts);
                }
            }
            else
            {
                emptyFieldsAroundShip.Add(neighbourCoords);
            }
        }
    }
}