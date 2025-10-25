using FluentAssertions;
using Src.Day06;
using Xunit;

namespace Tests;

public class Day06Tests
{
    [Theory]
    [InlineData("turn on 0,0 through 999,999", "turn on", new[] {0,0}, new[] {999,999})]
    [InlineData("toggle 0,0 through 999,0", "toggle", new[] {0,0}, new[] {999,0})]
    [InlineData("turn off 499,499 through 500,500", "turn off", new[] {499,499}, new[] {500,500})]

    public void Test(string input, string expectedCommand, int[] expected1, int[] expected2)
    {
        // Act
        var result = SolutionP1.ExtractCommands(input);

        // Assert
        result.first.Should().BeEquivalentTo(expected1);
        result.second.Should().BeEquivalentTo(expected2);
        result.command.Should().Be(expectedCommand);
    }
}
