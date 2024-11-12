using Day13.Src;
using FluentAssertions;

namespace Day13.Test;

public class Tests
{
    string realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day13.Src/Data/realData.txt";
    string testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day13.Src/Data/testData.txt";

    MirrorReflectionAnalyzer newMirrorReflectionAnalyzer = CreateMirrorReflectionAnalyzer();

    [Theory]
    [InlineData(0)]
    public void Should_return_slice_ROW(int expected)
    {
        // Arrange
        List<List<List<char>>> matrix = newMirrorReflectionAnalyzer.ConvertFileToMatrixBlocks(testData);

        // Act
        var result = newMirrorReflectionAnalyzer.CalculateHorizontalReflectionScore(matrix[0]);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(5)]
    public void Should_return_slice_COL(int expected)
    {
        // Arrange
        List<List<List<char>>> matrix = newMirrorReflectionAnalyzer.ConvertFileToMatrixBlocks(testData);

        // Act
        var result = newMirrorReflectionAnalyzer.CalculateVerticalReflectionScore(matrix[0]);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Should_return_result_test()
    {
        // Act
        var result = newMirrorReflectionAnalyzer.CalculateReflectionScore(testData);

        // Assert
        result.Should().Be(405);
    }

    [Fact]
    public void Should_return_result()
    {
        // Act
        var result = newMirrorReflectionAnalyzer.CalculateReflectionScore(realData);

        // Assert
        result.Should().Be(33520);
    }

    private static MirrorReflectionAnalyzer CreateMirrorReflectionAnalyzer()
    {
        return new MirrorReflectionAnalyzer();
    }
}