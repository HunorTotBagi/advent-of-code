using FluentAssertions;
using Src.Day03;
using Xunit;

namespace Tests;

public class Day03Tests
{
    [Theory]
    [InlineData(">", 2)]
    [InlineData("^>v<", 4)]    
    [InlineData("^v^v^v^v^v", 2)]    
    public void Test1(string s, int expected)
    {
        // Act
        var result = SolutionP1.CalculateSantasWork(s);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("^v", 3)]
    [InlineData("^>v<", 3)]
    [InlineData("^v^v^v^v^v", 11)]
    public void Test2(string s, int expected)
    {
        // Act
        var result = SolutionP2.CalculateSantasAndRobotsWork(s);

        // Assert
        result.Should().Be(expected);
    }
}
