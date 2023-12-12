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

        [Fact]
        public void Should()
        {
            // Arrange
            (List<string> stringResult, List<List<int>> intResult) = newRecord.ReadFile(filePath);
            List<string> expected = new List<string>{".##.###", "#.#.###", "##..###"};

            // Act
            List<string> result = newRecord.SelectStringsWithMatching(stringResult[0] ,intResult[0]);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should1()
        {
            // Arrange
            (List<string> stringResult, List<List<int>> intResult) = newRecord.ReadFile(filePath);
            List<string> expected = new List<string> { ".##.###", "#.#.###", "##..###" };

            // Act
            List<string> result = newRecord.SelectStringsWithMatching(stringResult[1], intResult[1]);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("???.###", new int[] { 1, 1, 3 }, 1)]
        [InlineData(".??..??...?##.", new int[] { 1, 1, 3 }, 4)]
        [InlineData("?#?#?#?#?#?#?#?", new int[] { 1, 3, 1, 6 }, 1)]
        [InlineData("????.#...#...", new int[] { 4, 1, 1 }, 1)]
        [InlineData("????.######..#####.", new int[] { 1, 6, 5 }, 4)]
        [InlineData("?###????????", new int[] { 3, 2, 1 }, 10)]
        public void Should_general_test(string input, int[] numbers, int expected)
        {
            int result = newRecord.FinalComibinations(input, numbers);

            result.Should().Be(expected);
        }


        [Fact]
        public void Should_get_final_result()
        {
            // Act
            int result = newRecord.GetFinalAnswer(filePath);

            // Assert
            result.Should().Be(21);
        }




        private static HotSpring CreateHotSpring()
        {
            return new HotSpring();
        }
    }
}
