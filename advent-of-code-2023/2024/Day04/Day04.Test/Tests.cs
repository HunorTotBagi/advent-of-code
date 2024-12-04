using Day04.Src;
using FluentAssertions;

namespace Day04.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day04.Src/Data/testData.txt";
        private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day04.Src/Data/realData.txt";

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
            var result = CodeSolution.ReadFile(_testData);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Counts_Horizontal()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.Horizontal(data);

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void Counts_Horizontal_Backwards()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.HorizontalBackwards(data);

            // Assert
            result.Should().Be(2);
        }

        [Fact]
        public void Counts_Vertical()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.Vertical(data);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public void Counters_Vertical_Backwards()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.VerticalBackwards(data);

            // Assert
            result.Should().Be(2);
        }

        [Fact]
        public void Counts_Diagonal_1()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.Diagonal1(data);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public void Counts_Diagonal_1_Backwards()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.Diagonal1Backwards(data);

            // Assert
            result.Should().Be(4);
        }

        [Fact]
        public void Counts_Diagonal_2()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.Diagonal2(data);

            // Assert
            result.Should().Be(4);
        }

        [Fact]
        public void Counts_Diagonal_2_Backwards()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.Diagonal2Backwards(data);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public void Counts_All_Occurrences_Test_Data()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.GetAllXmas(data);

            // Assert
            result.Should().Be(18);
        }

        [Fact]
        public void Counts_All_Occurrences_Real_Data()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_realData);

            // Act
            var result = CodeSolution.GetAllXmas(data);

            // Assert
            result.Should().Be(2500);
        }

        [Fact]
        public void Counts_All_Occurrences_X_Shaped_Mas_Test_Data()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.Result(data);

            // Assert
            result.Should().Be(9);
        }

        [Fact]
        public void Counts_All_Occurrences_X_Shaped_Mas_Real_Data()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_realData);

            // Act
            var result = CodeSolution.Result(data);

            // Assert
            result.Should().Be(1933);
        }
    }
}
