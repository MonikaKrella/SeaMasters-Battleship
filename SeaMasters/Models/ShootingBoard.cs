namespace SeaMasters;

public class ShootingBoard
{
    public FieldStateType[][] ShootingArea { get; set; }
    
    public ShootingBoard()
    {
        ShootingArea = new FieldStateType[10][];
        for (int i = 0; i < ShootingArea.Length; i++)
        {
            ShootingArea[i] = new FieldStateType[10];
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

        DistributeNeighbours(field, emptyFieldsAroundShip, destroyedShipParts);

        
        return emptyFieldsAroundShip;
    }

    private void DistributeNeighbours(Coordinates currField, HashSet<Coordinates> emptyFieldsAroundShip, HashSet<Coordinates> destroyedShipParts )
    {
        HashSet<Coordinates> adjacentFields = AdjacentFieldsHelper.FindAdjacentFields(currField);
        foreach (var neighbourdCoords in adjacentFields)
        {
            if (ShootingArea[neighbourdCoords.Y][neighbourdCoords.X] == FieldStateType.Hit)
            {
                bool isNewAdded = destroyedShipParts.Add(neighbourdCoords);
                if (isNewAdded)
                {
                    DistributeNeighbours(neighbourdCoords, emptyFieldsAroundShip, destroyedShipParts);
                }
            }
            else
            {
                emptyFieldsAroundShip.Add(neighbourdCoords);
            }
        }
    }
}