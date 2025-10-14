using Day10.Src;
using FluentAssertions;

namespace Day10.Test;

public class PipeTests
{
    Solution newPipe = CreatePipe();

    readonly string _testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day10.Src/testData0.txt";
    readonly string _testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day10.Src/testData1.txt";
    readonly string _testData2 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day10.Src/testData2.txt";

    [Fact]
    public void Should_read_text_file()
    {
        // Arrange
        List<List<char>> expected = new List<List<char>>
            {
                new List<char> { '.', '.', '.', '.', '.'},
                new List<char> { '.', 'S', '-', '7', '.',},
                new List<char> { '.', '|', '.', '|', '.'},
                new List<char> { '.', 'L', '-', 'J', '.'},
                new List<char> { '.', '.', '.', '.', '.'},
            };

        // Act
        List<List<char>> result = newPipe.ReadTextFile(_testData0);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Should_create_matrix_of_all_zeros()
    {
        // Arrange
        List<List<int>> expected = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

        // Act
        List<List<int>> result = newPipe.CreateMatrixWithZeros(_testData0);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Should_mark_where_is_the_next_pipe_in_second_iteration()
    {
        // Arrange
        List<List<int>> inputMatrix = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 0, 0},
                new List<int> { 0, 1, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

        List<List<int>> expected = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 2, 0},
                new List<int> { 0, 1, 0, 0, 0},
                new List<int> { 0, 2, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

        int currentIteration = 1;

        // Act
        List<List<int>> result = newPipe.ProcessEveryPipeCheck(inputMatrix, currentIteration, _testData0);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Should_mark_where_is_the_next_pipe_in_third_iteration()
    {
        // Arrange
        List<List<int>> inputMatrix = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 2, 0},
                new List<int> { 0, 1, 0, 0, 0},
                new List<int> { 0, 2, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

        List<List<int>> expected = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 2, 0},
                new List<int> { 0, 1, 0, 3, 0},
                new List<int> { 0, 2, 3, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

        int currentIteration = 2;

        // Act
        List<List<int>> result = newPipe.ProcessEveryPipeCheck(inputMatrix, currentIteration, _testData0);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Should_mark_where_is_the_next_pipe_in_fourth_iteration()
    {
        // Arrange
        List<List<int>> inputMatrix = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 2, 0},
                new List<int> { 0, 1, 0, 3, 0},
                new List<int> { 0, 2, 3, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

        List<List<int>> expected = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 2, 0},
                new List<int> { 0, 1, 0, 3, 0},
                new List<int> { 0, 2, 3, 4, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

        int currentIteration = 3;

        // Act
        List<List<int>> result = newPipe.ProcessEveryPipeCheck(inputMatrix, currentIteration, _testData0);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    private static Solution CreatePipe()
    {
        return new Solution();
    }
}