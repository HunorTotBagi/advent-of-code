using Day07.Src;

namespace Day07.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day07.Src/testData.txt";

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