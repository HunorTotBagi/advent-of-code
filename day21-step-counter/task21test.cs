using FluentAssertions;
using Xunit;

namespace AdventOfCode2023.Day21.Test
{
    public class StepCounterSolverTest
    {
        string realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day21-step-counter/data/realData.txt";
        string testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day21-step-counter/data/testData0.txt";
        string testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day21-step-counter/data/testData1.txt";
        string testData2 = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day21-step-counter/data/testData2.txt";
        string testData3 = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day21-step-counter/data/testData3.txt";
        string testData4 = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day21-step-counter/data/testData4.txt";

        StepCounterSolver newStepCounterSolver = CreateHunor();

        [Fact]
        public void Should_find_starting_position()
        {
            // Arrange
            var expectedX = 5;
            var expectedY = 5;

            // Act
            var (coordinateX, coordinateY) = newStepCounterSolver.FindStartingPoint(testData0);

            // Assert
            coordinateX.Should().Be(expectedX);
            coordinateY.Should().Be(expectedY);
        }

        [Fact]
        public void Should_initialize_garden_grid()
        {
            // Arrange
            var inputMatrix = newStepCounterSolver.ReadFileIntoCharGrid(testData0);
            var expected = newStepCounterSolver.ReadFileIntoCharGrid(testData1);

            // Act
            var result = newStepCounterSolver.InitializeGardenGrid(inputMatrix, testData0);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_expand_garden_reach_second_iteration()
        {
            // Arrange
            var inputMatrix = newStepCounterSolver.ReadFileIntoCharGrid(testData1);
            var expected = newStepCounterSolver.ReadFileIntoCharGrid(testData2);

            // Act
            var result = newStepCounterSolver.ExpandGardenReach(inputMatrix);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_expand_garden_reach_third_iteration()
        {
            // Arrange
            var inputMatrix = newStepCounterSolver.ReadFileIntoCharGrid(testData2);
            var expected = newStepCounterSolver.ReadFileIntoCharGrid(testData3);

            // Act
            var result = newStepCounterSolver.ExpandGardenReach(inputMatrix);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_simulate_movement()
        {
            // Arrange
            var expected = newStepCounterSolver.ReadFileIntoCharGrid(testData4);
            var numberOfSteps = 6;

            // Act
            var result = newStepCounterSolver.SimulateElfMovement(testData0, numberOfSteps);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_return_the_count_of_marked_tiles_test_data()
        {
            // Arrange
            var countO = 16;
            var numberOfSteps = 6;

            // Act
            var result = newStepCounterSolver.GetCount(testData0, numberOfSteps);

            // Assert
            result.Should().Be(countO);
        }

        [Fact]
        public void Should_return_the_count_of_marked_tiles_real_data()
        {
            // Arrange
            var countO = 3731;
            var numberOfSteps = 64;

            // Act
            var result = newStepCounterSolver.GetCount(realData, numberOfSteps);

            // Assert
            result.Should().Be(countO);
        }

        private static StepCounterSolver CreateHunor()
        {
            return new StepCounterSolver();
        }
    }
}