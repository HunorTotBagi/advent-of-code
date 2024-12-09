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
        public void ConvertToDots()
        {
            // Arrange
            var expected = "00...111...2...333.44.5555.6666.777.888899";
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.ConvertToDots(data);

            // Assert
            //result.Should().Be(expected);
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
        public void SwapDots()
        {
            // Arrange
            var expected = "0099811188827773336446555566..............";
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.SwapDots(data);

            // Assert
            //result.Should().Be(expected);
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

        //[Fact]
        //public void CalculatePartTwo()
        //{
        //    // Arrange
        //    var data = CodeSolution.ReadFile(_testData);

        //    // Act
        //    var result = CodeSolution.CalculatePartTwo(data);

        //    // Assert
        //    result.Should().Be(5);
        //}
    }
}
