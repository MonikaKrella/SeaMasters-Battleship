using SeaMasters.Consts;
using SeaMasters.Enums;
using SeaMasters.Models;
using SeaMasters.Services;

namespace SeaMastersTests;

public class RandomGeneratorTests
{
    [Fact]
    public void GetRandomCoords_ShouldCreateCoordsWithXBetween0and9()
    {
        var coords = RandomGenerator.GetRandomCoords();
        Assert.InRange(coords.X, 0, 9);
        Assert.InRange(coords.Y, 0, 9);
    }

    [Fact]
    public void GetDirection_ShouldGiveOneOfDiectionEnumValues()
    {
        var direction = RandomGenerator.GetDirection();
        Assert.IsType<Direction>(direction);
    }

    [Theory]
    [InlineData(3, 8)]
    [InlineData(0, 4)]
    [InlineData(9, 9)]
    public void GetAdjacentCoords_ShouldGiveCoordsOfFieldNextToCurrentField(int x, int y)
    {
        var coords = RandomGenerator.GetAdjacentCoords(new Coordinates(x, y));
        Assert.InRange(coords.X, x - 1, x + 1);
        Assert.InRange(coords.X, 0, 9);
        Assert.InRange(coords.Y, y - 1, y + 1);
        Assert.InRange(coords.Y, 0, 9);
    }

    [Fact]
    public void GetPlayerIndex_ShouldGiveIntInRangeOfPlayersAmount()
    {
        var index = RandomGenerator.GetPlayerIndex();
        Assert.InRange(index, 0, GameSettings.NUMBER_OF_PLAYERS - 1);
    }
}