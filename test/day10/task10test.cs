using System.ComponentModel;
using FluentAssertions;
using src.day10;
using Xunit;

namespace test.day10
{
    public class task10test
    {
        Pipe newPipe = CreatePipe();

        string filePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day10\\data\\exampleData.txt";
        string realFilePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day10\\data\\realData.txt";

        [Fact]
        public void First()
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
            List<List<char>> result = newPipe.ReadTextFile(filePath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_find_the_index_of_S()
        {
            // Arrange
            List<int> expected = new List<int> { 1, 1 };

            // Act
            List<int> indexOfS = newPipe.GetIndexOfStartingPosition(filePath);

            // Assert
            indexOfS.Should().BeEquivalentTo(expected);
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
            List<List<int>> result = newPipe.CreateZeroMatrixForPipe(filePath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_add_one_S()
        {
            // Arrange
            List<List<int>> inputMatrix = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

            List<List<int>> expected = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 0, 0},
                new List<int> { 0, 1, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

            int currentIteration = 0;

            // Act
            List<List<int>> result = newPipe.CallForS(currentIteration, inputMatrix, filePath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]  
        public void Should_add_two_for_random_pipe()
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
            List<List<int>> result = newPipe.CallEveryPipeCheck(inputMatrix, currentIteration, filePath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_add_three_for_random_pipe()
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
            List<List<int>> result = newPipe.CallEveryPipeCheck(inputMatrix, currentIteration, filePath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        private static Pipe CreatePipe()
        {
            return new Pipe();
        }
    }
}
