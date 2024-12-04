using Day15.Src;
using FluentAssertions;

namespace Day15.Test;

public class Tests
{
    LensLibrary newLensLibrary = CreateLensLibrary();

    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day15.Src/testData.txt";

    [Theory]
    [InlineData('H', 72)]
    [InlineData('A', 65)]
    [InlineData('S', 83)]
    public void Should_return_characters_ASCII_code(char inputCharacter, int ASCIICode)
    {
        // Arrange

        // Act
        var result = newLensLibrary.GetAsciiValue(inputCharacter);

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
        var result = newLensLibrary.GetHashValue(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Should_return_result_for_puzzle_1_test_data()
    {
        // Arrange
        var input = newLensLibrary.ReadInitializationSequence(_testData);

        // Act
        var result = newLensLibrary.SumOfHashValues(input);

        // Assert
        result.Should().Be(1320);
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
        var result = newLensLibrary.GetBoxIndex(input);

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
        var result = newLensLibrary.ContainsEqualSymbol(input);

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
        var result = newLensLibrary.ContainsMinusSymbol(input);

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
        var result = newLensLibrary.ExtractNumber(input);

        // Assert
        result.Should().Be(exp);
    }

    [Fact]
    public void Should_return_result_for_puzzle_2_test_data()
    {
        // Arrange
        var input = newLensLibrary.ReadInitializationSequence(_testData);

        // Act
        var result = newLensLibrary.CalculateTotalFocusingPower(input);

        // Assert
        result.Should().Be(145);
    }

    private static LensLibrary CreateLensLibrary()
    {
        return new LensLibrary();
    }
}