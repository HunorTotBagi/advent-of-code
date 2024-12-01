using Day02.Src;

namespace Day02.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day02.Src/Data/testData.txt";
        private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day02.Src/Data/realData.txt";

        private readonly CodeSolution _newCodeSolution = CreateCodeSolution();

        [Fact]
        public void Test1()
        {

        }

        public static CodeSolution CreateCodeSolution()
        {
            return new CodeSolution();
        }
    }
}