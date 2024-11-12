using Day14.Src;
using FluentAssertions;

namespace Day14.Test;

public class task14test
{
    string realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day14.Src/Data/realData.txt";
    string testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day14.Src/Data/testData.txt";

    Hunor newHunor = CreateHunor();

    [Theory]
    [InlineData(0, "C:\\Users\\htotbagi\\Downloads\\advent - of - code\\advent - of - code - 2023\\2023\\Day14\\Day14.Src\\Data\\testDataROW0.txt")]
    [InlineData(1, "C:\\Users\\htotbagi\\Downloads\\advent - of - code\\advent - of - code - 2023\\2023\\Day14\\Day14.Src\\Data\\testDataROW1.txt")]
    [InlineData(2, "C:\\Users\\htotbagi\\Downloads\\advent - of - code\\advent - of - code - 2023\\2023\\Day14\\Day14.Src\\Data\\testDataROW2.txt")]
    [InlineData(3, "C:\\Users\\htotbagi\\Downloads\\advent - of - code\\advent - of - code - 2023\\2023\\Day14\\Day14.Src\\Data\\testDataROW3.txt")]
    [InlineData(4, "C:\\Users\\htotbagi\\Downloads\\advent - of - code\\advent - of - code - 2023\\2023\\Day14\\Day14.Src\\Data\\testDataROW4.txt")]
    [InlineData(5, "C:\\Users\\htotbagi\\Downloads\\advent - of - code\\advent - of - code - 2023\\2023\\Day14\\Day14.Src\\Data\\testDataROW5.txt")]
    public void Row_tests(int colIndex, string filePath)
    {
        // Arrange
        List<List<char>> matrix = newHunor.LoadMatrixFromFile(testData);
        List<List<char>> expected = newHunor.LoadMatrixFromFile(filePath);

        // Act
        List<List<char>> result = newHunor.SlideRocksNorthInColumn(matrix, colIndex);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Should_return_sum()
    {
        List<List<char>> matrix = newHunor.LoadMatrixFromFile(testData);
        int result = newHunor.CalculateTotalLoad(matrix);

        result.Should().Be(136);
    }

    [Fact]
    public void Should_return_sum_real()
    {
        List<List<char>> matrix = newHunor.LoadMatrixFromFile(realData);
        int result = newHunor.CalculateTotalLoad(matrix);

        result.Should().Be(112048);
    }

    private static Hunor CreateHunor()
    {
        return new Hunor();
    }
}