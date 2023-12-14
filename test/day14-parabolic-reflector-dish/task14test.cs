using FluentAssertions;
using src.day14;
using Xunit;

namespace test.day14
{
    public class task14test
    {
        string realData = "C:\\Users\\htotbagi\\source\\repos\\src\\aoc\\day14-parabolic-reflector-dish\\data\\realData.txt";
        string testData = "C:\\Users\\htotbagi\\source\\repos\\src\\aoc\\day14-parabolic-reflector-dish\\data\\testData.txt";
        string testDataROW0 = "C:\\Users\\htotbagi\\source\\repos\\src\\aoc\\day14-parabolic-reflector-dish\\data\\testDataROW0.txt";
        string testDataROW1 = "C:\\Users\\htotbagi\\source\\repos\\src\\aoc\\day14-parabolic-reflector-dish\\data\\testDataROW1.txt";

        Hunor newHunor = CreateHunor();

        [Theory]
        [InlineData(0, "C:\\Users\\htotbagi\\source\\repos\\src\\aoc\\day14-parabolic-reflector-dish\\data\\testDataROW0.txt")]
        [InlineData(1, "C:\\Users\\htotbagi\\source\\repos\\src\\aoc\\day14-parabolic-reflector-dish\\data\\testDataROW1.txt")]
        [InlineData(2, "C:\\Users\\htotbagi\\source\\repos\\src\\aoc\\day14-parabolic-reflector-dish\\data\\testDataROW2.txt")]
        [InlineData(3, "C:\\Users\\htotbagi\\source\\repos\\src\\aoc\\day14-parabolic-reflector-dish\\data\\testDataROW3.txt")]
        [InlineData(4, "C:\\Users\\htotbagi\\source\\repos\\src\\aoc\\day14-parabolic-reflector-dish\\data\\testDataROW4.txt")]
        [InlineData(5, "C:\\Users\\htotbagi\\source\\repos\\src\\aoc\\day14-parabolic-reflector-dish\\data\\testDataROW5.txt")]
        public void Row_tests(int colIndex, string filePath)
        {
            // Arrange
            List<List<char>> matrix = newHunor.LoadMatrixFromFile(testData);
            List<List<char>> expected = newHunor.LoadMatrixFromFile(filePath);

            // Act
            List<List<char>> result = newHunor.SlideRocksNorthInColumn(matrix, colIndex);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_return_sum()
        {
            List<List<char>> matrix = newHunor.LoadMatrixFromFile(testData);
            int result = newHunor.CalculateTotalLoad(matrix);

            result.Should().Be(136);
        }

        [Fact]
        public void Should_return_sum_real()
        {
            List<List<char>> matrix = newHunor.LoadMatrixFromFile(realData);
            int result = newHunor.CalculateTotalLoad(matrix);

            result.Should().Be(112048);
        }

        private static Hunor CreateHunor()
        {
            return new Hunor();
        }
    }
}