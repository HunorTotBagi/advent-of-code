using FluentAssertions;
using src.day11;
using Xunit;

namespace test.day11
{
    public class task11test
    {
        string filePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day11\\data\\exampleData0.txt";
        string realFilePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day11\\data\\realData.txt";

        Galaxy newGalaxy = new Galaxy();

        [Fact]
        public void Should_Get_coordinates()
        {
            // Arrange
            List<List<int>> exp = new List<List<int>>();

            // Act
            List<List<int>> result = newGalaxy.GetCoordinates(filePath);

            // Assert
            result.Should().BeEquivalentTo(exp);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(7)]
        public void Should_return_bool_on_index_row(int row)
        {
            bool result = newGalaxy.EmptyRow(filePath, row);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(8)]
        public void Should_return_bool_on_index_col(int col)
        {
            bool result = newGalaxy.EmptyCol(filePath, col);

            result.Should().BeTrue();
        }

        [Fact]
        public void Should()
        {
            List<int> first = new List<int> { 0,3};
            List<int> second = new List<int> { 1, 7 };

            int result = newGalaxy.GetDistanceBetweenTwoPoints(filePath, first, second);

            result.Should().Be(6);
        }

        [Fact]
        public void Final()
        {
            int result = newGalaxy.GetFinal(filePath);

            result.Should().Be(374);
        }

        [Fact]
        public void Final1()
        {
            int result = newGalaxy.GetFinal(realFilePath);

            result.Should().Be(9545480);
        }

        private static Galaxy CreateGalaxy()
        {
            return new Galaxy();
        }
    }
}