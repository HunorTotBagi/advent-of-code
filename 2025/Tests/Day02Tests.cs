using FluentAssertions;

namespace Tests;

public class Day02Tests
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Src/Day02/testData.txt";

    [Fact]
    public void ReadFileTest()
    {
        // Arrange
        var expected = new List<string>
        {
            "11-22",
            "95-115",
            "998-1012",
            "1188511880-1188511890",
            "222220-222224",
            "1698522-1698528",
            "446443-446449",
            "38593856-38593862",
            "565653-565659",
            "824824821-824824827",
            "2121212118-2121212124"
        };

        // Act
        var result = Src.Day02.SolutionP1.ReadFile(_testData);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(12341234, true)]
    [InlineData(11, true)]
    [InlineData(123, false)]
    [InlineData(351159, false)]
    public void IsValidDigitTest(int number, bool expected)
    {
        // Act
        var result = Src.Day02.SolutionP1.IsValidDigit(number);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void SolveP1Test()
    {
        // Arrange
        var expected = 1227775554;

        // Act
        var result = Src.Day02.SolutionP1.Solve(_testData);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(12341234, true)]
    [InlineData(11, true)]
    [InlineData(123, false)]
    [InlineData(351159, false)]
    public void IsValidDigitAdvancedTest(int number, bool expected)
    {
        // Act
        var result = Src.Day02.SolutionP2.IsValidDigit(number);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void SolveP2Test()
    {
        // Arrange
        var expecetd = 4174379265;

        // Act
        var result = Src.Day02.SolutionP2.Solve(_testData);

        // Assert
        result.Should().Be(expecetd);
    }
}
