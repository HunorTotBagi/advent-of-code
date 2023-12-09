using System;
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
        public void Should_get_row_based_on_index(string fileName, int index)
        {
            // Arrange
            List<long> expected = new List<long> { 0, 3, 6, 9, 12, 15 };
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

            // Act
            List<long> result = newSensor.GetNumberListBasedOnIndex(filePath, index);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_get_next_row_calc()
        {
            // Arrange
            List<long> input = new List<long> { 0, 3, 6, 9, 12, 15 };
            List<long> expected = new List<long> { 3, 3, 3, 3, 3 };

            // Act
            List<long> result = newSensor.GetNextRowCalculation(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("exampleFile.txt")]
        public void Get_next_number_for_specific_row(string fileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);
            int index = 0;

            List<List<long>> expected = new List<List<long>>
            {
                new List<long>{ 0, 3, 6, 9, 12, 15 },
                new List<long>{ 3, 3, 3, 3, 3 },
                new List<long>{ 0, 0, 0, 0 },
            };

            List<List<long>> result = newSensor.GetAllDifferencesForThatRow(filePath, index);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("exampleFile.txt")]
        public void Get_next_number_for_specific_row2(string fileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);
            int index = 1;

            List<List<long>> expected = new List<List<long>>
            {
                new List<long>{ 1,   3 ,  6  ,10,  15 , 21},
                new List<long>{ 2 ,  3 ,  4,   5  , 6 },
                new List<long>{ 1 ,  1 ,  1,   1 },
                new List<long>{ 0  , 0  , 0 }
            };

            List<List<long>> result = newSensor.GetAllDifferencesForThatRow(filePath, index);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("exampleFile.txt")]
        public void aaaaaaaaaaaa(string fileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

            List<List<long>> input = newSensor.GetAllDifferencesForThatRow(filePath, 0);

            long expected = 18;

            long result = newSensor.AddStepsToAsALastElement(input);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("exampleFile.txt")]
        public void asdasd(string fileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

            long expected = 114;

            long result = newSensor.CalcFinal(filePath);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("realFile.txt")]
        public void asdawdwd(string fileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

            long expected = 114;

            long result = newSensor.CalcFinal(filePath);

            result.Should().Be(expected);
        }

        private static Sensor CreateSensor()
        {
            return new Sensor();
        }
    }
}
