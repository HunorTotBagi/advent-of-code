using Day01.Src;
using FluentAssertions;

namespace Day01.Test;

public class Tests
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day01.Src/Data/testData.txt";
    private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day01.Src/Data/realData.txt";

    private readonly CodeSolution _newCodeSolution = CreateCodeSolution();

    [Fact]
    public void Test1()
    {
        // Arrange
        var (arr1, arr2) = _newCodeSolution.GetArraysFromFile();

        var arr11 = new int[] {3, 4, 2, 1, 3, 3};
        var arr22 = new int[] {4, 3, 5, 3, 9, 3 };

        // Act

        // Assert
        arr1.Should().Equal(arr11);
        arr2.Should().Equal(arr22);
    }

    [Fact]
    public void Sorting()
    {
        // Arrange
        var (arr1, arr2) = _newCodeSolution.GetArraysFromFile();

        var res1 = arr1.OrderBy(x => x).ToList();
        var res2 = arr2.OrderBy(x => x).ToList();

        var expected1 = new int[] { 1, 2, 3, 3, 3, 4 };
        var expected2 = new int[] { 3, 3, 3, 4, 5, 9 };

        // Act

        // Assert
        res1.Should().Equal(expected1);
        res2.Should().Equal(expected2);
    }

    [Fact]
    public void CalcDistance()
    {
        // Arrange
        var (arr1, arr2) = _newCodeSolution.GetArraysFromFile();

        var res1 = arr1.OrderBy(x => x).ToArray();
        var res2 = arr2.OrderBy(x => x).ToArray();

        var checking = _newCodeSolution.CalculateDistance(res1, res2);

        var expected = new int[] { 2, 1, 0, 1, 2, 5 };

        // Act

        // Assert
        checking.Should().Equal(expected);
    }

    [Fact]
    public void Finalnaswer()
    {
        // Arrange
        var (arr1, arr2) = _newCodeSolution.GetArraysFromFile();

        var res1 = arr1.OrderBy(x => x).ToArray();
        var res2 = arr2.OrderBy(x => x).ToArray();

        var checking = _newCodeSolution.CalculateDistance(res1, res2);

        var final = _newCodeSolution.SummItUp(checking);

        // Act

        // Assert
        final.Should().Be(11);
    }

    [Fact]
    public void SecondPart()
    {
        // Arrange
        var (arr1, arr2) = _newCodeSolution.GetArraysFromFile();

        var result = _newCodeSolution.GetSimilarityScore(arr1, arr2);

        // Act

        // Assert
        result.Should().Be(31);
    }

    public static CodeSolution CreateCodeSolution()
    {
        return new CodeSolution();
    }
}
