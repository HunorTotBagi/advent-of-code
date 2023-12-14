using FluentAssertions;
using src.day13;
using Xunit;

namespace test.day13
{
    public class task13test
    {
        string realData = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day13\\data\\realData.txt";
        string testData = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day13\\data\\testData.txt";

        MirrorReflectionAnalyzer newMirrorReflectionAnalyzer = CreateMirrorReflectionAnalyzer();

        [Theory]
        [InlineData(0)]
        public void Should_return_slice_ROW(int expected)
        {
            // Arrange
            List<List<List<char>>> matrix = newMirrorReflectionAnalyzer.ConvertFileToMatrixBlocks(testData);

            // Act
            int result = newMirrorReflectionAnalyzer.CalculateHorizontalReflectionScore(matrix[0]);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(5)]
        public void Should_return_slice_COL(int expected)
        {
            // Arrange
            List<List<List<char>>> matrix = newMirrorReflectionAnalyzer.ConvertFileToMatrixBlocks(testData);

            // Act
            int result = newMirrorReflectionAnalyzer.CalculateVerticalReflectionScore(matrix[0]);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_result_test()
        {
            // Act
            int result = newMirrorReflectionAnalyzer.CalculateReflectionScore(testData);

            // Assert
            result.Should().Be(405);
        }

        [Fact]
        public void Should_return_result()
        {
            // Act
            int result = newMirrorReflectionAnalyzer.CalculateReflectionScore(realData);

            // Assert
            result.Should().Be(33520);
        }

        private static MirrorReflectionAnalyzer CreateMirrorReflectionAnalyzer()
        {
            return new MirrorReflectionAnalyzer();
        }
    }
}