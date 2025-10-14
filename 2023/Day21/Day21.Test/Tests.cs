using Day21.Src;
using FluentAssertions;

namespace Day21.Test;

public class Tests
{
    private readonly string _testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day21.Src/testData0.txt";
    private readonly string _testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day21.Src/testData1.txt";
    private readonly string _testData2 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day21.Src/testData2.txt";
    private readonly string _testData3 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day21.Src/testData3.txt";
    private readonly string _testData4 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day21.Src/testData4.txt";

    StepCounterSolver newStepCounterSolver = CreateHunor();

    [Fact]
    public void Should_find_starting_position()
    {
        // Arrange
        var expectedX = 5;
        var expectedY = 5;

        // Act
        var (coordinateX, coordinateY) = newStepCounterSolver.FindStartingPoint(_testData0);

        // Assert
        coordinateX.Should().Be(expectedX);
        coordinateY.Should().Be(expectedY);
    }

    [Fact]
    public void Should_initialize_garden_grid()
    {
        // Arrange
        var inputMatrix = newStepCounterSolver.ReadFileIntoCharGrid(_testData0);
        var expected = newStepCounterSolver.ReadFileIntoCharGrid(_testData1);

        // Act
        var result = newStepCounterSolver.InitializeGardenGrid(inputMatrix, _testData0);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Should_expand_garden_reach_second_iteration()
    {
        // Arrange
        var inputMatrix = newStepCounterSolver.ReadFileIntoCharGrid(_testData1);
        var expected = newStepCounterSolver.ReadFileIntoCharGrid(_testData2);

        // Act
        var result = newStepCounterSolver.ExpandGardenReach(inputMatrix);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Should_expand_garden_reach_third_iteration()
    {
        // Arrange
        var inputMatrix = newStepCounterSolver.ReadFileIntoCharGrid(_testData2);
        var expected = newStepCounterSolver.ReadFileIntoCharGrid(_testData3);

        // Act
        var result = newStepCounterSolver.ExpandGardenReach(inputMatrix);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Should_simulate_movement()
    {
        // Arrange
        var expected = newStepCounterSolver.ReadFileIntoCharGrid(_testData4);
        var numberOfSteps = 6;

        // Act
        var result = newStepCounterSolver.SimulateElfMovement(_testData0, numberOfSteps);

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
        var result = newStepCounterSolver.GetCount(_testData0, numberOfSteps);

        // Assert
        result.Should().Be(countO);
    }

    private static StepCounterSolver CreateHunor()
    {
        return new StepCounterSolver();
    }
}