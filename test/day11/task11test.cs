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
            List<List<char>> result = newGalaxy.ExpandRows(filePath0);
            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_expand_the_galaxy_columns()
        {
            // Arrange
            List<List<char>> expected = newGalaxy.ReadFileToGrid(filePath2);

            // Act
            List<List<char>> result = newGalaxy.ExpanGalaxy(filePath0);
            // Assert
            result.Should().BeEquivalentTo(expected);
        }





        //[Theory]
        //[InlineData("asd")]
        //public void Should1(string fileName)
        //{
        //    // Arrange
        //    var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day11/data/" + fileName;

        //    // Act

        //    // Assert
        //}



        private static Hunor Create()
        {
            return new Hunor();
        }
    }
}