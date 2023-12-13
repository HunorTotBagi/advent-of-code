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

        [Theory]
        [InlineData(0)]
        public void Should_return_slice_ROW(int expected)
        {
            // Arrange
            List<List<List<char>>> matrix = newHunor.ReadFileIntoBlocks(testData);

            // Act
            int result = newHunor.GetReflectionRow(matrix[0]);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(5)]
        public void Should_return_slice_COL(int expected)
        {
            // Arrange
            List<List<List<char>>> matrix = newHunor.ReadFileIntoBlocks(testData);

            // Act
            int result = newHunor.GetColumnsReflection(matrix[0]);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_result_test()
        {
            // Act
            int result = newHunor.Final(testData);

            // Assert
            result.Should().Be(405);
        }

        [Fact]
        public void Should_return_result()
        {
            // Act
            int result = newHunor.Final(realData);

            // Assert
            result.Should().Be(33520);
        }

        private static Hunor CreateHunor()
        {
            return new Hunor();
        }
    }
}