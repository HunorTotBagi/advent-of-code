using FluentAssertions;
using Xunit;

namespace AdventOfCode2023.Day16.Tests
{
    public class ContraptionTest
    {
        string realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day16-the-floor-will-be-lava/data/realData.txt";
        string testData0 = AppDomain.CurrentDomain.BaseDirectory + "../../../../advent-of-code-LATEST/day16-the-floor-will-be-lava/data/testData0.txt";

        Contraption newContraption = CreateContraption();

        [Fact]
        public void Should_calculate_answer_for_test_data()
        {
            // Arrange
            var expeceted = 46;

            // Act
            var result = newContraption.Calculate(testData0, 0, -1, 0, 1);

            // Assert
            result.Should().Be(expeceted);
        }

        [Fact]
        public void Should_calculate_answer_for_real_data()
        {
            // Arrange
            var expeceted = 8116;

            // Act
            var result = newContraption.Calculate(realData, 0, -1, 0, 1);

            // Assert
            result.Should().Be(expeceted);
        }

        [Fact]
        public void Should_calculate_answer_for_test_data_part_two()
        {
            // Arrange
            var expeceted = 8383;

            // Act
            var result = newContraption.CalculateFromEveryEdge(realData);

            // Assert
            result.Should().Be(expeceted);
        }

        private static Contraption CreateContraption()
        {
            return new Contraption();
        }
    }
}