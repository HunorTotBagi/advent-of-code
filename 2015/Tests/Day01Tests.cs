using FluentAssertions;
using Src.Day01;
using Xunit;

namespace Tests;

public class Day01Tests
{
    [Theory]
    [InlineData("(())", 0)]
    [InlineData("()()", 0)]
    [InlineData("(((", 3)]
    [InlineData("(()(()(", 3)]
    [InlineData("))(((((", 3)]
    [InlineData("())", -1)]
    [InlineData("))(", -1)]
    [InlineData(")))", -3)]
    [InlineData(")())())", -3)]
    [InlineData(")())())", -3)]
    public void GetTheFloorTest(string input, int expected)
    {
        // Act
        var result = SolutionP1.GetTheFloor(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(")", 1)]
    [InlineData("()())", 5)]
    public void GetBasementPositionIndexTest(string input, int expected)
    {
        // Act
        var result = SolutionP2.GetBasementPositionIndex(input);

        // Assert
        result.Should().Be(expected);
    }
}
