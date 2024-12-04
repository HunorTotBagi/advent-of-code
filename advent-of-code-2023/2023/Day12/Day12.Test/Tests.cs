using Day12.Src;
using FluentAssertions;

namespace Day12.Test;

public class RecordTests
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day12.Src/testData.txt";

    HotSpring newHotSpring = CreateHotSpring();

    [Fact]
    public void Should_return_symbols_and_numbers_from_input_file()
    {
        // Arrange
        var symbolStrings = new List<string>{ { "???.###" }, { ".??..??...?##." }, { "?#?#?#?#?#?#?#?" },
                                            { "????.#...#..."}, { "????.######..#####." }, { "?###????????" } };

        var sizeLists = new List<List<int>>{ new List<int>{ 1, 1, 3 }, new List<int>{ 1, 1, 3 }, new List<int>{ 1, 3, 1, 6 },
                                                new List<int>{ 4, 1, 1 }, new List<int>{ 1, 6, 5 }, new List<int>{ 3, 2, 1 } };

        // Act
        (List<string> stringResult, List<List<int>> intResult) = newHotSpring.ReadFile(_testData);

        // Assert
        stringResult.Should().BeEquivalentTo(symbolStrings);
        intResult.Should().BeEquivalentTo(sizeLists);
    }

    [Fact]
    public void Should_return_combinations_that_mach_given_symbols()
    {
        // Arrange
        (List<string> resultStrings, List<List<int>> resultIntegers) = newHotSpring.ReadFile(_testData);
        var expectedSymbols = new List<string> { ".##.###", "#.#.###", "##..###" };

        // Act
        var result = newHotSpring.SelectStringsWithMatching(resultStrings[0], resultIntegers[0]);

        // Assert
        result.Should().BeEquivalentTo(expectedSymbols);
    }

    [Theory]
    [InlineData("???.###", new int[] { 1, 1, 3 }, 1)]
    [InlineData(".??..??...?##.", new int[] { 1, 1, 3 }, 4)]
    [InlineData("?#?#?#?#?#?#?#?", new int[] { 1, 3, 1, 6 }, 1)]
    [InlineData("????.#...#...", new int[] { 4, 1, 1 }, 1)]
    [InlineData("????.######..#####.", new int[] { 1, 6, 5 }, 4)]
    [InlineData("?###????????", new int[] { 3, 2, 1 }, 10)]
    public void Should_return_number_of_arrangements(string input, int[] numbers, int expected)
    {
        var result = newHotSpring.CalculateFinalCombinations(input, numbers);

        result.Should().Be(expected);
    }

    private static HotSpring CreateHotSpring()
    {
        return new HotSpring();
    }
}
