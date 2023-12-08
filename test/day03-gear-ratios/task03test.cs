using FluentAssertions;
using Xunit;

namespace test.day03_gear_ratios
{
    public class task03test
    {
        Schematic newSchematic = CreateSchematic();

        [Theory]
        [InlineData("engineSchematic.txt")]
        public void Should_return_summ_of_all_numbers_in_schema(string fileName)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + fileName;

            // Act
            int result = newSchematic.SummUpAllNumbersInSchematic(filePath);

            // Assert
            result.Should().Be(4533);
        }

        [Theory]
        [InlineData("singleDigit.txt", "singleDigitExtended.txt")]
        [InlineData("doubleDigit.txt", "doubleDigitExtended.txt")]
        [InlineData("trippleDigit.txt", "trippleDigitExtended.txt")]
        public void Should_extend_given_file_with_dots(string firstFileName, string secondFileName)
        {
            // Arrange
            var firstFilePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + firstFileName;
            var secondFilePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + secondFileName;

            var expected = newSchematic.ReadFileToList(secondFilePath);

            // Act
            List<string> result = newSchematic.ExtendSchematicWithDots(firstFilePath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        //[Fact]
        //public void Is_the_number_first()
        //{
        //    // Arrange
        //    string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\trippleDigitExtended.txt";
        //    var extendedSchema = newSchematic.ReadFileToList(filePath);
        //    int i = 1;
        //    int j = 1;

        //    // Act
        //    bool result = newSchematic.IsTheNumberFirst(extendedSchema, i, j);

        //    // Assert
        //    result.Should().BeTrue();
        //}

        //[Fact]
        //public void Is_the_number_middle()
        //{
        //    string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\trippleDigitExtended.txt";
        //    var extendedSchema = newSchematic.ReadFileToList(filePath);
        //    int i = 1;
        //    int j = 2;

        //    bool result = newSchematic.IsTheNumberMiddle(extendedSchema, i, j);

        //    result.Should().BeTrue();
        //}

        //[Fact]
        //public void Is_the_number_last()
        //{
        //    string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\trippleDigitExtended.txt";
        //    var extendedSchema = newSchematic.ReadFileToList(filePath);
        //    int i = 1;
        //    int j = 3;

        //    bool result = newSchematic.IsTheNumberLast(extendedSchema, i, j);

        //    result.Should().BeTrue();
        //}

        //[Fact]
        //public void Should_return_lenght_off_all_numbers()
        //{
        //    // Arrange
        //    string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\engineSchematicsExtended.txt";
        //    List<int> expected = new List<int>
        //    {
        //        3, 3, 2, 3, 3, 2, 3, 3, 3, 3
        //    };

        //    // Act
        //    List<int> result = newSchematic.GetLenghtOfAllNumbers(filePath);

        //    result.Should().Equal(expected);

        //    // Assert
        //}

        [Theory]
        [InlineData("singleDigitExtended.txt", 1, 1)]
        public void single_digit_all_points_around(string fileName, int rowIndex, int columnIndex)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + fileName;

            // Act
            bool result = newSchematic.Dimension1(filePath, rowIndex, columnIndex);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("doubleDigitExtended.txt", 1, 2)]
        public void double_digit_all_points_around(string fileName, int rowIndex, int columnIndex)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + fileName;

            // Act
            bool result = newSchematic.Dimension2(filePath, rowIndex, columnIndex);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("trippleDigitExtended.txt", 1, 3)]
        public void tripple_digit_all_points_around(string fileName, int rowIndex, int columnIndex)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + fileName;

            // Act
            bool result = newSchematic.Dimension3(filePath, rowIndex, columnIndex);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("engineFirstRow.txt")]
        public void Should_return_correct_sum(string fileName)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + fileName;

            // Act
            int result = newSchematic.GetFinalResult(filePath);

            // Assert
            result.Should().Be(467);
        }

        private static Schematic CreateSchematic()
        {
            return new Schematic();
        }


    }
}
