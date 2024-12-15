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
                new List<char> { 'A', 'A', 'A', 'A' },
                new List<char> { 'B', 'B', 'C', 'D' },
                new List<char> { 'B', 'B', 'C', 'C' },
                new List<char> { 'E', 'E', 'E', 'C' },

            };

            // Act
            var result = CodeSolution.ReadFile(_testData);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetUniqueCharacter()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);
            var expected = new HashSet<char> { 'A', 'B', 'C', 'D', 'E'};

            // Act
            var result = CodeSolution.GetUniqueCharacter(data);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetArea()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.GetArea('A', data);

            // Assert
            result.Should().Be(4);
        }

        [Theory]
        [InlineData('A', 10)]
        [InlineData('B', 8)]
        [InlineData('C', 10)]
        [InlineData('D', 4)]
        [InlineData('E', 8)]
        public void GetPerimeter(char flower, int expected)
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.GetPerimeter(flower, data);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Calculate()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.CalculateTotalPrice(data);

            // Assert
            result.Should().Be(140);
        }

        [Fact]
        public void CalculateTD1()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_realData);

            // Act
            var result = CodeSolution.CalculateTotalPrice(data);

            // Assert
            result.Should().Be(1930);
        }
    }
}