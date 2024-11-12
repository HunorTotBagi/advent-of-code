using Day21.Src;
using FluentAssertions;

namespace Day21.Test;

public class Tests
{
    private readonly string realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day21.Src/Data/realData.txt";
    private readonly string testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day21.Src/Data/testData0.txt";
    private readonly string testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day21.Src/Data/testData1.txt";
    private readonly string testData2 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day21.Src/Data/testData2.txt";
    private readonly string testData3 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day21.Src/Data/testData3.txt";
    private readonly string testData4 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day21.Src/Data/testData4.txt";

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