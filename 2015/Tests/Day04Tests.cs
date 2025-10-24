using FluentAssertions;
using Xunit;

namespace Tests;
using Src.Day04;

public class Day04Tests
{
    [Theory]
    [InlineData("abcdef", true, 609043)]
    [InlineData("pqrstuv", true, 1048970)]
    public void Test1(string secretKey, bool fiveZeros, int expected)
    {
        // Act
        var result = SolutionP1.Find(secretKey, fiveZeros);

        // Assert
        result.Should().Be(expected);
    }
}
