using Day01.Src;
using FluentAssertions;

namespace Day01.Test;

public class Tests
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day01.Src/Data/testData.txt";
    private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day01.Src/Data/realData.txt";

    private readonly CodeSolution _newCodeSolution = CreateCodeSolution();

    [Fact]
    public void Data_Is_Loaded_Correctly()
    {
        // Arrange
        var expectedArray1 = new[] {3, 4, 2, 1, 3, 3};
        var expectedArray2 = new[] {4, 3, 5, 3, 9, 3 };

        // Act
        var (array1, array2) = _newCodeSolution.GetArraysFromFile(_testData);

        // Assert
        array1.Should().Equal(expectedArray1);
        array2.Should().Equal(expectedArray2);
    }

    [Fact]
    public void Arrays_Are_Sorted()
    {
        // Arrange
        var (array1, array2) = _newCodeSolution.GetArraysFromFile(_testData);

        var expectedArray1 = new[] { 1, 2, 3, 3, 3, 4 };
        var expectedArray2 = new[] { 3, 3, 3, 4, 5, 9 };

        // Act
        array1 = _newCodeSolution.SortTheArray(array1);
        array2 = _newCodeSolution.SortTheArray(array2);

        // Assert
        array1.Should().Equal(expectedArray1);
        array2.Should().Equal(expectedArray2);
    }

    [Fact]
    public void Calculate_Distance()
    {
        // Arrange
        var (array1, array2) = _newCodeSolution.GetArraysFromFile(_testData);

        array1 = _newCodeSolution.SortTheArray(array1);
        array2 = _newCodeSolution.SortTheArray(array2);

        var expected = new[] { 2, 1, 0, 1, 2, 5 };

        // Act
        var distance = _newCodeSolution.CalculateDistance(array1, array2);

        // Assert
        distance.Should().Equal(expected);
    }

    [Fact]
    public void Total_Distance_Test_Data()
    {
        // Arrange
        var (array1, array2) = _newCodeSolution.GetArraysFromFile(_testData);

        array1 = _newCodeSolution.SortTheArray(array1);
        array2 = _newCodeSolution.SortTheArray(array2);

        var distance = _newCodeSolution.CalculateDistance(array1, array2);

        // Act
        var totalDistance = _newCodeSolution.SumItUp(distance);

        // Assert
        totalDistance.Should().Be(11);
    }

    [Fact]
    public void Total_Distance_Real_Data()
    {
        // Arrange
        var (array1, array2) = _newCodeSolution.GetArraysFromFile(_realData);

        array1 = _newCodeSolution.SortTheArray(array1);
        array2 = _newCodeSolution.SortTheArray(array2);

        var distance = _newCodeSolution.CalculateDistance(array1, array2);

        // Act
        var totalDistance = _newCodeSolution.SumItUp(distance);

        // Assert
        totalDistance.Should().Be(1873376);
    }

    [Fact]
    public void Calculate_Similarity_Score_Test_Data()
    {
        // Arrange
        var (array1, array2) = _newCodeSolution.GetArraysFromFile(_testData);

        // Act
        var similarityScore = _newCodeSolution.GetSimilarityScore(array1, array2);

        // Assert
        similarityScore.Should().Be(31);
    }

    [Fact]
    public void Calculate_Similarity_Score_Real_Data()
    {
        // Arrange
        var (array1, array2) = _newCodeSolution.GetArraysFromFile(_realData);

        // Act
        var similarityScore = _newCodeSolution.GetSimilarityScore(array1, array2);

        // Assert
        similarityScore.Should().Be(18997088);
    }

    public static CodeSolution CreateCodeSolution()
    {
        return new CodeSolution();
    }
}
