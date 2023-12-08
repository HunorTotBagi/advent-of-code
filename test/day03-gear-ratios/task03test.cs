using FluentAssertions;
using Xunit;

namespace test.day03_gear_ratios
{
    public class task03test
    {
        Schematic schematic = new Schematic();

        [Fact]
        public void Should_return_summ_of_all_numbers_in_schema()
        {
            // Arrange
            string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\engineSchematic.txt";

            // Act
            int result = schematic.SummUpAllNumbersInSchematic(filePath);

            // Assert

            result.Should().Be(4533);
        }

        [Fact]
        public void Should_extend_given_file_with_dots()
        {
            // Arrange
            string filePath1 = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\singleDigit.txt";
            string filePath2 = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\singleDigitExtended.txt";
            var extendedSchema = schematic.ReadFileToList(filePath2);

            // Act
            List<string> result = schematic.ExtendSchematic(filePath1);

            // Assert
            result.Should().BeEquivalentTo(extendedSchema);

        }

        [Fact]
        public void Is_the_number_first()
        {
            // Arrange
            string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\trippleDigitExtended.txt";
            var extendedSchema = schematic.ReadFileToList(filePath);
            int i = 1;
            int j = 1;

            // Act
            bool result = schematic.IsTheNumberFirst(extendedSchema, i, j);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Is_the_number_middle()
        {
            string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\trippleDigitExtended.txt";
            var extendedSchema = schematic.ReadFileToList(filePath);
            int i = 1;
            int j = 2;

            bool result = schematic.IsTheNumberMiddle(extendedSchema, i, j);

            result.Should().BeTrue();
        }

        [Fact]
        public void Is_the_number_last()
        {
            string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\trippleDigitExtended.txt";
            var extendedSchema = schematic.ReadFileToList(filePath);
            int i = 1;
            int j = 3;

            bool result = schematic.IsTheNumberLast(extendedSchema, i, j);

            result.Should().BeTrue();
        }

        [Fact]
        public void Should_return_lenght_off_all_numbers()
        {
            // Arrange
            string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\engineSchematicsExtended.txt";
            List<int> expected = new List<int>
            {
                3, 3, 2, 3, 3, 2, 3, 3, 3, 3
            };

            // Act
            List<int> result = schematic.GetLenghtOfAllNumbers(filePath);

            result.Should().Equal(expected);

            // Assert
        }

        [Fact]
        public void single_digit_all_points_around()
        {
            // Arrange
            string path = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\singleDigitExtended.txt";
            int i = 1;
            int j = 1;


            // Act
            bool result = schematic.Dimension1(path, i, j);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void double_digit_all_points_around()
        {
            // Arrange
            string path = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\doubleDigitExtended.txt";
            int i = 1;
            int j = 2;


            // Act
            bool result = schematic.Dimension2(path, i, j);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void triple_digit_all_points_around()
        {
            // Arrange
            string path = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day03Src\\files\\trippleDigitExtended.txt";
            int i = 1;
            int j = 3;


            // Act
            bool result = schematic.Dimension3(path, i, j);

            // Assert
            result.Should().BeTrue();
        }
    }
}
