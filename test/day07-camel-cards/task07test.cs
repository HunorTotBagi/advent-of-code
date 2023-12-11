using FluentAssertions;
using src.day07;
using Xunit;

namespace Day07_Camel_cards
{
    public class task07test
    {
        Hand newHand = CreateHand();

        [Fact]
        public void Should_read_in_file()
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day11/data/exampleData0.txt";
            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                { "32T3K" , 765 },
                { "T55J5" , 684 },
                { "KK677" , 28 },
                { "KTJJT" , 220 },
                { "QQQJA" , 483 },
            };

            // Act
            Dictionary<string, int> result = newHand.ReadFile(filePath);

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
        public void CountOccurences_ShouldReturnExpectedResult(string card, char[] expectedChars, int[] expectedCounts)
        {
            // Arrange
            Dictionary<char, int> expected = new Dictionary<char, int>();
            for (int i = 0; i < expectedChars.Length; i++)
            {
                expected[expectedChars[i]] = expectedCounts[i];
            }

            // Act
            Dictionary<char, int> result = newHand.CountOccurences(card);

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
            int result = newHand.GetCardType(card);

            // Assert
            result.Should().Be(expected);
        }

        private static Hand CreateHand()
        {
            return new Hand();
        }
    }
}
