using Day16.Src;
using FluentAssertions;

namespace Day16.Test;

public class ContraptionTest
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day16.Src/Data/testData.txt";
    private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day16.Src/Data/realData.txt";

    Contraption newContraption = CreateContraption();

    [Fact]
    public void Should_calculate_answer_for_test_data()
    {
        // Arrange
        var expected = 46;

        // Act
        var result = newContraption.Calculate(_testData, 0, -1, 0, 1);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Should_calculate_answer_for_real_data()
    {
        // Arrange
        var expected = 8116;

        // Act
        var result = newContraption.Calculate(_realData, 0, -1, 0, 1);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Should_calculate_answer_for_test_data_part_two()
    {
        // Arrange
        var expected = 8383;

        // Act
        var result = newContraption.CalculateFromEveryEdge(_realData);

        // Assert
        result.Should().Be(expected);
    }

    private static Contraption CreateContraption()
    {
        return new Contraption();
    }
}
