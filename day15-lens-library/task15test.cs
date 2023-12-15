using advent_of_code_LATEST;
using FluentAssertions;
using Xunit;

namespace TestProject1
{
    public class task15tests
    {
        LensLibrary newLensLibrary = CreateLensLibrary();

        string testData = "C:\\Users\\htotbagi\\source\\repos\\advent-of-code-LATEST\\advent-of-code-LATEST\\data\\day15\\testData.txt";
        string realData = "C:\\Users\\htotbagi\\source\\repos\\advent-of-code-LATEST\\advent-of-code-LATEST\\data\\day15\\realData.txt";

        [Theory]
        [InlineData('H', 72)]
        [InlineData('A', 65)]
        [InlineData('S', 83)]
        public void Should_return_characters_ASCII_code(char inputCharacter, int ASCIICode)
        {
            // Arrange

            // Act
            int result = newLensLibrary.ConvertToAscii(inputCharacter);

            // Assert
            result.Should().Be(ASCIICode);
        }

        [Theory]
        [InlineData("HASH", 52)]
        [InlineData("rn=1", 30)]
        [InlineData("cm-", 253)]
        [InlineData("qp=3", 97)]
        public void Should_return_HASHAlgorithm_result(string input, int expected)
        {
            // Arrange

            // Act
            int result = newLensLibrary.HASHAlgorithm(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_result_for_puzzle_1_test_data()
        {
            // Arrange
            List<string> input = newLensLibrary.ReadFile(testData);

            // Act
            int result = newLensLibrary.Final(input);

            // Assert
            result.Should().Be(1320);
        }

        [Fact]
        public void Should_return_result_for_puzzle_1_real_data()
        {
            // Arrange
            List<string> input = newLensLibrary.ReadFile(realData);

            // Act
            int result = newLensLibrary.Final(input);

            // Assert
            result.Should().Be(512950);
        }

        [Theory]
        [InlineData("rn=1", 0)]
        [InlineData("cm-", 0)]
        [InlineData("qp=3", 1)]
        [InlineData("ot=7", 3)]
        public void Should_return_box_index(string input, int expected)
        {
            // Arrange

            // Act
            int result = newLensLibrary.GetBoxIndex(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("rngwergw=1", true)]
        [InlineData("qpasd=3", true)]
        [InlineData("cm-1", false)]
        public void Should_return_true_if_string_contains_equal_symbol(string input, bool exp)
        {
            // Arrange

            // Act
            bool result = newLensLibrary.StringContainsEqualSymbol(input);

            // Assert
            result.Should().Be(exp);
        }

        [Theory]
        [InlineData("rngwergw-1", true)]
        [InlineData("qpasd=3", false)]
        [InlineData("ottt-7", true)]
        public void Should_return_true_if_string_contains_minus_symbol(string input, bool exp)
        {
            // Arrange

            // Act
            bool result = newLensLibrary.StringContainsMinusSymbol(input);

            // Assert
            result.Should().Be(exp);
        }

        [Theory]
        [InlineData("rngwergw-1", 1)]
        [InlineData("qpasd=35", 35)]
        [InlineData("ottt-711", 711)]
        public void Should_return_number(string input, int exp)
        {
            // Arrange

            // Act
            int result = newLensLibrary.ExtractNumber(input);

            // Assert
            result.Should().Be(exp);
        }

        [Fact]
        public void Should_return_result_for_puzzle_2_test_data()
        {
            // Arrange
            List<string> input = newLensLibrary.ReadFile(testData);
            
            // Act
            int result = newLensLibrary.GetFocusingPower(input);

            // Assert
            result.Should().Be(145);  
        }

        [Fact]
        public void Should_return_result_for_puzzle_2_real_data()
        {
            // Arrange
            List<string> input = newLensLibrary.ReadFile(realData);

            // Act
            int result = newLensLibrary.GetFocusingPower(input);

            // Assert
            result.Should().Be(247153);
        }

        private static LensLibrary CreateLensLibrary()
        {
            return new LensLibrary();
        }
    }
}