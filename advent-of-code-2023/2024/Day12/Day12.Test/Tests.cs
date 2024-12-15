using Day12.Src;
using FluentAssertions;

namespace Day12.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day12.Src/testData.txt";
        private readonly string _testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day12.Src/testData1.txt";
        private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day12.Src/realData.txt";


        [Fact]
        public void ReadFile()
        {
            // Arrange
            var expected = new List<List<char>>
            {
                new() { 'A', 'A', 'A', 'A' },
                new() { 'B', 'B', 'C', 'D' },
                new() { 'B', 'B', 'C', 'C' },
                new() { 'E', 'E', 'E', 'C' },

            };

            // Act
            var result = CodeSolution.ReadFile(_testData);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetRegions()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);
            var expected = new List<List<char>>
            {
                new() { 'A', 'A', 'A', 'A' },
                new() { 'B', 'B', 'C', 'D' },
                new() { 'B', 'B', 'C', 'C' },
                new() { 'E', 'E', 'E', 'C' },

            };

            // Act
            var result = CodeSolution.FloodFill(data);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }


    }
}