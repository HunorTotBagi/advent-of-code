using Day14.Src;
using FluentAssertions;

namespace Day14.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day14.Src/testData.txt";
        private readonly string _testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day14.Src/testData1.txt";
        private readonly string _testData2 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day14.Src/testData2.txt";


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
