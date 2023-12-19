using FluentAssertions;
using Xunit;

namespace AdventOfCode2023.Day19.Tests
{
    public class HunorTest
    {
        string realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day19/data/realData.txt";
        string testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day19/data/testData0.txt";
        string testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day19/data/testData1.txt";

        Hunor newHunor = CreateHunor();

        [Fact]
        public void Should_get_workflowname_and_workflows()
        {
            // Arrange
            var expectedWorkflowName = "px";
            var (workflow, _) = newHunor.ReadFileIn(testData0);
            var expectedWorkflows = new List<string> { "a<2006:qkq", "m>2090:A", "rfg" };

            // Act
            var (workflowName, workflows) = newHunor.ExtractInfo(workflow[0]);

            // Assert
            workflowName.Should().Be(expectedWorkflowName);
            workflows.Should().BeEquivalentTo(expectedWorkflows);
        }

        [Fact]
        public void Should_extract_numbers()
        {
            // Arrange
            var (_, parts) = newHunor.ReadFileIn(testData0);
            var expected = new List<int> { 787, 2655, 1222, 2876 };

            // Act
            var result = newHunor.CreateListNumbers(parts[0]);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_reate_overal_list_for_seacrgin()
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
            var (keys, comparisons) = newHunor.CreateBig(testData1);

            // Assert
            keys.Should().BeEquivalentTo(expectedKeys);
            comparisons.Should().BeEquivalentTo(expectedComparisons);
        }

        [Fact]
        public void Should_get_logic_values()
        {
            // Arrange
            var expectedFirst = "s";
            var expectedSecond = '<';
            var expectedNumber = 1351;
            var expectedNextPath = "px";
            var input = "s<1351:px";

            // Act
            var (xmas, sign, number, nextPath) = newHunor.GetResultFromComparisons(input);

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
        public void Should_return_MainLogic_Theory(string expected, string[] inputLogicArray, int[] inputNumbersArray)
        {
            // Arrange
            var inputLogic = new List<string>(inputLogicArray);
            var inputNumbers = new List<int>(inputNumbersArray);

            // Act
            var result = newHunor.MainLogic(inputLogic, inputNumbers);

            // Assert
            result.Should().Be(expected);
        }


        [Fact]
        public void Should_first_iteration()
        {
            // Arrange
            var expected = "A";
            var inputNumbers = new List<int> { 787, 2655, 1222, 2876 };
            var (keys, comparisons) = newHunor.CreateBig(testData0);

            // Act
            var result = newHunor.InputNumberGetAorR(inputNumbers, keys, comparisons);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_final_res()
        {
            // Arrange
            var expected = 19114;

            // Act
            var result = newHunor.FinalCalc(testData0);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_final_res_real_data()
        {
            // Arrange
            var expected = 575412;

            // Act
            var result = newHunor.FinalCalc(realData);

            // Assert
            result.Should().Be(expected);
        }

        private static Hunor CreateHunor()
        {
            return new Hunor();
        }
    }
}
