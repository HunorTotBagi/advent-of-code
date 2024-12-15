using Day16.Src;
using FluentAssertions;

namespace Day16.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day16.Src/testData.txt";

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
