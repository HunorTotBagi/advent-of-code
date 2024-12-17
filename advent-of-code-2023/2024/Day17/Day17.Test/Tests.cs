using Day17.Src;
using FluentAssertions;

namespace Day17.Test
{
    public class Tests
    {
        private readonly string _testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day17.Src/testData0.txt";
        private readonly string _testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day17.Src/testData1.txt";
        private readonly string _testDataReal0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day17.Src/testDataReal0.txt";
        private readonly string _testDataReal1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day17.Src/testDataReal1.txt";


        [Fact]
        public void ReadFile()
        {
            // Arrange
            var expected = new List<int> {729, 0, 0};

            // Act
            var result = CodeSolution.ReadFileRegister(_testData0);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReadFileProot()
        {
            // Arrange
            var expected = new List<int> { 0, 1, 5, 4, 3, 0 };

            // Act
            var result = CodeSolution.ReadFileProgram(_testData1);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Calc()
        {
            // Arrange
            var program = CodeSolution.ReadFileProgram(_testData1);
            var register = CodeSolution.ReadFileRegister(_testData0);

            // Act
            var result = CodeSolution.CalcAll(register, program);

            // Assert
            result.Should().BeEquivalentTo("4635635210");
        }

        [Fact]
        public void CalcReal()
        {
            // Arrange
            var program = CodeSolution.ReadFileProgram(_testDataReal1);
            var register = CodeSolution.ReadFileRegister(_testDataReal0);

            // Act
            var result = CodeSolution.CalcAll(register, program);

            // Assert
            result.Should().BeEquivalentTo("742514604");
        }
    }
}
