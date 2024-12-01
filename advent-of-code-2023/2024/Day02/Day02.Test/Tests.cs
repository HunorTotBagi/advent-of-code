using Day02.Src;

namespace Day02.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day02.Src/Data/testData.txt";
        private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day02.Src/Data/realData.txt";

        [Fact]
        public void Test1()
        {
            // Arrange
            CodeSolution.ReadFile(_testData);

            // Act

            // Assert
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            CodeSolution.ReadFile(_testData);

            // Act

            // Assert
        }
    }
}
