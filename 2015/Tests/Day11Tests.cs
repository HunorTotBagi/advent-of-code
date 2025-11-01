using FluentAssertions;
using Src.Day11;
using Xunit;

namespace Tests;

public class Day11Tests
{
    [Theory]
    [InlineData("eoirjgeabcpotgk", true)]
    [InlineData("eoirjgeawbcpotgk", false)]
    [InlineData("orioeiurtoeiurtxyz", true)]
    public void PasswordContainsThreeIncreasingLettersTest(string input, bool expected)
    {
        // Act
        var result = SolutionP1.PasswordContainsThreeIncreasingLetters(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("asdfadsgsfdgsdfg", true)]
    [InlineData("alsdflaskdfiiweof", false)]
    [InlineData("powkefpoksliiiii", false)]
    public void PasswordDoesNotContainForbiddenLettersTest(string input, bool expected)
    {
        // Act
        var result = SolutionP1.PasswordDoesNotContainForbiddenLetters(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("abbceffg", true)]
    [InlineData("abbcegjk", false)]
    [InlineData("eorijgweoirjgooslkfaslkdfnnweoihaiuwhf", true)]
    [InlineData("hepxxxyz", false)]
    public void PasswordContainsTwoDifferentNonOverlappingPairsOfLettersTest(string input, bool expected)
    {
        // Act
        var result = SolutionP1.PasswordContainsTwoDifferentNonOverlappingPairsOfLetters(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("hijklmmn", false)]
    [InlineData("abbceffg   ", false)]
    [InlineData("abbcegjk", false)]
    public void IsPasswordGoodTest(string input, bool expected)
    {
        // Act
        var result = SolutionP1.IsPasswordGood(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("xx", "xy")]
    [InlineData("xy", "xz")]
    [InlineData("xz", "ya")]
    [InlineData("ya", "yb")]
    public void GenerateNextPasswordTest(string input, string expected)
    {
        // Act
        var result = SolutionP1.GenerateNextPassword(input);

        // Assert
        result.Should().Be(expected);
    }
}
