using System.Reflection;
using SeaMasters;
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
        shootingBoard.UpdateField(new Coordinates(5,5), FieldStateType.Hit);
        var actual = shootingBoard.ShootingArea[5][5];
        
        Assert.Equal(expected, actual);
    }
}