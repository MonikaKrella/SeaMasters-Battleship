using SeaMasters.Models;

namespace SeaMastersTests;

public class GameManagerTests
{
    private GameManager gameManager;

    public GameManagerTests()
    {
        gameManager = new GameManager();
    }

    [Fact]
    public void MakeTurn_InvalidIdShouldFail()
    {
        var actual = gameManager.MakeTurn("invalidId");
        Assert.Null(actual);
    }
}