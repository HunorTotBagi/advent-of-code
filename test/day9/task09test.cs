using FluentAssertions;
using src.day09;
using Xunit;

namespace test.day9
{
    public class task09test
    {
        Sensor newSensor = CreateSensor();

        [Theory]
        [InlineData("exampleFile.txt")]
        public void Should_read_in_fie(string fileName)
        {
            // Arrange
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

            List<List<int>> expected = new List<List<int>>
            {
                new List<int> { 0, 3, 6, 9, 12, 15 },
                new List<int> { 1, 3, 6, 10, 15, 21 },
                new List<int> { 10, 13, 16, 21, 30, 45 },
            };

            // Act
            List<List<int>> result = newSensor.newExtractor(filePath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_get_next_row1()
        {
            // Arrange
            List<int> input = new List<int> { 0, 3, 6, 9, 12, 15 };
            List<int> expected = new List<int> { 3, 3, 3, 3, 3 };

            // Act
            List<int> result = newSensor.GetNextRowCalculation(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_get_next_row2()
        {
            // Arrange
            List<int> input = new List<int> { 3, 3, 3, 3, 3 };
            List<int> expected = new List<int> { 0, 0, 0, 0 };

            // Act
            List<int> result = newSensor.GetNextRowCalculation(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }


        [Theory]
        [InlineData("exampleFile.txt")]
        public void Get_next_number_for_specific_row(string fileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

            var input = newSensor.newExtractor(filePath)[0];

            List<List<int>> expected = new List<List<int>>
            {
                new List<int>{ 0, 3, 6, 9, 12, 15 },
                new List<int>{ 3, 3, 3, 3, 3 },
                new List<int>{ 0, 0, 0, 0 },
            };

            List<List<int>> result = newSensor.GetAllDifferencesForThatRow(filePath, input);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("exampleFile.txt")]
        public void Get_next_number_for_specific_row1(string fileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

            var input = newSensor.newExtractor(filePath)[1];

            List<List<int>> expected = new List<List<int>>
            {
                new List<int>{ 1, 3, 6, 10, 15, 21 },
                new List<int>{ 2, 3, 4, 5, 6 },
                new List<int>{ 1, 1, 1, 1 },
                new List<int>{ 0, 0, 0 },
            };

            List<List<int>> result = newSensor.GetAllDifferencesForThatRow(filePath, input);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("exampleFile.txt")]
        public void Get_next_number_for_specific_row2(string fileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

            var input = newSensor.newExtractor(filePath)[2];

            List<List<int>> expected = new List<List<int>>
            {
                new List<int>{ 10, 13, 16, 21, 30, 45},
                new List<int>{ 3, 3, 5, 9, 15 },
                new List<int>{ 0, 2, 4, 6 },
                new List<int>{ 2, 2, 2 },
                new List<int>{ 0, 0 },
            };

            List<List<int>> result = newSensor.GetAllDifferencesForThatRow(filePath, input);

            result.Should().BeEquivalentTo(expected);
        }

        //[Theory]
        //[InlineData("exampleFile.txt")]
        //public void Get_next_number_for_specific_row2(string fileName)
        //{
        //    var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);
        //    int index = 1;

        //    List<List<int>> expected = new List<List<int>>
        //    {
        //        new List<int>{ 1,   3 ,  6  ,10,  15 , 21},
        //        new List<int>{ 2 ,  3 ,  4,   5  , 6 },
        //        new List<int>{ 1 ,  1 ,  1,   1 },
        //        new List<int>{ 0  , 0  , 0 }
        //    };

        //    List<List<int>> result = newSensor.GetAllDifferencesForThatRow(filePath, index);

        //    result.Should().BeEquivalentTo(expected);
        //}

        //[Theory]
        //[InlineData("exampleFile.txt")]
        //public void aaaaaaaaaaaa(string fileName)
        //{
        //    var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

        //    List<List<int>> input = newSensor.GetAllDifferencesForThatRow(filePath, 0);

        //    int expected = 18;

        //    int result = newSensor.AddStepsToAsALastElement(input);

        //    result.Should().Be(expected);
        //}

        //[Theory]
        //[InlineData("exampleFile.txt")]
        //public void TestCalcFinal(string fileName)
        //{
        //    // Assuming `newSensor` is an instance of the class you want to test

        //    // Construct the full path to the file
        //    var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

        //    // Set the expected result
        //    int expected = 114;

        //    // Call the method under test
        //    int result = newSensor.CalcFinal(filePath);

        //    // Assert the result using FluentAssertions
        //    result.Should().Be(expected);
        //}

        //[Theory]
        //[InlineData("realFile.txt")]
        //public void asdawdwd(string fileName)
        //{
        //    var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

        //    int expected = 114;

        //    int result = newSensor.CalcFinal(filePath);

        //    result.Should().Be(expected);
        //}

        //[Theory]
        //[InlineData("exampleFile.txt")]
        //public void test_file_read(string fileName)
        //{
        //    var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../aoc/day09/data/", fileName);

        //    List<List<int>> asd = new List<List<int>>
        //    {
        //        new List<int>  { 1 ,2 ,3},
        //        new List<int>  { 1 ,2 ,3},
        //        new List<int>  { 1 ,2 ,3},
        //    };

        //    List<List<int>> result = newSensor.newExtractor(filePath);

        //    result.Should().BeEquivalentTo(asd);
        //}

        private static Sensor CreateSensor()
        {
            return new Sensor();
        }
    }
}
