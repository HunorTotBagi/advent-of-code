using Day09.Src;
using FluentAssertions;

namespace Day09.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day09.Src/testData.txt";

        [Fact]
        public void Test1()
        {
            // Arrange


            // Act
            var data = CodeSolution.ReadFile(_testData);

            // Assert
            data.Should().Be(5);
        }
    }
}