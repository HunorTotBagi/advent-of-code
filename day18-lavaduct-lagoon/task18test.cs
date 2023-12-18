
using FluentAssertions;
using Xunit;

namespace AdventOfCode2023.Day18.Tests
{
    public class LavaductLagoonCalculatorTests
    {
        string realData = "C:\\Users\\htotbagi\\source\\repos\\advent-of-code-LATEST\\advent-of-code-LATEST\\day18\\data\\realData.txt";
        string testData0 = "C:\\Users\\htotbagi\\source\\repos\\advent-of-code-LATEST\\advent-of-code-LATEST\\day18\\data\\testData0.txt";
        string testData1 = "C:\\Users\\htotbagi\\source\\repos\\advent-of-code-LATEST\\advent-of-code-LATEST\\day18\\data\\testData1.txt";

        LavaductLagoonCalculator lagoonCalculator = CreateLavaductLagoonCalculator();

        [Fact]
        public void Should_parse_dig_plan_from_file()
        {
            // Arrange
            var expectedDirections = new List<char> { 'R', 'D', 'L' };
            var expectedNumbers = new List<int> { 6, 5, 2 };
            var expectedColorCodes = new List<string> { "(#70c710)", "(#0dc571)", "(#5713f0)" };

            // Act
            (List<char> directions, List<int> numbers, List<string> colorCodes) = lagoonCalculator.ParseDigPlanFromFile(testData1);

            // Assert
            directions.Should().BeEquivalentTo(expectedDirections);
            numbers.Should().BeEquivalentTo(expectedNumbers);
            colorCodes.Should().BeEquivalentTo(expectedColorCodes);
        }

        [Fact]
        public void Should_calculate_area_using_shoelace_formula()
        {
            // Arrange
            var coordinateX = new List<int> { 4, 9, 11, 2, 4 };
            var coordinateY = new List<int> { 10, 7, 2, 2, 10 };

            // Act
            double area = lagoonCalculator.CalculateAreaUsingShoelaceFormula(coordinateX, coordinateY);

            // Assert
            area.Should().Be(45.5);
        }

        [Fact]
        public void Should_parse_coordinates_from_dig_plan()
        {
            // Arrange
            List<int> expectedX = new List<int> { 0, 0, 5, 5, 7, 7, 9, 9, 7, 7, 5, 5, 2, 2, 0 };
            List<int> expectedY = new List<int> { 0, 6, 6, 4, 4, 6, 6, 1, 1, 0, 0, 2, 2, 0, 0 };

            // Act
            (List<int> cordX, List<int> cordY) = lagoonCalculator.ParseCoordinatesFromDigPlan(testData0);

            // Assert
            cordX.Should().BeEquivalentTo(expectedX);
            cordY.Should().BeEquivalentTo(expectedY);
        }

        [Fact]
        public void Should_calculate_total_boundary_length()
        {
            // Arrange
            double expected = 38;

            // Act
            double result = lagoonCalculator.CalculateTotalBoundaryLength(testData0);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_calculate_total_lagoon_area_for_test_data()
        {
            // Arrange
            int expected = 62;

            // Act
            double result = lagoonCalculator.CalculateTotalLagoonArea(testData0);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_calculate_total_lagoon_area_for_real_data()
        {
            // Arrange
            int expected = 28911;

            // Act
            double result = lagoonCalculator.CalculateTotalLagoonArea(realData);

            // Assert
            result.Should().Be(expected);
        }

        private static LavaductLagoonCalculator CreateLavaductLagoonCalculator()
        {
            return new LavaductLagoonCalculator();
        }
    }
}