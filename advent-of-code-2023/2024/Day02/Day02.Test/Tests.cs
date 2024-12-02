using Day02.Src;
using FluentAssertions;

namespace Day02.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day02.Src/Data/testData.txt";
        private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day02.Src/Data/realData.txt";

        [Fact]
        public void Reads_The_Data()
        {
            // Arrange
            List<List<int>> listOfLists =
            [
                new() { 7, 6, 4, 2, 1 },
                new() { 1, 2, 7, 8, 9 },
                new() { 9, 7, 6, 2, 1 },
                new() { 1, 3, 2, 4, 5 },
                new() { 8, 6, 4, 4, 1 },
                new() { 1, 3, 6, 7, 9 }
            ];

            // Act
            var result = CodeSolution.ReadFile(_testData);

            // Assert
            result.Should().BeEquivalentTo(listOfLists);
        }

        [Fact]
        public void Report_Is_Safe()
        {
            // Arrange
            var matrix = CodeSolution.ReadFile(_testData);

            // Act
            var row0 = CodeSolution.ReportIsSafe(matrix[0]);
            var row1 = CodeSolution.ReportIsSafe(matrix[1]);
            var row2 = CodeSolution.ReportIsSafe(matrix[2]);
            var row3 = CodeSolution.ReportIsSafe(matrix[3]);
            var row4 = CodeSolution.ReportIsSafe(matrix[4]);
            var row5 = CodeSolution.ReportIsSafe(matrix[5]);

            //Assert
            row0.Should().Be(true);
            row1.Should().Be(false);
            row2.Should().Be(false);
            row3.Should().Be(false);
            row4.Should().Be(false);
            row5.Should().Be(true);
        }

        [Fact]
        public void Count_Safe_Reports_For_Test_Data()
        {
            // Arrange
            var matrix = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.TotalSafeReports(matrix);

            //Assert
            result.Should().Be(2);
        }

        [Fact]
        public void Count_Safe_Reports_For_Real_Data()
        {
            // Arrange
            var matrix = CodeSolution.ReadFile(_realData);

            // Act
            var result = CodeSolution.TotalSafeReports(matrix);

            // Assert
            result.Should().Be(383);
        }

        [Fact]
        public void Is_Safe_With_Removal()
        {
            // Arrange
            var matrix = CodeSolution.ReadFile(_testData);

            // Act
            var row0 = CodeSolution.IsSafeWithOneRemoval(matrix[0]);
            var row1 = CodeSolution.IsSafeWithOneRemoval(matrix[1]);
            var row2 = CodeSolution.IsSafeWithOneRemoval(matrix[2]);
            var row3 = CodeSolution.IsSafeWithOneRemoval(matrix[3]);
            var row4 = CodeSolution.IsSafeWithOneRemoval(matrix[4]);
            var row5 = CodeSolution.IsSafeWithOneRemoval(matrix[5]);

            //Assert
            row0.Should().Be(true);
            row1.Should().Be(false);
            row2.Should().Be(false);
            row3.Should().Be(true);
            row4.Should().Be(true);
            row5.Should().Be(true);
        }

        [Fact]
        public void Count_Safe_Reports_With_One_Removal_For_Test_Data()
        {
            // Arrange
            var matrix = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.TotalSafeReportsWithOneRemoval(matrix);

            //Assert
            result.Should().Be(4);
        }

        [Fact]
        public void Count_Safe_Reports_With_One_Removal_For_Real_Data()
        {
            // Arrange
            var matrix = CodeSolution.ReadFile(_realData);

            // Act
            var result = CodeSolution.TotalSafeReportsWithOneRemoval(matrix);

            // Assert
            result.Should().Be(436);
        }
    }
}
