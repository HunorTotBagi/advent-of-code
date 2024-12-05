using Day06.Src;
using FluentAssertions;

namespace Day06.Test
{
    public class UnitTest1
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06.Src/testData0.txt";

        [Fact]
        public void Test1()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            // Act

            // Assert
        }
    }
}