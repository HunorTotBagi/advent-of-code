using Day14.Src;
using FluentAssertions;

namespace Day14.Test;

public class Tests
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day14.Src/Data/testData.txt";

    [Theory]
    [InlineData(0, "testDataROW0.txt")]
    [InlineData(1, "testDataROW1.txt")]
    [InlineData(2, "testDataROW2.txt")]
    [InlineData(3, "testDataROW3.txt")]
    [InlineData(4, "testDataROW4.txt")]
    [InlineData(5, "testDataROW5.txt")]
    public void Row_tests(int colIndex, string fileName)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day14.Src/Data/" + fileName;
        var matrix = CodeSolution.LoadMatrixFromFile(_testData);
        var expected = CodeSolution.LoadMatrixFromFile(filePath);

        // Act
        var result = CodeSolution.SlideRocksNorthInColumn(matrix, colIndex);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Should_return_sum()
    {
        // Arrange
        var matrix = CodeSolution.LoadMatrixFromFile(_testData);

        // Act
        var result = CodeSolution.CalculateTotalLoad(matrix);

        // Assert
        result.Should().Be(136);
    }
}
