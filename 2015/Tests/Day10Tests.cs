using FluentAssertions;
using Src.Day10;
using Xunit;

namespace Tests;

public class Day10Tests
{
    [Theory]
    [InlineData("1", "11")]
    [InlineData("11", "21")]
    [InlineData("1211", "111221")]
    [InlineData("111221", "312211")]
    public void TransformTest(string input, string expected)
    {
        // Act
        var result = SolutionP1.Transform(input);

        // Assert
        result.Should().Be(expected);
    }
}
