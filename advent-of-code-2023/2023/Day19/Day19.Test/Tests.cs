using Day19.Src;
using FluentAssertions;

namespace Day19.Test;

public class Tests
{
    private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day19.Src/Data/realData.txt";
    private readonly string _testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day19.Src/Data/testData0.txt";
    private readonly string _testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day19.Src/Data/testData1.txt";

    WorkflowProcessor workflowProcessor = CreateWorkflowProcessor();

    [Fact]
    public void Should_extract_workflow_rules()
    {
        // Arrange
        var expectedWorkflowName = "px";
        var (workflow, _) = workflowProcessor.ReadFileIn(_testData0);
        var expectedWorkflows = new List<string> { "a<2006:qkq", "m>2090:A", "rfg" };

        // Act
        var (workflowName, workflows) = workflowProcessor.ExtractWorkflowRules(workflow[0]);

        // Assert
        workflowName.Should().Be(expectedWorkflowName);
        workflows.Should().BeEquivalentTo(expectedWorkflows);
    }

    [Fact]
    public void Should_extract_rating_numbers()
    {
        // Arrange
        var (_, parts) = workflowProcessor.ReadFileIn(_testData0);
        var expected = new List<int> { 787, 2655, 1222, 2876 };

        // Act
        var result = workflowProcessor.ExtractRatingNumbers(parts[0]);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Should_create_workflow_mappings()
    {
        // Arrange
        var expectedKeys = new List<string> { "px", "pv", "lnx" };
        var expectedComparisons = new List<List<string>>
            {
                new() {"a<2006:qkq", "m>2090:A", "rfg"},
                new() {"a>1716:R", "A"},
                new() {"m>1548:A", "A"},
            };

        // Act
        var (keys, comparisons) = workflowProcessor.CreateWorkflowMappings(_testData1);

        // Assert
        keys.Should().BeEquivalentTo(expectedKeys);
        comparisons.Should().BeEquivalentTo(expectedComparisons);
    }

    [Fact]
    public void Should_process_comparison_rule()
    {
        // Arrange
        var expectedFirst = "s";
        var expectedSecond = '<';
        var expectedNumber = 1351;
        var expectedNextPath = "px";
        var input = "s<1351:px";

        // Act
        var (xmas, sign, number, nextPath) = workflowProcessor.ProcessComparisonRule(input);

        // Assert
        xmas.Should().Be(expectedFirst);
        sign.Should().Be(expectedSecond);
        number.Should().Be(expectedNumber);
        nextPath.Should().Be(expectedNextPath);
    }

    [Theory]
    [InlineData("qqz", new string[] { "s<1351:px", "qqz" }, new int[] { 787, 2655, 1222, 2876 })]
    [InlineData("qs", new string[] { "s>2770:qs", "m<1801:hdj", "R" }, new int[] { 787, 2655, 1222, 2876 })]
    [InlineData("lnx", new string[] { "s>3448:A", "lnx" }, new int[] { 787, 2655, 1222, 2876 })]
    [InlineData("A", new string[] { "m>1548:A", "A" }, new int[] { 787, 2655, 1222, 2876 })]
    public void Should_check_main_logic_functionality(string expected, string[] inputLogicArray, int[] inputNumbersArray)
    {
        // Arrange
        var inputLogic = new List<string>(inputLogicArray);
        var inputNumbers = new List<int>(inputNumbersArray);

        // Act
        var result = workflowProcessor.MainLogic(inputLogic, inputNumbers);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Should_determine_part_outcome()
    {
        // Arrange
        var expected = "A";
        var inputNumbers = new List<int> { 787, 2655, 1222, 2876 };
        var (keys, comparisons) = workflowProcessor.CreateWorkflowMappings(_testData0);

        // Act
        var result = workflowProcessor.DeterminePartOutcome(inputNumbers, keys, comparisons);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Should_compute_accepted_parts_sum_for_test_data()
    {
        // Arrange
        var expected = 19114;

        // Act
        var result = workflowProcessor.ComputeAcceptedPartsSum(_testData0);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Should_compute_accepted_parts_sum_for_real_data()
    {
        // Arrange
        var expected = 575412;

        // Act
        var result = workflowProcessor.ComputeAcceptedPartsSum(_realData);

        // Assert
        result.Should().Be(expected);
    }

    private static WorkflowProcessor CreateWorkflowProcessor()
    {
        return new WorkflowProcessor();
    }
}