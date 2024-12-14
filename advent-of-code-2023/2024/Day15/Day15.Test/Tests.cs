using Day15.Src;
using FluentAssertions;

namespace Day15.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testData.txt";

        [Fact]
        public void ReadFile()
        {
            // Arrange
            var expected = 5;

            // Act
            var result = CodeSolution.ReadFile(_testData);

            // Assert
            result.Should().Be(expected);
            //result.Should().BeEquivalentTo(expected);
        }
    }
}
