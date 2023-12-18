using FluentAssertions;
using Xunit;

namespace AdventOfCode2023.Day18.Tests
{
    public class LavaductLagoonCalculatorTests
    {
        string realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day18-lavaduct-lagoon/data/realData.txt";
        string testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day18-lavaduct-lagoon/data/testData0.txt";
        string testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day18-lavaduct-lagoon/data/testData1.txt";
        string testData2 = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day18-lavaduct-lagoon/data/testData2.txt";

        LavaductLagoonCalculator lagoonCalculator = CreateLavaductLagoonCalculator();

        [Fact]
        public void Should_parse_dig_plan_from_file()
        {
            // Arrange
            var expectedDirections = new List<char> { 'R', 'D', 'L' };
            var expectedNumbers = new List<long> { 6, 5, 2 };
            var expectedColorCodes = new List<string> { "(#70c710)", "(#0dc571)", "(#5713f0)" };

            // Act
            var (directions, numbers, colorCodes) = lagoonCalculator.ParseDigPlanFromFile(testData1);

            // Assert
            directions.Should().BeEquivalentTo(expectedDirections);
            numbers.Should().BeEquivalentTo(expectedNumbers);
            colorCodes.Should().BeEquivalentTo(expectedColorCodes);
        }

        [Fact]
        public void Should_calculate_area_using_shoelace_formula()
        {
            // Arrange
            var coordinateX = new List<long> { 0, 0, 5, 5 };
            var coordinateY = new List<long> { 0, 2, 2, 0 };

            // Act
            var area = lagoonCalculator.CalculateAreaUsingShoelaceFormula(coordinateX, coordinateY);

            // Assert
            area.Should().Be(10);
        }

        [Fact]
        public void Should_parse_coordinates_from_dig_plan()
        {
            // Arrange
            var expectedX = new List<long> { 0, 0, 5, 5, 7, 7, 9, 9, 7, 7, 5, 5, 2, 2, 0 };
            var expectedY = new List<long> { 0, 6, 6, 4, 4, 6, 6, 1, 1, 0, 0, 2, 2, 0, 0 };
            var (directions, numbers, colorCodes) = lagoonCalculator.ParseDigPlanFromFile(testData0);

            // Act
            var (cordX, cordY) = lagoonCalculator.ParseCoordinatesFromDigPlan(directions, numbers);

            // Assert
            cordX.Should().BeEquivalentTo(expectedX);
            cordY.Should().BeEquivalentTo(expectedY);
        }

        [Fact]
        public void Should_calculate_total_lagoon_area_for_test_data()
        {
            // Arrange
            var expected = 62;
            var (directions, numbers, colorCodes) = lagoonCalculator.ParseDigPlanFromFile(testData0);

            // Act
            var result = lagoonCalculator.CalculateTotalLagoonArea(directions, numbers);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_calculate_total_lagoon_area_for_real_data()
        {
            // Arrange
            var expected = 28911;
            var (directions, numbers, colorCodes) = lagoonCalculator.ParseDigPlanFromFile(realData);

            // Act
            var result = lagoonCalculator.CalculateTotalLagoonArea(directions, numbers);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_parse_revisited_plan()
        {
            // Arrange
            var expectedNewDirections = new List<char> { 'R', 'D', 'U', 'L' };
            var expectedNewNumbers = new List<long> { 461937, 56407, 829975, 112010 };

            // Act
            var (newDirections, newNumbers) = lagoonCalculator.ParseRevisedDigPlan(testData2);

            // Assert
            newNumbers.Should().BeEquivalentTo(expectedNewNumbers);
            newDirections.Should().BeEquivalentTo(expectedNewDirections);
        }

        [Fact]
        public void Should_calculate_total_lagoon_area_part_two_for_test_data()
        {
            // Arrange
            var expected = 952408144115;
            var (newDirections, newNumbers) = lagoonCalculator.ParseRevisedDigPlan(testData0);

            // Act
            var result = lagoonCalculator.CalculateTotalLagoonArea(newDirections, newNumbers);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_calculate_total_lagoon_area_part_two_for_real_data()
        {
            // Arrange
            var expected = 77366737561114;
            var (newDirections, newNumbers) = lagoonCalculator.ParseRevisedDigPlan(realData);

            // Act
            var result = lagoonCalculator.CalculateTotalLagoonArea(newDirections, newNumbers);

            // Assert
            result.Should().Be(expected);
        }

        private static LavaductLagoonCalculator CreateLavaductLagoonCalculator()
        {
            return new LavaductLagoonCalculator();
        }
    }
}