using FluentAssertions;
using src.day12_hot_springs;
using Xunit;

namespace Day12_Hot_springs
{
    public class RecordTests
    {
        string filePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day12-hot-springs\\data\\exampleData.txt";
        string realFilePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day12-hot-springs\\data\\realData.txt";

        HotSpring newRecord = CreateHotSpring();

        [Theory]
        [InlineData("exampleData.txt")]
        public void Should_return_symbols_and_numbers(string fileName)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day12-hot-springs/data/" + fileName;

            var strings = new List<string>
            {
                { "???.###" }, { ".??..??...?##." }, { "?#?#?#?#?#?#?#?" },
                { "????.#...#..."}, { "????.######..#####." }, { "?###????????" }
            };

            var integers = new List<List<int>>
            {
                new List<int>{ 1, 1, 3 }, new List<int>{ 1, 1, 3 }, new List<int>{ 1, 3, 1, 6 },
                new List<int>{ 4, 1, 1 }, new List<int>{ 1, 6, 5 }, new List<int>{ 3, 2, 1 }
            };

            // Act
            (List<string> stringResult, List<List<int>> intResult) = newRecord.ReadFile(filePath);

            // Assert
            stringResult.Should().BeEquivalentTo(strings);
            intResult.Should().BeEquivalentTo(integers);
        }





        private static HotSpring CreateHotSpring()
        {
            return new HotSpring();
        }
    }
}
