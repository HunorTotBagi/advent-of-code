using Day11.Src;
using FluentAssertions;

namespace Day11.Test
{
    public class Tests
    {
        private readonly string _testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day09.Src/testData0.txt";
        private readonly string _testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day09.Src/testData1.txt";
        private readonly string _testData2 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day09.Src/testData2.txt";


        [Fact]
        public void ReadFile()
        {
            // Arrange
            var result = 5;

            // Act
            var data = CodeSolution.ReadFile(_testData0);

            // Assert
            data.Should().Be(result);
        }
    }
}
