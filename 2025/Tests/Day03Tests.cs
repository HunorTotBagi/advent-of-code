using FluentAssertions;

namespace Tests;

public class Day03Tests
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Src/Day03/testData.txt";

    [Fact]
    public void ReadFileTest()
    {
        // Arrange
        var expected = new List<string>
        {
            "987654321111111",
            "811111111111119",
            "234234234234278",
            "818181911112111",
        };

        // Act
        var result = Src.Day03.SolutionP1.ReadFile(_testData);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("987654321111111", 98)]
    [InlineData("811111111111119", 89)]
    [InlineData("234234234234278", 78)]
    [InlineData("818181911112111", 92)]
    public void Test2(string input, int expected)
    {
        // Act
        var result = Src.Day03.SolutionP1.ExtractJoltage(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var expected = 357;

        // Act
        var result = Src.Day03.SolutionP1.Solve(_testData);

        // Assert
        result.Should().Be(expected);
    }
}
