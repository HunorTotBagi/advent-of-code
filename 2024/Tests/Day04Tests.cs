using FluentAssertions;
using Src.Day04;

namespace Tests;

public class Day04Tests
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Src/Day04/testData.txt";

    [Fact]
    public void Reads_Data()
    {
        // Arrange
        var expected = new List<List<char>>
        {
            new() { 'M', 'M', 'M', 'S', 'X', 'X', 'M', 'A', 'S', 'M' },
            new() { 'M', 'S', 'A', 'M', 'X', 'M', 'S', 'M', 'S', 'A' },
            new() { 'A', 'M', 'X', 'S', 'X', 'M', 'A', 'A', 'M', 'M' },
            new() { 'M', 'S', 'A', 'M', 'A', 'S', 'M', 'S', 'M', 'X' },
            new() { 'X', 'M', 'A', 'S', 'A', 'M', 'X', 'A', 'M', 'M' },
            new() { 'X', 'X', 'A', 'M', 'M', 'X', 'X', 'A', 'M', 'A' },
            new() { 'S', 'M', 'S', 'M', 'S', 'A', 'S', 'X', 'S', 'S' },
            new() { 'S', 'A', 'X', 'A', 'M', 'A', 'S', 'A', 'A', 'A' },
            new() { 'M', 'A', 'M', 'M', 'M', 'X', 'M', 'M', 'M', 'M' },
            new() { 'M', 'X', 'M', 'X', 'A', 'X', 'M', 'A', 'S', 'X' }
        };

        // Act
        var result = Solution.ReadFile(_testData);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Counts_Horizontal()
    {
        // Arrange
        var data = Solution.ReadFile(_testData);

        // Act
        var result = Solution.Horizontal(data);

        // Assert
        result.Should().Be(3);
    }

    [Fact]
    public void Counts_Horizontal_Backwards()
    {
        // Arrange
        var data = Solution.ReadFile(_testData);

        // Act
        var result = Solution.HorizontalBackwards(data);

        // Assert
        result.Should().Be(2);
    }

    [Fact]
    public void Counts_Vertical()
    {
        // Arrange
        var data = Solution.ReadFile(_testData);

        // Act
        var result = Solution.Vertical(data);

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public void Counters_Vertical_Backwards()
    {
        // Arrange
        var data = Solution.ReadFile(_testData);

        // Act
        var result = Solution.VerticalBackwards(data);

        // Assert
        result.Should().Be(2);
    }

    [Fact]
    public void Counts_Diagonal_1()
    {
        // Arrange
        var data = Solution.ReadFile(_testData);

        // Act
        var result = Solution.Diagonal1(data);

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public void Counts_Diagonal_1_Backwards()
    {
        // Arrange
        var data = Solution.ReadFile(_testData);

        // Act
        var result = Solution.Diagonal1Backwards(data);

        // Assert
        result.Should().Be(4);
    }

    [Fact]
    public void Counts_Diagonal_2()
    {
        // Arrange
        var data = Solution.ReadFile(_testData);

        // Act
        var result = Solution.Diagonal2(data);

        // Assert
        result.Should().Be(4);
    }

    [Fact]
    public void Counts_Diagonal_2_Backwards()
    {
        // Arrange
        var data = Solution.ReadFile(_testData);

        // Act
        var result = Solution.Diagonal2Backwards(data);

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public void Counts_All_Occurrences_Test_Data()
    {
        // Arrange
        var data = Solution.ReadFile(_testData);

        // Act
        var result = Solution.GetAllXmas(data);

        // Assert
        result.Should().Be(18);
    }

    [Fact]
    public void Counts_All_Occurrences_X_Shaped_Mas_Test_Data()
    {
        // Arrange
        var data = Solution.ReadFile(_testData);

        // Act
        var result = Solution.Result(data);

        // Assert
        result.Should().Be(9);
    }
}
