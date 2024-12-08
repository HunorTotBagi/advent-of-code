using Day08.Src;
using FluentAssertions;

namespace Day08.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day08.Src/testData.txt";

        [Fact]
        public void Read_Grid_From_File()
        {
            // Arrange
            var expected = new List<List<char>>
            {
                new() { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '.', '.', '0', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '0', '.', '.', '.', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '.', '0', '.', '.', '.', '.' },
                new() { '.', '.', '.', '.', '0', '.', '.', '.', '.', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', 'A', '.', '.', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '.', '.', 'A', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '.', '.', '.', 'A', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new() { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
            };

            // Act
            var data = CodeSolution.ReadGridFromFile(_testData);

            // Assert
            data.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(-1, 5, false)]
        [InlineData(0, 3, true)]
        [InlineData(3, 11, true)]
        [InlineData(1, 0, true)]
        [InlineData(3, 12, false)]
        public void Is_Point_In_Bounds(int x, int y, bool expectedResult)
        {
            // Arrange
            var data = CodeSolution.ReadGridFromFile(_testData);
            var coordinate = new List<int> { x, y };

            // Act
            var result = CodeSolution.IsPointInBounds(coordinate, data);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Get_Unique_Antennas()
        {
            // Arrange
            var data = CodeSolution.ReadGridFromFile(_testData);
            var expected = new HashSet<char> { '0', 'A' };

            // Act
            var uniqueCharacters = CodeSolution.GetUniqueAntennas(data);

            // Assert
            uniqueCharacters.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Find_All_Antenna_Positions()
        {
            // Arrange
            var data = CodeSolution.ReadGridFromFile(_testData);

            var expected = new List<List<int>>
            {
                new(){ 8,1 },
                new(){ 5,2 },
                new(){ 7,3 },
                new(){ 4,4 },
            };

            // Act
            var antennaPositions = CodeSolution.FindAllAntennaPositions('0', data);

            // Assert
            antennaPositions.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(3, 3, 2, 6, new[] { 2, 0 }, new[] { 3, 9 })]
        [InlineData(2, 3, 3, 6, new[] { 1, 0 }, new[] { 4, 9 })]
        [InlineData(1, 8, 2, 5, new[] { 0, 11 }, new[] { 3, 2 })]
        public void Generate_Antinode_Positions(int firstX, int firstY, int secondX, int secondY, int[] expected1, int[] expected2)
        {
            // Arrange
            var first = new List<int> { firstX, firstY };
            var second = new List<int> { secondX, secondY };
            var expected = new List<List<int>>
            {
                new() { expected1[0], expected1[1] },
                new() { expected2[0], expected2[1] }
            };

            // Act
            var result = CodeSolution.GenerateAntinodePositions(first, second);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Calculate()
        {
            // Arrange
            var data = CodeSolution.ReadGridFromFile(_testData);

            // Act
            var result = CodeSolution.Calculate(data);

            // Assert
            result.Should().Be(14);
        }

        [Fact]
        public void Calculate_Overloaded()
        {
            // Arrange
            var data = CodeSolution.ReadGridFromFile(_testData);

            // Act
            var result = CodeSolution.CalculateAdvanced(data);

            // Assert
            result.Should().Be(34);
        }
    }
}