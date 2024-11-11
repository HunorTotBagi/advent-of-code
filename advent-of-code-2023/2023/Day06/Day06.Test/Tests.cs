using Day06.Src;
using FluentAssertions;

namespace Day06.Test;

public class Tests
{
    Race newRace = CreateRace();

    [Theory]
    [InlineData("exampleRace.txt", new ulong[] { 7, 15, 30 })]
    [InlineData("realRace.txt", new ulong[] { 48, 87, 69, 81 })]
    [InlineData("exampleRacePuzzle2.txt", new ulong[] { 71530 })]
    [InlineData("realRacePuzzle2.txt", new ulong[] { 48876981 })]
    public void Should_return_correct_times(string fileName, ulong[] expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06.Src/Data/" + fileName;

        // Act
        List<ulong> result = newRace.GetRaceTimesFromFile(filePath);

        // Assert
        result.Should().Equal(expected);
    }

    [Theory]
    [InlineData("exampleRace.txt", new ulong[] { 9, 40, 200 })]
    [InlineData("realRace.txt", new ulong[] { 255, 1288, 1117, 1623 })]
    [InlineData("exampleRacePuzzle2.txt", new ulong[] { 940200 })]
    [InlineData("realRacePuzzle2.txt", new ulong[] { 255128811171623 })]
    public void Should_return_correct_distances(string fileName, ulong[] expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06.Src/Data/" + fileName;

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
    [InlineData("realRacePuzzle2.txt", 0, 36992486)]
    public void Should_return_correct_number_of_ways(string fileName, int raceNumber, ulong expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06.Src/Data/" + fileName;

        // Act
        ulong result = newRace.CalculateWaysToBeatRecordForRace(filePath, raceNumber);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("exampleRace.txt", 288)]
    [InlineData("realRace.txt", 252000)]
    public void Should_return_correct_margin_of_error(string fileName, ulong expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06.Src/Data/" + fileName;

        // Act
        ulong result = newRace.CalculateMarginOfError(filePath);

        // Assert
        result.Should().Be(expected);
    }

    private static Race CreateRace()
    {
        return new Race();
    }
}