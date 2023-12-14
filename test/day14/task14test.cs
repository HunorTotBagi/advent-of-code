using FluentAssertions;
using src.day14;
using Xunit;

namespace test.day14
{
    public class task14test
    {
        string realData = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\realData.txt";
        string testData = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\testData.txt";
        string testDataROW0 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\testDataROW0.txt";
        string testDataROW1 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\testDataROW1.txt";

        Hunor newHunor = CreateHunor();

        [Theory]
        [InlineData(0, "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\testDataROW0.txt")]
        [InlineData(1, "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\testDataROW1.txt")]
        [InlineData(2, "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\testDataROW2.txt")]
        [InlineData(3, "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\testDataROW3.txt")]
        [InlineData(4, "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\testDataROW4.txt")]
        [InlineData(5, "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\testDataROW5.txt")]
        public void Row_tests(int colIndex, string filePath)
        {
            // Arrange
            List<List<char>> matrix = newHunor.ReadFileIntoList(testData);
            List<List<char>> expected = newHunor.ReadFileIntoList(filePath);

            // Act
            List<List<char>> result = newHunor.MoveOneRowNorth(matrix, colIndex);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_return_sum()
        {
            List<List<char>> matrix = newHunor.ReadFileIntoList(testData);
            int result = newHunor.Calculate(matrix);

            result.Should().Be(136);
        }

        [Fact]
        public void Should_return_sum_real()
        {
            List<List<char>> matrix = newHunor.ReadFileIntoList(realData);
            int result = newHunor.Calculate(matrix);

            result.Should().Be(112048);
        }

        [Theory]
        [InlineData(0, "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\testData.txt")]
        [InlineData(1, "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\1cycle.txt")]
        [InlineData(2, "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\2cycle.txt")]
        [InlineData(3, "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day14\\data\\3cycle.txt")]

        public void Cycle_test(int numberOfCycles, string filePath)
        {
            // Arrange
            List<List<char>> matrix = newHunor.ReadFileIntoList(testData);
            List<List<char>> expected = newHunor.ReadFileIntoList(filePath);

            // Act
            //List<List<char>> result1 = newHunor.CycleRotate(matrix, 1);
            List<List<char>> result = newHunor.CycleRotate(matrix, numberOfCycles);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        private static Hunor CreateHunor()
        {
            return new Hunor();
        }
    }
}
