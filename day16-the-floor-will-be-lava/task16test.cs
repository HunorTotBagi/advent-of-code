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
        public void Should_give_answer()
        {
            // Arrange
            var expeceted = 46;

            // Act
            var result = newContraption.Calculate(testData0);

            // Assert
            result.Should().Be(expeceted);
        }

        [Fact]
        public void Should_give_answer_real()
        {
            // Arrange
            var expeceted = 8116;

            // Act
            var result = newContraption.Calculate(realData);

            // Assert
            result.Should().Be(expeceted);
        }

        private static Contraption CreateContraption()
        {
            return new Contraption();
        }
    }
}