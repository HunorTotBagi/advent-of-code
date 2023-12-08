using aoc;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class Day01Test
    {
        Document newDocument = CreateCalculator();

        List<string> spelledNumbers = new List<string>() { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
                                                            "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        [Theory]
        [InlineData("1abc2", "1")]
        [InlineData("3asd4", "3")]
        [InlineData("6asd9", "6")]
        [InlineData("pqr3stu8vwx", "3")]
        [InlineData("a2rgs4uwvwx", "2")]
        [InlineData("yqr1tu8vhtr", "1")]
        [InlineData("a1b2c3d4e5f", "1")]
        [InlineData("awg1aaaaaaad4e9f", "1")]
        [InlineData("awwdas6ba4wd4e1fgreger", "6")]
        [InlineData("treb7uchet", "7")]
        [InlineData("asdasd1asdasdasd", "1")]
        [InlineData("h2o", "2")]
        public void Should_return_the_first_number_from_left(string input, string expected)
        {
            // Act
            string result = newDocument.GetFirstNumberFromLeft(input);

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
        public void Should_return_converted_number(string input, string expected)
        {
            string result = newDocument.GetFirstNumberFromLeft(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("hunor", "ronuh")]
        [InlineData("Kat4rina", "anir4taK")]
        [InlineData("hu23nor", "ron32uh")]
        public void Should_return_string_in_reverse_order(string input, string expected)
        {
            string result = newDocument.ReverseString(input);

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
        public void Should_return_combined_number(string input, int expected)
        {
            // Act
            int result = newDocument.GetNumber(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("document.txt", 54581)]
        public void FinalTest(string fileName, int expected)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day04Src/data/" + fileName;

            // Act
            int result = newDocument.SummAllUp(filePath);

            // Assert
            result.Should().Be(expected);
        }

        private static Document CreateCalculator()
        {
            return new Document();
        }
    }
}