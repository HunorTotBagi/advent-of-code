using Day09.Src;
using FluentAssertions;

namespace Day09.Test
{
    public class Tests
    {
        private readonly string _testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day09.Src/testData0.txt";

        [Fact]
        public void ReadFile()
        {
            // Arrange
            var expected = new List<ulong> { 2, 3, 3, 3, 1, 3, 3, 1, 2, 1, 4, 1, 4, 1, 3, 1, 4, 0, 2 };

            // Act
            var data = Solution.ReadFile(_testData0);

            // Assert
            data.Should().Equal(expected);
        }

        [Theory]
        [InlineData("00...111...2...333.44.5555.6666.777.888899", "testData0.txt")]
        [InlineData("0..111....22222", "testData1.txt")]
        public void ConvertToDotsTheory(string expectedData, string fileName)
        {
            // Arrange
            var testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day09.Src/" + fileName;

            var expected = ConvertStringToStringList(expectedData);
            var data = Solution.ReadFile(testData);

            // Act
            var result = Solution.ConvertToBlockOfFilesAndSpaces(data);

            // Assert
            result.Should().Equal(expected);
        }

        [Theory]
        [InlineData("0099811188827773336446555566..............", "testData0.txt")]
        [InlineData("022111222......", "testData1.txt")]
        public void SwapDots(string expectedData, string fileName)
        {
            // Arrange
            var testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day09.Src/" + fileName;

            var expected = ConvertStringToStringList(expectedData);
            var data = Solution.ReadFile(testData);

            // Act
            var result = Solution.SwapDots(data);

            // Assert
            result.Should().Equal(expected);
        }

        [Fact]
        public void CalculatePartOne()
        {
            // Arrange
            var data = Solution.ReadFile(_testData0);

            // Act
            var result = Solution.CalculatePartOne(data);

            // Assert
            result.Should().Be(1928);
        }

        [Fact]
        public void CalculatePartTwo_Real_Data()
        {
            // Arrange
            var data = Solution.ReadFile(_testData0);

            // Act
            var result = Solution.CalculatePartTwo(data);

            // Assert
            result.Should().Be(2858);
        }

        private static List<string> ConvertStringToStringList(string v)
        {
            var result = new List<string>();

            foreach (var c in v)
                result.Add(c.ToString());

            return result;
        }
    }
}
