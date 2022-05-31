using SeaMasters.Models;

namespace SeaMasters;

public class ShotGenerator
{
    public ShootingBoard ShootingBoard { get; set; }

    public ShotGenerator(ShootingBoard argShootingBoard)
    {
        ShootingBoard = argShootingBoard;
    }


    public Coordinates RandomShot()
    {
        Coordinates shotCoords;
        do
        {
            shotCoords = RandomGenerator.GetRandomCoords();
        } while (ShootingBoard.ShootingArea[shotCoords.Y][shotCoords.X] != FieldStateType.Unknown);

        return shotCoords;
    }

    public Coordinates SearchingShot(Coordinates previousShot)
    {
        var adjacentFields = AdjacentFieldsHelper.FindAdjacentFields(previousShot);
        var checkedFields = new HashSet<Coordinates>();
        Coordinates shotCoords;
        do
        {
            if (checkedFields.Count < adjacentFields.Count)
            {
                shotCoords = RandomGenerator.GetAdjacentCoords(previousShot);
                checkedFields.Add(shotCoords);
            }
            else
            {
                shotCoords = RandomGenerator.GetRandomCoords();
            }
        } while (ShootingBoard.ShootingArea[shotCoords.Y][shotCoords.X] != FieldStateType.Unknown &&
                 checkedFields.Count < adjacentFields.Count);

        return shotCoords;
    }
}