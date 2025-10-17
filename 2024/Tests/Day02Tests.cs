using FluentAssertions;
using Src.Day02;

namespace Tests;

public class Day02Tests
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Src/Day02/testData.txt";

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
        var result = Solution.ReadFile(_testData);

        // Assert
        result.Should().BeEquivalentTo(listOfLists);
    }

    [Fact]
    public void Report_Is_Safe()
    {
        // Arrange
        var matrix = Solution.ReadFile(_testData);

        // Act
        var row0 = Solution.ReportIsSafe(matrix[0]);
        var row1 = Solution.ReportIsSafe(matrix[1]);
        var row2 = Solution.ReportIsSafe(matrix[2]);
        var row3 = Solution.ReportIsSafe(matrix[3]);
        var row4 = Solution.ReportIsSafe(matrix[4]);
        var row5 = Solution.ReportIsSafe(matrix[5]);

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
        var matrix = Solution.ReadFile(_testData);

        // Act
        var result = Solution.TotalSafeReports(matrix);

        //Assert
        result.Should().Be(2);
    }

    [Fact]
    public void Is_Safe_With_Removal()
    {
        // Arrange
        var matrix = Solution.ReadFile(_testData);

        // Act
        var row0 = Solution.IsSafeWithOneRemoval(matrix[0]);
        var row1 = Solution.IsSafeWithOneRemoval(matrix[1]);
        var row2 = Solution.IsSafeWithOneRemoval(matrix[2]);
        var row3 = Solution.IsSafeWithOneRemoval(matrix[3]);
        var row4 = Solution.IsSafeWithOneRemoval(matrix[4]);
        var row5 = Solution.IsSafeWithOneRemoval(matrix[5]);

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
        var matrix = Solution.ReadFile(_testData);

        // Act
        var result = Solution.TotalSafeReportsWithOneRemoval(matrix);

        //Assert
        result.Should().Be(4);
    }
}
