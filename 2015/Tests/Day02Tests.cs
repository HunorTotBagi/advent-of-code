using FluentAssertions;
using Src.Day02;
using Xunit;

namespace Tests;

public class Day02Tests
{
    [Fact]
    public void SplitterTest()
    {
        // Arrange
        var input = "2x3x4";
        var expected = new[] { 2, 3, 4 };

        // Act
        var result = SolutionP1.Splitter(input);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("2x3x4", 52)]
    [InlineData("1x1x10", 42)]
    public void CalculateSquareFeetTest(string input, int expected)
    {
        // Act
        var numbers = SolutionP1.Splitter(input);
        var result = SolutionP1.CalculateSquareFeet(numbers);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("2x3x4", 6)]
    [InlineData("1x1x10", 1)]
    public void GetTheSmallestSideTest(string input, int expected)
    {
        // Act
        var numbers = SolutionP1.Splitter(input);
        var result = SolutionP1.GetTheSmallestSide(numbers);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("2x3x4", 58)]
    [InlineData("1x1x10", 43)]
    public void SquareFeetTest(string input, int expected)
    {
        // Act
        var numbers = SolutionP1.Splitter(input);
        var result = SolutionP1.SquareFeet(numbers);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(new[] {2,3,4}, 10)]
    [InlineData(new[] {1,1,10}, 4)]
    public void CalculateRibbonTest(int[] input, int expected)
    {
        // Act
        var result = SolutionP2.CalculateRibbon(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(new[] { 2, 3, 4 }, 24)]
    [InlineData(new[] { 1, 1, 10 }, 10)]
    public void CalculateRibbonBowTest(int[] input, int expected)
    {
        // Act
        var result = SolutionP2.CalculateRibbonBow(input);

        // Assert
        result.Should().Be(expected);
    }
}
