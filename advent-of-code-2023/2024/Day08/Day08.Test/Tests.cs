using Day08.Src;

namespace Day08.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day08.Src/testData.txt";

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