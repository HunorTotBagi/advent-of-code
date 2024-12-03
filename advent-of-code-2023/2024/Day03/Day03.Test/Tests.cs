using Day03.Src;
using FluentAssertions;

namespace Day03.Test
{
    public class Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day03.Src/Data/testData.txt";
        private readonly string _testData1 = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day03.Src/Data/testData1.txt";
        private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day03.Src/Data/realData.txt";

        [Fact]
        public void Read_The_File()
        {
            // Arrange
            var expected = new List<string> { "mul(2,4)", "mul(5,5)", "mul(11,8)", "mul(8,5)" };

            // Act
            var data = CodeSolution.ReadFile(_testData);

            // Assert
            data.Should().Equal(expected);
        }

        [Fact]
        public void Extract_The_Numbers()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);

            var expected1 = new List<int> { 2, 5, 11, 8 };
            var expected2 = new List<int> { 4, 5, 8, 5 };

            // Act
            var (list1, list2) = CodeSolution.GetNumbers(data);

            // Assert
            list1.Should().Equal(expected1);
            list2.Should().Equal(expected2);
        }

        [Fact]
        public void Calculate_Test_Data()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_testData);
            var (list1, list2) = CodeSolution.GetNumbers(data);

            // Act
            var result = CodeSolution.Calculate(list1, list2);

            // Assert
            result.Should().Be(161);
        }

        [Fact]
        public void Calculate_Real_Data()
        {
            // Arrange
            var data = CodeSolution.ReadFile(_realData);
            var (list1, list2) = CodeSolution.GetNumbers(data);

            // Act
            var result = CodeSolution.Calculate(list1, list2);

            // Assert
            result.Should().Be(159833790);
        }

        [Fact]
        public void Read_Corrupted_File()
        {
            // Arrange
            var expected = new List<string> { "mul(2,4)", "don't()", "mul(5,5)", "mul(11,8)", "do()", "mul(8,5)" };

            // Act
            var data = CodeSolution.ReadCorruptedFile(_testData1);

            // Assert
            data.Should().Equal(expected);
        }

        [Fact]
        public void Include_Only_Non_Corrupted_Data()
        {
            // Arrange
            var data = CodeSolution.ReadCorruptedFile(_testData1);
            var expected = new List<string> { "mul(2,4)", "mul(8,5)" };

            // Act
            var result = CodeSolution.ScanList(data);

            // Assert
            result.Should().Equal(expected);
        }

        [Fact]
        public void Calculate_Corrupted_Test1_Data()
        {
            // Arrange
            var data = CodeSolution.ReadCorruptedFile(_testData1);
            var nonCorruptedData = CodeSolution.ScanList(data);
            var (list1, list2) = CodeSolution.GetNumbers(nonCorruptedData);

            // Act
            var result = CodeSolution.Calculate(list1, list2);

            // Assert
            result.Should().Be(48);
        }

        [Fact]
        public void Calculate_Corrupted_Real_Data()
        {
            // Arrange
            var data = CodeSolution.ReadCorruptedFile(_realData);
            var nonCorruptedData = CodeSolution.ScanList(data);
            var (list1, list2) = CodeSolution.GetNumbers(nonCorruptedData);

            // Act
            var result = CodeSolution.Calculate(list1, list2);

            // Assert
            result.Should().Be(89349241);
        }
    }
}
