using Day15.Src;
using FluentAssertions;

namespace Day15.Test
{
    public class Tests
    {
        private readonly string _testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testData0.txt";
        private readonly string _testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testData1.txt";
        private readonly string _testData2 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testData2.txt";
        private readonly string _testData3 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testData3.txt";
        private readonly string _testData4 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testData4.txt";
        private readonly string _testDataLargeMap = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testDataLargeMap.txt";
        private readonly string _testDataLargeMoves = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testDataLargeMoves.txt";
        private readonly string _testDataLargeResult = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testDataLargeResult.txt";
        private readonly string _testData5final = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testData5final.txt";

        private readonly string _testDataLargeMapReal = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testDataLargeMapReal.txt";
        private readonly string _testDataLargeMovesReal = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testDataLargeMovesReal.txt";

        [Fact]
        public void ReadFile()
        {
            // Arrange
            var expected = 5;

            // Act
            var result = CodeSolution.ReadFile(_testData0);
            var moves = CodeSolution.ReadMoves(_testData1);

            var a = 1;
            // Assert
            //result.Should().Be(expected);
            //result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void CountStonesData2()
        {
            // Arrange
            var map = CodeSolution.ReadFile(_testData2);
            var moves = CodeSolution.ReadMoves(_testData1);

            // Act
            var result = CodeSolution.CountStonesInThatDirection(map, '>', 1, 3);

            // Assert
            result.Should().Be(2);
        }

        [Fact]
        public void CountStonesData3()
        {
            // Arrange
            var map = CodeSolution.ReadFile(_testData3);

            // Act
            var result = CodeSolution.CountStonesInThatDirection(map, 'v', 1, 4);

            // Assert
            result.Should().Be(4);
        }

        [Fact]
        public void MoveStonesData2()
        {
            // Arrange
            var map = CodeSolution.ReadFile(_testData2);
            var numberOfStones = CodeSolution.CountStonesInThatDirection(map, '>', 1, 3);
            var expected = CodeSolution.ReadFile(_testData3);

            // Act
            var result = CodeSolution.MoveStonesByOnePlace(map, 1, 3, numberOfStones, '>');

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void MoveStonesData3()
        {
            // Arrange
            var map = CodeSolution.ReadFile(_testData3);
            var numberOfStones = CodeSolution.CountStonesInThatDirection(map, 'v', 1, 4);
            var expected = CodeSolution.ReadFile(_testData4);

            // Act
            var result = CodeSolution.MoveStonesByOnePlace(map, 1, 4, numberOfStones, 'v');

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ApplyAllOnSmallData()
        {
            // Arrange
            var map = CodeSolution.ReadFile(_testData0);
            var moves = CodeSolution.ReadMoves(_testData1);
            var expected = CodeSolution.ReadFile(_testData5final);

            // Act
            var result = CodeSolution.ApplyAllMoves(map, moves);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ApplyAllOnLargeData()
        {
            // Arrange
            var map = CodeSolution.ReadFile(_testDataLargeMap);
            var moves = CodeSolution.ReadMoves(_testDataLargeMoves);
            var expected = CodeSolution.ReadFile(_testDataLargeResult);

            // Act
            var result = CodeSolution.ApplyAllMoves(map, moves);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void CalcGPS()
        {
            // Arrange
            var map = CodeSolution.ReadFile(_testDataLargeMap);
            var moves = CodeSolution.ReadMoves(_testDataLargeMoves);

            var expected = CodeSolution.ApplyAllMoves(map, moves);

            // Act
            var result = CodeSolution.CalculateGPS(expected);

            // Assert
            result.Should().Be(10092);
        }

        [Fact]
        public void CalcGPSREAL()
        {
            // Arrange
            var map = CodeSolution.ReadFile(_testDataLargeMapReal);
            var moves = CodeSolution.ReadMoves(_testDataLargeMovesReal);

            var expected = CodeSolution.ApplyAllMoves(map, moves);

            // Act
            var result = CodeSolution.CalculateGPS(expected);

            // Assert
            result.Should().Be(10092);
        }
    }
}
