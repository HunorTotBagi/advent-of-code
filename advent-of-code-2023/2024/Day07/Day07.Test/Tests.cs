using Day07.Src;
using FluentAssertions;

namespace Day07.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day07.Src/testData.txt";

        [Fact]
        public void Read_Calibration_Data_Correctly()
        {
            // Arrange
            var leftNumbers = new List<long> { 190, 3267, 83, 156, 7290,161011, 192, 21037, 292 };

            var rightNumbers = new List<List<long>>
            {
                new() { 10, 19 }, new() { 81, 40, 27 }, new() { 17, 5 },
                new() { 15, 6 }, new() { 6, 8, 6, 15 }, new() { 16, 10, 13 },
                new() { 17, 8, 14 }, new() { 9, 7, 18, 13 }, new() { 11, 6, 16, 20 }
            };

            // Act
            var (number, all) = CodeSolution.ReadCalibrationFile(_testData);

            // Assert
            number.Should().BeEquivalentTo(leftNumbers);
            all.Should().BeEquivalentTo(rightNumbers);
        }

        [Theory]
        [InlineData(1, new[] { "+", "*" })]
        [InlineData(2, new[] { "++", "+*", "*+", "**" })]
        public void Generate_Valid_Operator_Combinations(int input, string[] expected)
        {
            // Arrange
            var expectedList = new List<string>(expected);

            // Act
            var result = CodeSolution.GenerateOperatorCombinations(input);

            // Assert
            result.Should().BeEquivalentTo(expectedList);
        }

        [Theory]
        [InlineData(190, new long[] { 10, 19 }, true)]
        [InlineData(3267, new long[] { 81, 40, 27 }, true)]
        [InlineData(83, new long[] { 17, 5 }, false)]
        public void Validate_Equation(long target, long[] elements, bool expected)
        {
            // Arrange
            var elementsList = new List<long>(elements);

            // Act
            var result = CodeSolution.IsValidCalibration(target, elementsList);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Calculate_Sum_Of_Valid_Equations()
        {
            // Arrange
            var (targetNumbers, elements) = CodeSolution.ReadCalibrationFile(_testData);

            // Act
            var result = CodeSolution.CalculateCalibration(targetNumbers, elements);

            // Assert
            result.Should().Be(3749);
        }

        [Theory]
        [InlineData(1, new[] { "+", "*", "|" })]
        [InlineData(2, new[] { "++", "+*", "+|", "*+", "**", "*|", "|+", "|*", "||" })]
        public void Generate_Valid_Operator_Combinations_With_Concatenation(int input, string[] expected)
        {
            // Arrange
            var expectedList = new List<string>(expected);

            // Act
            var result = CodeSolution.GenerateOperatorCombinationsWithConcatenation(input);

            // Assert
            result.Should().BeEquivalentTo(expectedList);
        }

        [Theory]
        [InlineData(156, new long[] { 15, 6 }, true)]
        [InlineData(7290, new long[] { 6, 8, 6, 15 }, true)]
        [InlineData(192, new long[] { 17, 8, 14 }, true)]
        public void Validate_Equation_With_Concatenation(long target, long[] elements, bool expected)
        {
            // Arrange
            var elementsList = new List<long>(elements);

            // Act
            var result = CodeSolution.IsValidCalibrationWithConcatenation(target, elementsList);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Calculate_Sum_Of_Valid_Equations_With_Concatenation()
        {
            // Arrange
            var (targetNumbers, elements) = CodeSolution.ReadCalibrationFile(_testData);

            // Act
            var result = CodeSolution.CalculateCalibrationWithConcatenation(targetNumbers, elements);

            // Assert
            result.Should().Be(11387);
        }
    }
}
