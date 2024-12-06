using Day06.Src;
using FluentAssertions;

namespace Day06.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06.Src/testData.txt";

        [Fact]
        public void Test1()
        {
            // Arrange
            var expected = new List<List<char>>
            {
                new List<char> { '.', '.', '.', '.', '#', '.', '.', '.', '.', '.' },
                new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
                new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new List<char> { '.', '.', '#', '.', '.', '.', '.', '.', '.', '.' },
                new List<char> { '.', '.', '.', '.', '.', '.', '#', '.', '.', '.' },
                new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new List<char> { '.', '#', '.', '.', '^', '.', '.', '.', '.', '.' },
                new List<char> { '.', '.', '.', '.', '.', '.', '.', '.', '#', '.' },
                new List<char> { '#', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new List<char> { '.', '.', '.', '.', '.', '.', '#', '.', '.', '.' }
            };

            // Act
            var data = CodeSolution.ReadFile(_testData);

            // Assert
            data.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void FindGuard()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var (firstIndex, secondIndex) = CodeSolution.FindGuardPosition(data);

            // Assert
            firstIndex.Should().Be(6);
            secondIndex.Should().Be(4);
        }

        [Fact]
        public void Count()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var (firstIndex, secondIndex) = CodeSolution.FindGuardPosition(data);
            var result = CodeSolution.Count(firstIndex, secondIndex, data);

            // Assert
            result.Should().Be(41);
        }

        [Fact]
        public void Count1()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var (firstIndex, secondIndex) = CodeSolution.FindGuardPosition(data);
            var result = CodeSolution.CountLoops(firstIndex, secondIndex, data);

            // Assert
            result.Should().Be(6);
        }
    }
}