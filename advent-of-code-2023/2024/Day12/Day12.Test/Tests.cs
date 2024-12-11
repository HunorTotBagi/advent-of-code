using Day12.Src;
using FluentAssertions;

namespace Day12.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day12.Src/testData.txt";


        [Fact]
        public void ReadFile()
        {
            // Arrange
            var expected = 5;

            // Act
            var result = CodeSolution.ReadFile(_testData);

            // Assert
            result.Should().Be(expected);
            //result.Should().BeEquivalentTo(result);
        }
    }
}