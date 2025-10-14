using Day15.Src;
using FluentAssertions;

namespace Day15.Test
{
    public class Tests
    {

        private readonly string _testDataLargeMap = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testDataLargeMap.txt";
        private readonly string _testDataLargeMoves = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testDataLargeMoves.txt";

        [Fact]
        public void CalculateGPS()
        {
            // Arrange
            var map = Solution.ReadMap(_testDataLargeMap);
            var moves = Solution.ReadMoves(_testDataLargeMoves);

            var expected = Solution.ApplyAllMoves(map, moves);

            // Act
            var result = Solution.CalculateGps(expected);

            // Assert
            result.Should().Be(10092);
        }
    }
}
