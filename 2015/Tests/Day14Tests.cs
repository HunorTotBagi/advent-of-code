using FluentAssertions;
using Src.Day14;
using Xunit;

namespace Tests;

public class Day14Tests
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Src/Day14/testData.txt";

    [Theory]
    [InlineData("Vixen can fly 8 km/s for 8 seconds, but then must rest for 53 seconds.", 8, 8, 53)]
    [InlineData("Rudolph can fly 20 km/s for 7 seconds, but then must rest for 132 seconds.", 20, 7, 132)]
    public void Test1(string input, int expectedSpeed, int expectedActiveTime, int expectedRestTime)
    {
        // Act
        var (speed, activeTime, restTime) = SolutionP1.ExtractInfo(input);

        // Arrange
        speed.Should().Be(expectedSpeed);
        activeTime.Should().Be(expectedActiveTime);
        restTime.Should().Be(expectedRestTime);
    }

    [Theory]
    [InlineData(14,10,127, 1120)]
    [InlineData(16,11,162, 1056)]
    public void GetDistanceTest(int speed, int activeTime, int restTime, int expected)
    {
        // Act
        var result = SolutionP1.GetDistance(speed, activeTime, restTime, 1000);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var seconds = 1000;

        // Act
        var result = SolutionP1.Calc(_testData, seconds);

        // Assert
        result.Should().Be(1120);
    }
}
