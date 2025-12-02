using FluentAssertions;
using Src.Day01;

namespace Tests
{
    public class Day01Tests
    {
        private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Src/Day01/testData.txt";

        [Fact]
        public void Test1()
        {
            // Arrange
            var expected = new List<(char, int)>
            {
                ('L', 68),
                ('L', 30),
                ('R', 48),
                ('L', 5),
                ('R', 60),
                ('L', 55),
                ('L', 1),
                ('L', 99),
                ('R', 14),
                ('L', 82),
            };

            // Act
            var result = SolutionP1.ReadFile(_testData);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var expected = 3;

            // Act
            var result = SolutionP1.Solve(_testData);

            // Assert
            result.Should().Be(expected);
        }
    }
}
