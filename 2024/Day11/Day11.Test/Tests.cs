using Day11.Src;
using FluentAssertions;

namespace Day11.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day11.Src/testData.txt";

        [Fact]
        public void ReadFile()
        {
            // Arrange
            var expected = new List<int> { 125, 17 };

            // Act
            var result = CodeSolution.ReadFile(_testData);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(1235, 12,35)]
        [InlineData(812135, 812,135)]
        public void SplitEvenNumber(ulong input, ulong firstPartExpected, ulong secondPartExpected)
        {
            // Arrange

            // Act
            var (first, second) = CodeSolution.SplitEvenNumber(input);

            // Assert
            first.Should().Be(firstPartExpected);
            second.Should().Be(secondPartExpected);
        }

        [Theory]
        [InlineData("0000123", 123)]
        [InlineData("07104", 7104)]
        [InlineData("000", 0)]
        [InlineData("0", 0)]
        public void RemoveLeadingZeros(string input, ulong expected)
        {
            // Arrange

            // Act
            var result = CodeSolution.RemoveLeadingZeros(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(6, 22)]
        [InlineData(25, 55312)]
        public void Calc(ulong numberOfBlinks, ulong expected)
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act
            var result = CodeSolution.CalculateStoneCountAfterBlinks(data, numberOfBlinks);

            // Assert
            result.Should().Be(expected);
        }
    }
}
