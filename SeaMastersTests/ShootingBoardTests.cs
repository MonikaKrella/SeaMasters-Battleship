using SeaMasters.Enums;
using SeaMasters.Models;

namespace SeaMastersTests;

public class ShootingBoardTests
{
    private ShootingBoard shootingBoard;

    public ShootingBoardTests()
    {
        shootingBoard = new ShootingBoard();
    }

    [Fact]
    public void UpdateField_ShouldChangeStateAtCurrentFieldCoords()
    {
        var expected = FieldStateType.Hit;
        shootingBoard.UpdateField(new Coordinates(5, 5), FieldStateType.Hit);
        var actual = shootingBoard.ShootingArea[5][5];

        Assert.Equal(expected, actual);
    }


    [Fact]
    public void UpdateAfterDestruction_ShouldRetutnAllEmptyFieldsAround()
    {
        var expected = new HashSet<Coordinates>
            { new(5, 6), new(7, 6), new(5, 5), new(6, 5), new(7, 5), new(5, 7), new(6, 7), new(7, 7) };
        var actual = shootingBoard.UpdateAfterDestruction(new Coordinates(6, 6));
        Assert.Equal(expected, actual);
    }
}