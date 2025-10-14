using Day14.Src;
using FluentAssertions;

namespace Day14.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day14.Src/testData.txt";
        private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day14.Src/realData.txt";

        [Fact]
        public void ReadFile()
        {
            // Arrange
            var expectedPositions = new List<List<int>>()
            {
                new() { 0, 4 }, new() { 6, 3 }, new() { 10, 3 },
                new() { 2, 0 }, new() { 0, 0 }, new() { 3, 0 },
                new() { 7, 6 }, new() { 3, 0 }, new() { 9, 3 },
                new() { 7, 3 }, new() { 2, 4 }, new() { 9, 5 },
            };

            var expectedVelocities = new List<List<int>>()
            {
                new() { 3, -3 }, new() { -1, -3 }, new() { -1, 2 },
                new() { 2, -1 }, new() { 1, 3 }, new() { -2, -2 },
                new() { -1, -3 }, new() { -1, -2 }, new() { 2, 3 },
                new() { -1, 2 }, new() { 2, -3 }, new() { -3, -3 },
            };

            // Act
            var (positions, velocities) = Solution.ReadFile(_testData);

            // Assert
            positions.Should().BeEquivalentTo(expectedPositions);
            velocities.Should().BeEquivalentTo(expectedVelocities);
        }

        [Fact]
        public void GetResuls()
        {
            // Arrange
            var (pos, vel) = Solution.ReadFile(_testData);
            var finalPos = Solution.Calculate(100, 11, 7, pos, vel);


            // Act
            var result = Solution.Quadrants(11, 7, finalPos);

            // Assert
            result.Should().Be(12);
        }
    }
}
