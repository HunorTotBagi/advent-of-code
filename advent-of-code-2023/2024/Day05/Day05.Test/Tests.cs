using Day05.Src;
using FluentAssertions;

namespace Day05.Test
{
    public class Tests
    {
        private readonly string _testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day05.Src/testData0.txt";
        private readonly string _testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day05.Src/testData1.txt";

        [Fact]
        public void Read_Rules()
        {
            // Arrange
            var expected = new List<List<int>>
            {
                new() { 47, 53 },
                new() { 97, 13 },
                new() { 97, 61 },
                new() { 97, 47 },
                new() { 75, 29 },
                new() { 61, 13 },
                new() { 75, 53 },
                new() { 29, 13 },
                new() { 97, 29 },
                new() { 53, 29 },
                new() { 61, 53 },
                new() { 97, 53 },
                new() { 61, 29 },
                new() { 47, 13 },
                new() { 75, 47 },
                new() { 97, 75 },
                new() { 47, 61 },
                new() { 75, 61 },
                new() { 47, 29 },
                new() { 75, 13 },
                new() { 53, 13 }
            };

            // Act
            var rules = CodeSolution.ReadFileRules(_testData0);

            // Assert
            rules.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Read_Rows()
        {
            // Arrange
            var expected = new List<List<int>>
            {
                new() { 75, 47, 61, 53, 29 },
                new() { 97, 61, 53, 29, 13 },
                new() { 75, 29, 13 },
                new() { 75, 97, 47, 61, 53 },
                new() { 61, 13, 29 },
                new() { 97, 13, 75, 29, 47 }
            };

            // Act
            var rows = CodeSolution.ReadFileRows(_testData1);

            // Assert
            rows.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Is_Targeted_Pair_In_Rules()
        {
            // Arrange
            var rules = CodeSolution.ReadFileRules(_testData0);

            // Act
            var result = CodeSolution.IsPairInRules(75,53, rules);

            // Assert
            result.Should().Be(true);
        }

        [Fact]
        public void Is_Targeted_Row_Correct_Or_Not()
        {
            // Arrange
            var rules = CodeSolution.ReadFileRules(_testData0);
            var rows = CodeSolution.ReadFileRows(_testData1);

            // Act
            var result0 = CodeSolution.IsRowCorrect(rows[0], rules);
            var result1 = CodeSolution.IsRowCorrect(rows[1], rules);
            var result2 = CodeSolution.IsRowCorrect(rows[2], rules);
            var result3 = CodeSolution.IsRowCorrect(rows[3], rules);
            var result4 = CodeSolution.IsRowCorrect(rows[4], rules);
            var result5 = CodeSolution.IsRowCorrect(rows[5], rules);

            // Assert
            result0.Should().Be(true);
            result1.Should().Be(true);
            result2.Should().Be(true);
            result3.Should().Be(false);
            result4.Should().Be(false);
            result5.Should().Be(false);
        }

        [Fact]
        public void Count_All_Middle_Elements_Of_Correct_Rows()
        {
            // Arrange
            var rules = CodeSolution.ReadFileRules(_testData0);
            var rows = CodeSolution.ReadFileRows(_testData1);

            // Act
            var result = CodeSolution.CountCorrectRows(rows, rules);

            // Assert
            result.Should().Be(143);
        }

        [Fact]
        public void Swap_False_Rows_Until_Correct()
        {
            // Arrange
            var rules = CodeSolution.ReadFileRules(_testData0);
            var rows = CodeSolution.ReadFileRows(_testData1);

            var expected3 = new List<int> { 97, 75, 47, 61, 53 };
            var expected4 = new List<int> { 61, 29, 13 };
            var expected5 = new List<int> { 97, 75, 47, 29, 13 };

            // Act
            var result3 = CodeSolution.SwapWhileNotFound(rows[3], rules);
            var result4 = CodeSolution.SwapWhileNotFound(rows[4], rules);
            var result5 = CodeSolution.SwapWhileNotFound(rows[5], rules);

            // Assert
            result3.Should().Equal(expected3);
            result4.Should().Equal(expected4);
            result5.Should().Equal(expected5);
        }

        [Fact]
        public void Count_All_Middle_Elements_Of_False_Swapped_Rows()
        {
            // Arrange
            var rules = CodeSolution.ReadFileRules(_testData0);
            var data = CodeSolution.ReadFileRows(_testData1);

            // Act
            var result0 = CodeSolution.CountFalseSwappedRows(data, rules);

            // Assert
            result0.Should().Be(123);
        }
    }
}
