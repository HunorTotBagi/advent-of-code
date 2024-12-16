using Day17.Src;
using FluentAssertions;

namespace Day17.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day17.Src/testData.txt";

        [Fact]
        public void ReadFile()
        {
            // Arrange
            var expected = new List<List<int>>();

            // Act
            var result = CodeSolution.ReadFile(_testData);

            // Assert
            result.Should().BeEquivalentTo(expected);
            //result.Should().Be(expected);
        }
    }
}
