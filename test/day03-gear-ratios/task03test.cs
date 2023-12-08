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
        public void Should_extend_given_file_with_dots(string firstFileName, string secondFileName)
        {
            // Arrange
            var firstFilePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + firstFileName;
            var secondFilePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + secondFileName;

            var expected = newSchematic.ReadFileToList(secondFilePath);

            // Act
            List<string> result = newSchematic.ExtendSchematic(firstFilePath);

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

        //[Fact]
        //public void single_digit_all_points_around()
        //{
        //    // Arrange
        //    string path = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\singleDigitExtended.txt";
        //    int i = 1;
        //    int j = 1;


        //    // Act
        //    bool result = newSchematic.Dimension1(path, i, j);

        //    // Assert
        //    result.Should().BeTrue();
        //}

        //[Fact]
        //public void double_digit_all_points_around()
        //{
        //    // Arrange
        //    string path = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\doubleDigitExtended.txt";
        //    int i = 1;
        //    int j = 2;


        //    // Act
        //    bool result = newSchematic.Dimension2(path, i, j);

        //    // Assert
        //    result.Should().BeTrue();
        //}

        //[Fact]
        //public void triple_digit_all_points_around()
        //{
        //    // Arrange
        //    string path = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\trippleDigitExtended.txt";
        //    int i = 1;
        //    int j = 3;


        //    // Act
        //    bool result = newSchematic.Dimension3(path, i, j);

        //    // Assert
        //    result.Should().BeTrue();
        //}

        private static Schematic CreateSchematic()
        {
            return new Schematic();
        }
    }
}
