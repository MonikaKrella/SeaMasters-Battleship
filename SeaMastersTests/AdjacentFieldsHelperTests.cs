using System.Collections;
using SeaMasters.Models;
using SeaMasters.Services;

namespace SeaMastersTests;

public class AdjacentFieldsHelperTests
{
    [Theory]
    [MemberData(nameof(FindAdjacentFieldsTestData))]
    public void FindAdjacentFields_ShouldReturnAdjacentFields(Coordinates currentField, HashSet<Coordinates> expected)
    {
        HashSet<Coordinates> actual = AdjacentFieldsHelper.FindAdjacentFields(currentField);
        
        Assert.Equal(expected, actual);
    }

    private static IEnumerable<object[]> FindAdjacentFieldsTestData()
    {
        yield return new object[]
        {
            new Coordinates(0, 0), new HashSet<Coordinates>{ new(0, 1), new(1, 0), new(1, 1) }
        };
        yield return new object[]
        {
            new Coordinates(8, 9), new HashSet<Coordinates>{ new(9, 9), new(7, 9), new(7, 8), new(8, 8), new(9, 8) }
        };
        yield return new object[]
        {
            new Coordinates(5, 5), new HashSet<Coordinates>{ new(4, 5), new(6, 5), new(4, 4), new(5, 4), new(6, 4), new(4, 6), new(5, 6), new(6, 6) }
        };
    }
}