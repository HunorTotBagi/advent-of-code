using FluentAssertions;
using Src.Day02;
using Xunit;

namespace Tests;

public class Day02Tests
{
    [Fact]
    public void Test1()
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
    public void Test2(string input, int expected)
    {
        // Act
        var numbers = SolutionP1.Splitter(input);
        var result = SolutionP1.CalcSquareFeet(numbers);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("2x3x4", 6)]
    [InlineData("1x1x10", 1)]
    public void Test3(string input, int expected)
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
    public void Test4(string input, int expected)
    {
        // Act
        var numbers = SolutionP1.Splitter(input);
        var result = SolutionP1.SqFeet(numbers);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Test5()
    {
        // Act
        var result = SolutionP1.CalculateAll(_testData);
        var expected = 0;

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(new[] {2,3,4}, 10)]
    [InlineData(new[] {1,1,10}, 4)]
    public void Test6(int[] input, int expected)
    {
        // Act
        var result = SolutionP2.Ribbon(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(new[] { 2, 3, 4 }, 24)]
    [InlineData(new[] { 1, 1, 10 }, 10)]
    public void Test7(int[] input, int expected)
    {
        // Act
        var result = SolutionP2.RibbonBow(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Test8()
    {
        // Act
        var result = SolutionP2.CalculateAll(_testData);
        var expected = 0;

        // Assert
        result.Should().Be(expected);
    }
}
