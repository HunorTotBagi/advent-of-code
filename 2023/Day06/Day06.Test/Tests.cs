using Day06.Src;
using FluentAssertions;

namespace Day06.Test;

public class Tests
{
    Solution newRace = CreateRace();

    [Theory]
    [InlineData("exampleRace.txt", new ulong[] { 7, 15, 30 })]
    [InlineData("exampleRacePuzzle2.txt", new ulong[] { 71530 })]
    public void Should_return_correct_times(string fileName, ulong[] expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06.Src/" + fileName;

        // Act
        List<ulong> result = newRace.GetRaceTimesFromFile(filePath);

        // Assert
        result.Should().Equal(expected);
    }

    [Theory]
    [InlineData("exampleRace.txt", new ulong[] { 9, 40, 200 })]
    [InlineData("exampleRacePuzzle2.txt", new ulong[] { 940200 })]
    public void Should_return_correct_distances(string fileName, ulong[] expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06.Src/" + fileName;

        // Act
        List<ulong> result = newRace.GetRaceDistancesFromFile(filePath);

        // Assert
        result.Should().Equal(expected);
    }

    [Theory]
    [InlineData("exampleRace.txt", 0, 4)]
    [InlineData("exampleRace.txt", 1, 8)]
    [InlineData("exampleRace.txt", 2, 9)]
    [InlineData("exampleRacePuzzle2.txt", 0, 71503)]
    public void Should_return_correct_number_of_ways(string fileName, int raceNumber, ulong expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06.Src/" + fileName;

        // Act
        ulong result = newRace.CalculateWaysToBeatRecordForRace(filePath, raceNumber);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("exampleRace.txt", 288)]
    public void Should_return_correct_margin_of_error(string fileName, ulong expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06.Src/" + fileName;

        // Act
        ulong result = newRace.CalculateMarginOfError(filePath);

        // Assert
        result.Should().Be(expected);
    }

    private static Solution CreateRace()
    {
        return new Solution();
    }
}