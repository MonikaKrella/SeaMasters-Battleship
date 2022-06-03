using SeaMasters.Models;
using SeaMasters.Services;

namespace SeaMastersTests;

public class AdjacentFieldsHelperTests
{
    [Fact]
    public void AdjacentFieldsHelper_ShouldReturnAdjacentFieldsAroundCurrentField()
    {
        HashSet<Coordinates> expected = new HashSet<Coordinates>()
            { new (0, 1), new (1, 0), new (1, 1) };

        HashSet<Coordinates> actual = AdjacentFieldsHelper.FindAdjacentFields(new Coordinates(0, 0));
        
        Assert.Equal(expected, actual);
    }
}