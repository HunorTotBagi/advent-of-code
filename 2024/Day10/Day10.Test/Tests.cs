using Day10.Src;
using FluentAssertions;

namespace Day10.Test
{
    public class Tests
    {
        private readonly string _testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day10.Src/testData0.txt";
        private readonly string _testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day10.Src/testData1.txt";

        [Fact]
        public void ReadFile()
        {
            // Arrange
            var expected = new List<List<int>>
            {
                new() { 0, 1, 2, 3 },
                new() { 1, 2, 3, 4 },
                new() { 8, 7, 6, 5 },
                new() { 9, 8, 7, 6 }
            };

            // Act
            var data = Solution.ReadFile(_testData0);

            // Assert
            data.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SumTrailheadScores()
        {
            // Arrange
            var data = Solution.ReadFile(_testData1);

            // Act
            var result = Solution.SumTrailheadScores(data);

            // Assert
            result.Should().Be(36);
        }

        [Fact]
        public void SumTrailheadRatings()
        {
            // Arrange
            var data = Solution.ReadFile(_testData1);

            // Act
            var result = Solution.SumTrailheadRatings(data);

            // Assert
            result.Should().Be(81);
        }
    }
}
