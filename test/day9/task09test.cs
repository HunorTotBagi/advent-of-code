using FluentAssertions;
using src.day09;
using Xunit;

namespace test.day9
{
    public class task09test
    {
        Sensor newSensor = CreateSensor();

        [Theory]
        [InlineData("exampleFile.txt", 0)]
        public void Should_get_row(string fileName, ulong index)
        {
            // Arrange
            List<ulong> expected = new List<ulong> { 0, 3, 6, 9, 12, 15 };
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

            // Act
            List<ulong> result = newSensor.GetNumberListBasedOnIndex(filePath, index);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_get_next_row_calc()
        {
            // Arrange
            List<ulong> input = new List<ulong> { 0, 3, 6, 9, 12, 15 };
            List<ulong> expected = new List<ulong> { 3, 3, 3, 3, 3 };

            // Act
            List<ulong> result = newSensor.GetNextRowCalculation(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("exampleFile.txt")]
        public void Get_next_number_for_specific_row(string fileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);
            ulong index = 0;

            List<List<ulong>> expected = new List<List<ulong>>
            {
                new List<ulong>{ 0,   3 ,  6 ,  9 , 12 , 15 },
                new List<ulong>{ 3  , 3  , 3 ,  3  , 3 },
                new List<ulong>{ 0, 0, 0, 0 },

            };



            List<List<ulong>> result = newSensor.GetAllDifferencesForThatRow(filePath, index);

            result.Should().BeEquivalentTo(expected);
        }

        private static Sensor CreateSensor()
        {
            return new Sensor();
        }
    }
}
