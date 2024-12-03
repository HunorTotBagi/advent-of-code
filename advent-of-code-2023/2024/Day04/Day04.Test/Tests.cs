using Day04.Src;
using FluentAssertions;

namespace Day04.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day04.Src/Data/testData.txt";
        private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day04.Src/Data/realData.txt";

        [Fact]
        public void Test1()
        {
            // Arrange
            var expected = new List<string> {"a", "b"};

            // Act
            var result = CodeSolution.ReadFile(_testData);

            // Assert
            result.Should().Equal(expected);
        }
    }
}