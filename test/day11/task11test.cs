using FluentAssertions;
using src.day11;
using Xunit;

namespace test.day11
{
    public class task11test
    {
        string filePath0 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day11\\data\\exampleData0.txt";
        string filePath1 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day11\\data\\expandedGalaxyRows.txt";
        string filePath2 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day11\\data\\exampleData2.txt";
        string realFilePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day11\\data\\realData.txt";

        Hunor newGalaxy = new Hunor();

        [Fact]
        public void Should_expand_the_galaxy_rows()
        {
            // Arrange
            List<List<char>> expected = newGalaxy.ReadFileToGrid(filePath1);

            // Act
            List<List<char>> result = newGalaxy.ExpandRows(filePath0, 2);
            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_expand_the_galaxy_columns()
        {
            // Arrange
            List<List<char>> expected = newGalaxy.ReadFileToGrid(filePath2);

            // Act
            List<List<char>> result = newGalaxy.ExpanGalaxy(filePath0, 2);
            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_return_shortest_path()
        {
            // Arrange
            List<ulong> start = new List<ulong> { 6, 1 };
            List<ulong> end = new List<ulong> { 11, 5 };
            ulong expected = 9;

            // Act
            ulong result = newGalaxy.GetShortestPath(start, end);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_summ_of_all_distances()
        {
            // Act
            ulong expected = 374;

            // Act
            ulong result = newGalaxy.GetSum(filePath0, 2);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_summ_of_all_distancesR()
        {
            // Act
            ulong expected = 9545480;

            // Act
            ulong result = newGalaxy.GetSum(realFilePath, 2);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_summ_of_all_distancesONE_MILLION()
        {
            // Act
            ulong expected = 9545480;

            // Act
            ulong result = newGalaxy.GetSum(realFilePath, 1000000);

            // Assert
            result.Should().Be(expected);
        }




        private static Hunor Create()
        {
            return new Hunor();
        }
    }
}