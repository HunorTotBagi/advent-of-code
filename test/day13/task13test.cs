using FluentAssertions;
using src.day13;
using Xunit;

namespace test.day13
{
    public class task13test
    {
        string realData = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day13\\data\\realData.txt";
        string testData = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day13\\data\\testData.txt";

        Hunor newHunor = CreateHunor();

        [Fact]
        public void Should_read_in()
        {
            // Arrange
            List<List<List<char>>> exp = new();

            // Act
            List<List<List<char>>> result = newHunor.ReadFileIntoBlocks(testData);

            // Assert
            result.Should().BeEquivalentTo(exp);
        }

        [Theory]
        [InlineData(4)]
        public void Should_return_slice_ROW(int expected)
        {
            List<List<List<char>>> matrix = newHunor.ReadFileIntoBlocks(testData);

            int result = newHunor.GetReflectionIndex(matrix[0]);

            result.Should().Be(expected);
        }

        private static Hunor CreateHunor()
        {
            return new Hunor();
        }
    }
}