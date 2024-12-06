using Day06.Src;
using FluentAssertions;

namespace Day06.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06.Src/testData.txt";

        [Fact]
        public void Read_Data()
        {
            // Arrange
            var expected = new List<List<char>>
            {
                new() { '.', '.', '.', '.', '#', '.', '.', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
                new() { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new() { '.', '.', '#', '.', '.', '.', '.', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '#', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new() { '.', '#', '.', '.', '^', '.', '.', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '.', '.', '#', '.' },
                new() { '#', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '#', '.', '.', '.' }
            };

            // Act
            var data = CodeSolution.ReadFile(_testData);

            // Assert
            data.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Find_Guard_Position()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var (positionX, positionY) = CodeSolution.FindGuardPosition(data);

            // Assert
            positionX.Should().Be(6);
            positionY.Should().Be(4);
        }

        [Fact]
        public void Count_Visited_Places()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var (positionX, positionY) = CodeSolution.FindGuardPosition(data);
            var result = CodeSolution.CountVisitedPlaces(positionX, positionY, data);

            // Assert
            result.Should().Be(41);
        }

        [Fact]
        public void Count_Infinite_Loop_When_New_Obstacle_Is_Added()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var (positionX, positionY) = CodeSolution.FindGuardPosition(data);
            var result = CodeSolution.CountInfiniteLoops(positionX, positionY, data);

            // Assert
            result.Should().Be(6);
        }
    }
}