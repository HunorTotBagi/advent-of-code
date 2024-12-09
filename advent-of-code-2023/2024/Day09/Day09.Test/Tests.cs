using Day09.Src;
using FluentAssertions;

namespace Day09.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day09.Src/testData.txt";

        [Fact]
        public void ReadFile()
        {
            // Arrange
            var expected = new List<ulong> { 2, 3, 3, 3, 1, 3, 3, 1, 2, 1, 4, 1, 4, 1, 3, 1, 4, 0, 2 };

            // Act
            var data = CodeSolution.ReadFile(_testData);

            // Assert
            data.Should().Equal(expected);
        }

        [Fact]
        public void CountDOts()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.CountTheDots(data);

            // Assert
            result.Should().Be(14);
        }

        [Fact]
        public void CalculatePartOne()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.CalculatePartOne(data);

            // Assert
            result.Should().Be(1928);
        }

        [Fact]
        public void SwapChunks()
        {
            // Arrange
            var expected = new List<string>()
            {
                "0", "0", "9", "9", "2", "1", "1", "1", "7", "7", "7",
                ".", "4", "4", ".", "3", "3", "3", ".", ".", ".", ".",
                "5", "5", "5", "5", ".", "6", "6", "6", "6", ".", ".", ".",
                ".", ".", "8", "8", "8", "8", ".", "."
            };

            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.SwapChunksCorrectLogic(data);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void CalculatePartTwo_Real_Data()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.CalculatePartTwo(data);

            // Assert
            result.Should().Be(2858);
        }
    }
}
