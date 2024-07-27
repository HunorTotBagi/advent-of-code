using FluentAssertions;
using Xunit;

namespace AdventOfCode2023.Day01.Tests
{
    public class DocumentTests
    {
        readonly string realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day01-trebuchet/data/realData.txt";
        readonly string testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day01-trebuchet/data/testData.txt";

        readonly List<string> typedList = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        readonly List<string> typedListReverse = ["eno", "owt", "eerht", "ruof", "evif", "xis", "neves", "thgie", "enin"];
        readonly List<char> numbersList = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];

        CalibrationDocumentProcessor newCalibrationDocumentProcessor = CreateCalibrationDocumentProcessor();

        [Theory]
        [InlineData("1abc2", "1")]
        [InlineData("pqr3stu8vwx", "3")]
        [InlineData("awwdas6ba4wd4e1fgreger", "6")]
        [InlineData("treb7uchet", "7")]
        public void Should_extract_first_number(string input, string expected)
        {
            // Arrange

            // Act
            var result = newCalibrationDocumentProcessor.ExtractFirstNumber(input, typedList);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("two1nine", "2")]
        [InlineData("eightwothree", "8")]
        [InlineData("abcone2threexyz", "1")]
        [InlineData("xtwone3four", "2")]
        [InlineData("4nineeightseven2", "4")]
        [InlineData("zoneight234", "1")]
        [InlineData("7pqrstsixteen", "7")]
        public void Should_extract_first_number_for_complicated_strings(string input, string expected)
        {
            // Arrange

            // Act
            var result = newCalibrationDocumentProcessor.ExtractFirstNumber(input, typedList);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("hunor", "ronuh")]
        [InlineData("Kat4rina", "anir4taK")]
        [InlineData("hu23nor", "ron32uh")]
        public void Should_reverse_string(string input, string expected)
        {
            // Arrange

            // Act
            var result = newCalibrationDocumentProcessor.ReverseString(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("two1nine", 29)]
        [InlineData("eightwothree", 83)]
        [InlineData("abcone2threexyz", 13)]
        [InlineData("xtwone3four", 24)]
        [InlineData("4nineeightseven2", 42)]
        [InlineData("zoneight234", 14)]
        [InlineData("7pqrstsixteen", 76)]
        [InlineData("m69", 69)]
        public void Should_get_correct_number_from_string(string input, int expected)
        {
            // Arrange

            // Act
            var result = newCalibrationDocumentProcessor.GetNumber(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_sum_of_calibration_for_test_data()
        {
            // Arrange
            var expected = 281;

            // Act
            var result = newCalibrationDocumentProcessor.SumCalibrationValues(testData);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_sum_of_calibration_for_real_data()
        {
            // Arrange
            var expected = 54581;

            // Act
            var result = newCalibrationDocumentProcessor.SumCalibrationValues(realData);

            // Assert
            result.Should().Be(expected);
        }

        private static CalibrationDocumentProcessor CreateCalibrationDocumentProcessor()
        {
            return new CalibrationDocumentProcessor();
        }
    }
}