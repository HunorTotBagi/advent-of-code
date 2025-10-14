using Day16.Src;
using FluentAssertions;

namespace Day16.Test;

public class ContraptionTest
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day16.Src/testData.txt";

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

    private static Contraption CreateContraption()
    {
        return new Contraption();
    }
}
