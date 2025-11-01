using System.Runtime.CompilerServices;
using FluentAssertions;
using Src.Day09;
using Xunit;

namespace Tests;

public class Day09Tests
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Src/Day09/testData.txt";

    [Theory]
    [InlineData("London to Dublin = 464", "London", "Dublin", 464)]
    [InlineData("London to Belfast = 518", "London", "Belfast", 518)]
    [InlineData("Dublin to Belfast = 141", "Dublin", "Belfast", 141)]
    public void SplitTest(string input, string from, string to, int distance)
    {
        // Act
        var result = SolutionP1.Split(input);

        // Assert
        result.Item1.Should().Be(from);
        result.Item2.Should().Be(to);
        result.Item3.Should().Be(distance);
    }

    [Theory]
    [InlineData("Novi Sad", "Beograd",  "Beograd", "Novi Sad")]
    [InlineData("Beograd", "Novi Sad", "Beograd", "Novi Sad")]
    public void CanonicalTest(string from, string to, string expected1, string expected2)
    {
        // Act
        var result = SolutionP1.Canonical(from, to);

        // Assert
        result.Item1.Should().Be(expected1);
        result.Item2.Should().Be(expected2);
    }

    [Fact]
    public void CalcTest()
    {
        var result = SolutionP1.Calc(_testData);

        result.Should().Be(605);
    }
}
