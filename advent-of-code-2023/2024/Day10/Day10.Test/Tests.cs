using Day10.Src;
using FluentAssertions;

namespace Day10.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day10.Src/testData.txt";
        private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day10.Src/realData.txt";

        [Fact]
        public void ReadFile()
        {
            // Arrange

            // Act
            var data = CodeSolution.ReadFile(_testData);

            // Assert
            data.Should().Be(5);
        }
    }
}