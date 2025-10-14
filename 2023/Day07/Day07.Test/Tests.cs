using Day07.Src;
using FluentAssertions;

namespace Day07.Test;

public class Tests
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day07.Src/testData.txt";

    [Fact]
    public void Should_read_in_file()
    {
        // Arrange
        var expected = new Dictionary<string, int>
            {
                { "32T3K" , 765 },
                { "T55J5" , 684 },
                { "KK677" , 28 },
                { "KTJJT" , 220 },
                { "QQQJA" , 483 },
            };

        // Act
        var result = Solution.ReadFile(_testData);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("AAAAA", new char[] { 'A' }, new int[] { 5 })]
    [InlineData("AA8AA", new char[] { 'A', '8' }, new int[] { 4, 1 })]
    [InlineData("23332", new char[] { '2', '3' }, new int[] { 2, 3 })]
    [InlineData("TTT98", new char[] { 'T', '9', '8' }, new int[] { 3, 1, 1 })]
    [InlineData("23432", new char[] { '2', '3', '4' }, new int[] { 2, 2, 1 })]
    [InlineData("A23A4", new char[] { 'A', '2', '3', '4' }, new int[] { 2, 1, 1, 1 })]
    [InlineData("23456", new char[] { '2', '3', '4', '5', '6' }, new int[] { 1, 1, 1, 1, 1 })]
    public void CountOccurrences_ShouldReturnExpectedResult(string card, char[] expectedChars, int[] expectedCounts)
    {
        // Arrange
        var expected = CreateDictionary(expectedChars, expectedCounts);

        // Act
        var result = Solution.CountOccurences(card);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("AAAAA", 7)]
    [InlineData("AA8AA", 6)]
    [InlineData("23332", 5)]
    [InlineData("TTT98", 4)]
    [InlineData("23432", 3)]
    [InlineData("A23A4", 2)]
    [InlineData("23456", 1)]
    public void Should_return_hand_type(string card, int expected)
    {
        // Act
        var result = Solution.GetCardType(card);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("KK677", "KTJJT", 4)]
    public void Should_compare_hands(string firstHand, string secondHand, int expected)
    {
        var result = Solution.CompareHands(firstHand, secondHand);

        result.Should().Be(expected);
    }

    [Fact]
    public void Should_calculate_winnings()
    {
        // Arrange

        // Act
        var result = Solution.CalculateWinnings(_testData);

        // Assert
        result.Should().Be(6440);
    }

    public static Dictionary<char, int> CreateDictionary(char[] expectedChars, int[] expectedCounts)
    {
        var expected = new Dictionary<char, int>();
        for (var i = 0; i < expectedChars.Length; i++)
        {
            expected[expectedChars[i]] = expectedCounts[i];
        }
        return expected;
    }
}